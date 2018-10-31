import { Component, OnInit } from "@angular/core";
import { UserService } from "../services/user.service";
import { User } from "../user";

@Component({
  selector: "dvn-current-user",
  templateUrl: "./current-user.component.html",
  styleUrls: ["./current-user.component.scss"]
})
export class CurrentUserComponent implements OnInit {
  public user: User;

  constructor(private userSvc: UserService) {}

  ngOnInit() {
    this.user = this.userSvc.GetUser();
  }
}
