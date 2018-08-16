import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { HttpService } from './http.service';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { TokyoComponent } from './tokyo/tokyo.component';
import { OkinawaComponent } from './okinawa/okinawa.component';
import { KumamotoComponent } from './kumamoto/kumamoto.component';
import { HiroshimaComponent } from './hiroshima/hiroshima.component';
import { TulsaComponent } from './tulsa/tulsa.component';
import { KrakowComponent } from './krakow/krakow.component';
import { PagenotfoundComponent } from './pagenotfound/pagenotfound.component';

@NgModule({
  declarations: [
    AppComponent,
    TokyoComponent,
    OkinawaComponent,
    KumamotoComponent,
    HiroshimaComponent,
    TulsaComponent,
    KrakowComponent,
    PagenotfoundComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [HttpService],
  bootstrap: [AppComponent]
})
export class AppModule { }
