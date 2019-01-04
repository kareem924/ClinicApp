import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';




import { AuthModule } from './modules/auth/auth.module';
import { HomeModule} from './modules/home/home.module';
import { AppRoutingModule } from './app-routing.module';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,

  ],
  imports: [
    // angular
    BrowserModule,

    // 3rd party
    AuthModule,
    HomeModule,
    // core & shared


    // app
    AppRoutingModule,

    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }