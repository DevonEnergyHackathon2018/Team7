import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { UploadReadingsPageComponent } from "./upload-readings-page.component";

describe("UploadReadingsPageComponent", () => {
  let component: UploadReadingsPageComponent;
  let fixture: ComponentFixture<UploadReadingsPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [UploadReadingsPageComponent]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UploadReadingsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
