import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgModule } from "@angular/core";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { Adal5Service } from "adal-angular5";

import { AppRoutingModule } from "./app-routing.module";
import { CoreModule } from "./core/core.module";
import { SharedModule } from "./shared/shared.module";

import { AppComponent } from "./app.component";
import { HomeComponent } from "./home/home.component";
import { NotFoundComponent } from "./not-found/not-found.component";

import { AuthInterceptor } from "./interceptors/auth.interceptor";
import { JsonInterceptor } from "./interceptors/json.interceptor";

import { BusyService } from "./services/busy.service";
import { MessageService } from "./services/message.service";
import { UserService } from "./services/user.service";

import { CurrentUserComponent } from "./current-user/current-user.component";

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
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
    Adal5Service,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      deps: [Adal5Service],
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JsonInterceptor,
      multi: true
    },
    BusyService,
    MessageService,
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
