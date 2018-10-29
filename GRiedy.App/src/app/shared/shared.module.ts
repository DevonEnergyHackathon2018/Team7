import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

import {
  MatButtonModule,
  MatCardModule,
  MatCheckboxModule,
  MatFormFieldModule,
  MatGridListModule,
  MatListModule,
  MatSelectModule,
  MatSidenavModule,
  MatToolbarModule
} from "@angular/material";

import { FileUploadModule } from "primeng/fileupload";
import { TableModule } from "primeng/table";
import { GrowlModule } from "primeng/growl";

@NgModule({
  imports: [
    CommonModule,
    MatButtonModule,
    MatCardModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatGridListModule,
    MatListModule,
    MatSelectModule,
    MatSidenavModule,
    MatToolbarModule,
    FormsModule,
    ReactiveFormsModule,
    FileUploadModule,
    GrowlModule,
    TableModule
  ],
  exports: [
    MatButtonModule,
    MatCardModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatGridListModule,
    MatListModule,
    MatSelectModule,
    MatSidenavModule,
    MatToolbarModule,
    FormsModule,
    ReactiveFormsModule,
    FileUploadModule,
    GrowlModule,
    TableModule
  ],
  declarations: []
})
export class SharedModule {}
