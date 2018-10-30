import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";
import { Compressor } from "../../data/compressor.data";

@Component({
  selector: "dvn-compressor-list",
  templateUrl: "./compressor-list.component.html",
  styleUrls: ["./compressor-list.component.scss"]
})
export class CompressorListComponent implements OnInit {
  @Input()
  public compressors: Array<Compressor>;

  @Output()
  public dismiss = new EventEmitter<number>();

  constructor() {}

  ngOnInit() {}

  public onDismissed(key: number): void {
    this.dismiss.emit(key);
  }
}
