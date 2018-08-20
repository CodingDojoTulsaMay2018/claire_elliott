import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NewComponent } from './new/new.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { HttpService } from './http.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ShowComponent } from './show/show.component';
import { SharksComponent } from './sharks/sharks.component';

@NgModule({
  declarations: [
    AppComponent,
    NewComponent,
    PageNotFoundComponent,
    ShowComponent,
    SharksComponent,
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
