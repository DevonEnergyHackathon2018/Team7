import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { CompressorDialogComponent } from "./compressor-dialog.component";

describe("CompressorDialogComponent", () => {
  let component: CompressorDialogComponent;
  let fixture: ComponentFixture<CompressorDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [CompressorDialogComponent]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompressorDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
