import { Component, OnInit } from "@angular/core";
import { UserService } from "./services/user.service";

@Component({
  selector: "dvn-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"]
})
export class AppComponent implements OnInit {
  title = "dvn";

  constructor(private readonly userSvc: UserService) {}

  public ngOnInit(): void {
    const user = this.userSvc.GetUser();
    console.log(`user: ${user.FullName}`);
  }
}
