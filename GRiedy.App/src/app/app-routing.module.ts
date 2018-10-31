import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { CurrentUserComponent } from "./current-user/current-user.component";
import { NotFoundComponent } from "./not-found/not-found.component";

const routes: Routes = [
  { path: "", pathMatch: "full", redirectTo: "compressor-dashboard" },
  {
    path: "compressor-dashboard",
    loadChildren:
      "app/compressor-dashboard/compressor-dashboard.module#CompressorDashboardModule"
  },
  {
    path: "upload-readings",
    loadChildren:
      "app/upload-readings/upload-readings.module#UploadReadingsModule"
  },
  { path: "current-user", pathMatch: "full", component: CurrentUserComponent },
  { path: "**", pathMatch: "full", component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
