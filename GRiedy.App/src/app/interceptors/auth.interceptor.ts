import { Injectable } from "@angular/core";

import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from "@angular/common/http";

import { Observable } from "rxjs/Observable";
import { Adal5Service } from "adal-angular5";

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
    // request = this.getNewRequest(request, token);
    return next.handle(request);
  }
}
