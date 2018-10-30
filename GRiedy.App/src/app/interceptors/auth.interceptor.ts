import { Injectable } from "@angular/core";

import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from "@angular/common/http";

import { Observable } from "rxjs/Observable";
import { Adal5Service } from "adal-angular5";
import { JwtHelper } from "angular2-jwt";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private readonly authSvc: Adal5Service) {}

  private getNewRequest(
    request: HttpRequest<any>,
    token: string
  ): HttpRequest<any> {
    return request.clone({
      setHeaders: {
        Authorization: "Bearer " + token
      }
    });
  }

  public intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const resource = this.authSvc.GetResourceForEndpoint(request.url);
    if (resource) {
      const cachedToken = this.authSvc.getCachedToken(resource);
      if (cachedToken) {
        const jwtHelper = new JwtHelper();
        if (jwtHelper.isTokenExpired(cachedToken)) {
          console.warn(`access token for ${resource} has expired`);
        } else {
          request = this.getNewRequest(request, cachedToken);
          return next.handle(request);
        }
      } else {
        console.log(`no cached access token for ${resource}`);
      }

      console.log(`acquiring access token for ${resource}`);
      return this.authSvc.acquireToken(resource).mergeMap(token => {
        console.log(`new access token acquired for ${resource}`);
        request = this.getNewRequest(request, token);
        return next.handle(request);
      });
    }

    console.error(`there is no resource associated with ${request.url}`);
    return next.handle(request);
  }
}
