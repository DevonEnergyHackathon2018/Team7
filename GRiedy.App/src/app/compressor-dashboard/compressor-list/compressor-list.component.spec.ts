import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { CompressorListComponent } from "./compressor-list.component";

describe("CompressorListComponent", () => {
  let component: CompressorListComponent;
  let fixture: ComponentFixture<CompressorListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [CompressorListComponent]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompressorListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
