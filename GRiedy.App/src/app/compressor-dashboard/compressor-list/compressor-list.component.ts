import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";
import { Compressor } from "../../data/compressor.data";
import { query, stagger, trigger, transition, animate, style } from "@angular/animations";

@Component({
  selector: "dvn-compressor-list",
  templateUrl: "./compressor-list.component.html",
  styleUrls: ["./compressor-list.component.scss"],
  // animations: [
  //   trigger('listAnimation', [
  //     transition('* => *', [ // each time the binding value changes
  //       query(':leave', [
  //         stagger(100, [
  //           animate('0.5s', style({ opacity: 0 }))
  //         ])
  //       ]),
  //       query(':enter', [
  //         style({ opacity: 0 }),
  //         stagger(100, [
  //           animate('0.5s', style({ opacity: 1 }))
  //         ])
  //       ])
  //     ])
  //   ])
  // ],
})
export class CompressorListComponent implements OnInit {
  @Input()
  public compressors: Array<Compressor>;

  @Output()
  public dismiss = new EventEmitter<string>();

  private animationInitialized: boolean = false;

  constructor() {}

  ngOnInit() {}

  public onDismissed(key: string): void {
    this.dismiss.emit(key);
  }
}
