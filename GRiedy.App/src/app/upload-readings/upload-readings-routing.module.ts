import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { UploadReadingsPageComponent } from "./upload-readings-page/upload-readings-page.component";

const routes: Routes = [
  { path: "", pathMatch: "full", component: UploadReadingsPageComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UploadReadingsRoutingModule {}
