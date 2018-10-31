import { Component, OnInit } from "@angular/core";
import { User } from "../../user";
import { UserService } from "../../services/user.service";

@Component({
  selector: "dvn-top-nav",
  templateUrl: "./top-nav.component.html",
  styleUrls: ["./top-nav.component.scss"]
})
export class TopNavComponent implements OnInit {
  public user: User;

  constructor(private readonly userSvc: UserService) {}

  ngOnInit() {
    //this.user = this.userSvc.GetUser();
  }
}
