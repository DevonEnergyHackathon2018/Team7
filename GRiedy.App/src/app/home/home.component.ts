import { Component } from "@angular/core";
import { MessageService } from "../services/message.service";

@Component({
  selector: "dvn-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.scss"]
})
export class HomeComponent {
  public uploadedFiles = [];

  constructor(public messageSvc: MessageService) {}

  public onUpload(event: any): void {
    for (const file of event.files) {
      this.uploadedFiles.push(file);
    }

    this.messageSvc.AddInfo("compressor analysis", "file uploaded");
  }
}
