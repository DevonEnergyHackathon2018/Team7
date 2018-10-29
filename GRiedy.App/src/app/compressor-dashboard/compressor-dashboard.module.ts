import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { CoreModule } from "../core/core.module";
import { SharedModule } from "../shared/shared.module";

import { CompressorDashboardRoutingModule } from "./compressor-dashboard-routing.module";
import { CompressorDashboardPageComponent } from "./compressor-dashboard-page/compressor-dashboard-page.component";
import { CompressorCardComponent } from "./compressor-card/compressor-card.component";
import { CompressorDialogComponent } from "./compressor-dialog/compressor-dialog.component";
import { CompressorListComponent } from "./compressor-list/compressor-list.component";

@NgModule({
  imports: [CommonModule, CoreModule, SharedModule, CompressorDashboardRoutingModule],
  declarations: [
    CompressorDashboardPageComponent,
    CompressorCardComponent,
    CompressorDialogComponent,
    CompressorListComponent
  ]
})
export class CompressorDashboardModule {}
