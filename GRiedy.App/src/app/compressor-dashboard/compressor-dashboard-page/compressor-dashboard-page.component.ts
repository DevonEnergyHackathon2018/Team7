import { Component, OnInit } from "@angular/core";
import { MessageService } from "../../services/message.service";
import { CompressorService } from "../../services/compressor.service";
import { Compressor } from "../../data/compressor.data";

import { SignalR, ISignalRConnection } from "ng2-signalr";
import { MatDialog } from "@angular/material";
import { UploadReadingsPageComponent } from "../../upload-readings/upload-readings-page/upload-readings-page.component";

@Component({
  selector: "dvn-compressor-dashboard-page",
  templateUrl: "./compressor-dashboard-page.component.html",
  styleUrls: ["./compressor-dashboard-page.component.scss"]
})
export class CompressorDashboardPageComponent implements OnInit {
  private connection: ISignalRConnection;

  public compressors: Array<Compressor>;

  constructor(
    private compressorSvc: CompressorService,
    private signalR: SignalR,
    public messageSvc: MessageService,
    public dialog: MatDialog
  ) {
    this.compressors = [];
  }

  public ngOnInit(): void {
    this.signalR.connect().then(c => {
      this.connection = c;

      c.listenFor("CompressorsChanged").subscribe(
        x => {
          const lookup:any = {};
          for(let i = 0; i < this.compressors.length; i++) {
            lookup[this.compressors[i].CompressorName] = i;
          }
          const result = x as Array<Compressor>;
          result.forEach(c => {
            if(lookup[c.CompressorName] === 0 || lookup[c.CompressorName] > 0) {
              console.log('c', c);
              console.log('lookup[c.CompressorName]', Object.assign({}, lookup[c.CompressorName]));
              this.compressors[lookup[c.CompressorName]] = c;
              return;
            }
            this.compressors.push(c);
          });
          console.log('this.compressors', this.compressors);
        },
        error => {
          console.error(error);
        }
      );
      c.listenFor("CompressorDismissed").subscribe(
        x => {
          //const index = this.compressors.findIndex(c => c.CompressorName == x);
          //this.compressors.splice(index, 1);

          const c = this.compressors.find(c => c.CompressorName == x);
          c.Removed = true;
          
        }, error => {
          console.error(error);
        }
      )
    });
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(UploadReadingsPageComponent, {
      width: '500px',
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }

  public onDismiss(key: number): void {
    this.compressorSvc.Dismiss(key).subscribe(
      () => {
        this.messageSvc.AddSuccess("griedy", "The compressor was dismissed!");
      },
      error => {
        this.messageSvc.AddError("griedy", error);
      }
    );
  }
}
