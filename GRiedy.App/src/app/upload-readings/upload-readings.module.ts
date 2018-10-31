import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { CoreModule } from "../core/core.module";
import { SharedModule } from "../shared/shared.module";

import { UploadReadingsRoutingModule } from "./upload-readings-routing.module";
import { UploadReadingsPageComponent } from "./upload-readings-page/upload-readings-page.component";

@NgModule({
  imports: [CommonModule, CoreModule, SharedModule, UploadReadingsRoutingModule],
  declarations: [UploadReadingsPageComponent]
})
export class UploadReadingsModule {}
