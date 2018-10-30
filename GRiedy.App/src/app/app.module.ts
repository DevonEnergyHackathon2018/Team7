import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";

import { AppRoutingModule } from "./app-routing.module";
import { CoreModule } from "./core/core.module";
import { SharedModule } from "./shared/shared.module";

import { AppComponent } from "./app.component";
import { NotFoundComponent } from "./not-found/not-found.component";

import { BusyService } from "./services/busy.service";
import { MessageService } from "./services/message.service";
import { UserService } from "./services/user.service";

import { CurrentUserComponent } from "./current-user/current-user.component";
import { CompressorService } from "./services/compressor.service";

@NgModule({
  declarations: [
    AppComponent,
    NotFoundComponent,
    CurrentUserComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,
    CoreModule,
    HttpClientModule,
    SharedModule
  ],
  providers: [
    BusyService,
    MessageService,
    UserService,
    CompressorService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
