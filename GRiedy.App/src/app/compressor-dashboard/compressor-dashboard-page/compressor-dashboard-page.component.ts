import { Component, OnInit } from "@angular/core";
import { MessageService } from "../../services/message.service";
import { CompressorService } from "../../services/compressor.service";
import { Compressor } from "../../data/compressor.data";
import { HubConnectionBuilder } from "@aspnet/signalr";

@Component({
  selector: "dvn-compressor-dashboard-page",
  templateUrl: "./compressor-dashboard-page.component.html",
  styleUrls: ["./compressor-dashboard-page.component.scss"]
})
export class CompressorDashboardPageComponent implements OnInit {
  public compressors: Array<Compressor>;

  constructor(
    private compressorSvc: CompressorService,
    public messageSvc: MessageService
  ) {}

  private getCompressors(): void {
    this.compressorSvc.GetAll().subscribe(
      compressors => {
        this.compressors = compressors;
        if (this.compressors) {
          this.messageSvc.AddInfo(
            "greidy",
            `${compressors.length} compressors were found.`
          );
        } else {
          this.messageSvc.AddInfo("greidy", "no compressors were found.");
        }
      },
      error => {
        this.messageSvc.AddError("greidy", error);
      }
    );
  }

  public ngOnInit(): void {
    const connection = new HubConnectionBuilder()
      .withUrl("http://localhost:5000/signalr")
      .build();

    connection.on("send", data => {
      console.log(data);
      this.getCompressors();
    });

    connection.start();

    this.getCompressors();
  }
}
