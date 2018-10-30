import { Component } from "@angular/core";
import { MessageService } from "../../services/message.service";

@Component({
  selector: "dvn-upload-readings-page",
  templateUrl: "./upload-readings-page.component.html",
  styleUrls: ["./upload-readings-page.component.scss"]
})
export class UploadReadingsPageComponent {
  public uploadedFiles = [];

  constructor(public messageSvc: MessageService) {}

  public onUpload(event: any): void {
    for (const file of event.files) {
      this.uploadedFiles.push(file);
    }

    this.messageSvc.AddInfo("compressor analysis", "file uploaded");
  }
}
