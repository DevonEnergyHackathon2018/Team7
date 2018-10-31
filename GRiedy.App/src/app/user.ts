import { JwtHelper } from "angular2-jwt";
import { Adal5Service } from "adal-angular5";

export class User {
  // constructor(private readonly authSvc: Adal5Service) {}

  public Username: string;
  public FullName: string;

  /*
  public hasRole(resource: string, role: string): boolean {
    const token = this.authSvc.getCachedToken(resource);
    if (token === null) {
      return false;
    }

    const jwtHelper = new JwtHelper();
    const tokenInfo = jwtHelper.decodeToken(token);
    if (!tokenInfo) {
      return false;
    }
    if (!tokenInfo.roles) {
      return false;
    }

    let i = 0;
    let found = false;
    while (i < tokenInfo.roles.length && !found) {
      if (tokenInfo.roles[i] === role) {
        found = true;
      } else {
        i++;
      }
    }

    return found;
  }

  public isAdmin(resource: string): boolean {
    return this.hasRole(resource, "admin");
  }

  public isContributor(resource: string): boolean {
    return this.hasRole(resource, "contributor");
  }
  */
}
