import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { CompressorDashboardPageComponent } from "./compressor-dashboard-page.component";

describe("CompressorDashboardPageComponent", () => {
  let component: CompressorDashboardPageComponent;
  let fixture: ComponentFixture<CompressorDashboardPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [CompressorDashboardPageComponent]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CompressorDashboardPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
