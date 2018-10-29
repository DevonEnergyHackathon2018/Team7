import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { CompressorCardComponent } from "./compressor-card.component";

describe("CompressorCardComponent", () => {
  let component: CompressorCardComponent;
  let fixture: ComponentFixture<CompressorCardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [CompressorCardComponent]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompressorCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
