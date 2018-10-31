import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";
import { Compressor } from "../../data/compressor.data";

@Component({
  selector: "dvn-compressor-card",
  templateUrl: "./compressor-card.component.html",
  styleUrls: ["./compressor-card.component.scss"]
})
export class CompressorCardComponent implements OnInit {
  @Input()
  public compressor: Compressor;

  @Output()
  public dismiss = new EventEmitter<number>();

  constructor() {}

  ngOnInit() {}

  public onDismissButtonClicked(key: number): void {
    this.dismiss.emit(key);
  }
}
