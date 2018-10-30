import { Component, OnInit, Input } from "@angular/core";
import { Compressor } from "../../data/compressor.data";

@Component({
  selector: "dvn-compressor-list",
  templateUrl: "./compressor-list.component.html",
  styleUrls: ["./compressor-list.component.scss"]
})
export class CompressorListComponent implements OnInit {
  @Input()
  public compressors: Array<Compressor>;

  constructor() {}

  ngOnInit() {}
}
