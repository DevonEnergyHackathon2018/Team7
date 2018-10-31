import { Component, OnInit, Input } from "@angular/core";
import { Compressor } from "../../data/compressor.data";

@Component({
  selector: "dvn-compressor-card",
  templateUrl: "./compressor-card.component.html",
  styleUrls: ["./compressor-card.component.scss"]
})
export class CompressorCardComponent implements OnInit {
  @Input()
  public compressor: Compressor;

  constructor() {}

  ngOnInit() {
    console.log('happens');
  }
}
