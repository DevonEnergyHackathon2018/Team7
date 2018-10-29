import { Component, OnInit } from "@angular/core";
import { MessageService } from "../../services/message.service";
import { CompressorService } from "../../services/compressor.service";
import { Compressor } from "../../data/compressor.data";

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

  ngOnInit() {
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
}
