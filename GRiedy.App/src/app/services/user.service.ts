import { Injectable } from "@angular/core";
import { Adal5Service } from "adal-angular5";
import { User } from "../user";

@Injectable()
export class UserService {
  private static user: User;

  constructor(private readonly authSvc: Adal5Service) {}

  public GetUser(): User {
    if (!UserService.user) {
      UserService.user = new User(this.authSvc);
      UserService.user.Username = this.authSvc.userInfo.username;
      if (this.authSvc.userInfo.profile) {
        UserService.user.FullName = `${
          this.authSvc.userInfo.profile.given_name
        } ${this.authSvc.userInfo.profile.family_name}`;
      }
    }

    return UserService.user;
  }
}
