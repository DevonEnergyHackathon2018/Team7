import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { CompressorDashboardPageComponent } from "./compressor-dashboard-page/compressor-dashboard-page.component";

const routes: Routes = [
  { path: "", pathMatch: "full", component: CompressorDashboardPageComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CompressorDashboardRoutingModule {}
