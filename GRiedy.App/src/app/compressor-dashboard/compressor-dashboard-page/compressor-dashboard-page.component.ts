import { Component, OnInit, Injectable } from "@angular/core";
import { MessageService } from "../../services/message.service";
import { CompressorService } from "../../services/compressor.service";
import { Compressor } from "../../data/compressor.data";

import { SignalR } from "ng2-signalr";

@Component({
  selector: "dvn-compressor-dashboard-page",
  templateUrl: "./compressor-dashboard-page.component.html",
  styleUrls: ["./compressor-dashboard-page.component.scss"]
})
export class CompressorDashboardPageComponent implements OnInit {
  public compressors: Array<Compressor>;

  constructor(
    private compressorSvc: CompressorService,
    private signalR: SignalR,
    public messageSvc: MessageService
  ) {}

  private getCompressors(): void {
    this.compressorSvc.GetAll().subscribe(
      compressors => {
        this.compressors = compressors;
        if (this.compressors) {
          this.messageSvc.AddInfo(
            "griedy",
            `${compressors.length} compressors were found.`
          );
        } else {
          this.messageSvc.AddInfo("griedy", "no compressors were found.");
        }
      },
      error => {
        this.messageSvc.AddError("griedy", error);
      }
    );
  }

  public ngOnInit(): void {
    this.signalR.connect().then(c => {
      c.listenFor("CompressorsAdded").subscribe(
        x => {
          this.getCompressors();
        },
        error => {
          console.error(error);
        }
      );
    });

    this.getCompressors();
  }
}
