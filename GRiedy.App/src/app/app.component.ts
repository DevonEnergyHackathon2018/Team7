import { Component, OnInit } from "@angular/core";
import { Adal5Service } from "adal-angular5";
import { environment } from "../environments/environment";
import { UserService } from "./services/user.service";
import { BusyService } from "./services/busy.service";

@Component({
  selector: "dvn-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"]
})
export class AppComponent implements OnInit {
  title = "dvn";

  constructor(
    private readonly authSvc: Adal5Service,
    private readonly userSvc: UserService,
    private readonly busySvc: BusyService
  ) {
    //this.authSvc.init(environment.adalConfig);
  }

  public get isAuthenticated(): boolean {
    return true;
    //return this.authSvc.userInfo.authenticated;
  }

  public get isBusy(): boolean {
    return this.busySvc.IsBusy();
  }

  public ngOnInit(): void {
    //this.authSvc.handleWindowCallback();

    // if (!this.authSvc.userInfo.authenticated) {
    //   this.authSvc.login();
    //   return;
    // }

    const user = this.userSvc.GetUser();
    console.log(`user: ${user.FullName}`);
  }
}
