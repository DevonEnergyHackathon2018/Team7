import { Component, OnInit, Input, Output, EventEmitter, trigger, state, transition, style, animate } from "@angular/core";
import { Compressor } from "../../data/compressor.data";

@Component({
  selector: "dvn-compressor-card",
  templateUrl: "./compressor-card.component.html",
  styleUrls: ["./compressor-card.component.scss"],
})
export class CompressorCardComponent implements OnInit {
  @Input()
  public compressor: Compressor;
  private animationInitialized: boolean = false;

  @Output()
  public dismiss = new EventEmitter<string>();

  constructor() {}

  ngOnInit() {}

  public onDismissButtonClicked(key: string): void {
    this.dismiss.emit(key);
  }
}
