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

import { SignalRModule } from "ng2-signalr";
import { SignalRConfiguration } from "ng2-signalr";

// >= v2.0.0
export function createConfig(): SignalRConfiguration {
  const c = new SignalRConfiguration();
  c.hubName = "CompressorHub";
  c.qs = { user: "cooluser" };
  c.url = "http://localhost:5000/signalr";
  c.logging = true;

  // >= v5.0.0
  c.executeEventsInZone = true; // optional, default is true
  c.executeErrorsInZone = false; // optional, default is false
  c.executeStatusChangeInZone = true; // optional, default is true
  return c;
}

@NgModule({
  declarations: [AppComponent, NotFoundComponent, CurrentUserComponent],
  imports: [
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,
    CoreModule,
    HttpClientModule,
    SharedModule,
    SignalRModule.forRoot(createConfig)
  ],
  providers: [BusyService, MessageService, UserService, CompressorService],
  bootstrap: [AppComponent]
})
export class AppModule {}
