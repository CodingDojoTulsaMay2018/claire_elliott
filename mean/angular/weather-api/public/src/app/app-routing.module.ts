import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TokyoComponent } from './tokyo/tokyo.component';
import { OkinawaComponent } from './okinawa/okinawa.component';
import { KumamotoComponent } from './kumamoto/kumamoto.component';
import { HiroshimaComponent } from './hiroshima/hiroshima.component';
import { TulsaComponent } from './tulsa/tulsa.component';
import { KrakowComponent } from './krakow/krakow.component';
import { PagenotfoundComponent } from './pagenotfound/pagenotfound.component';

const routes: Routes = [
  { path: 'tokyo',component: TokyoComponent },
  { path: 'okinawa',component: OkinawaComponent },
  { path: 'kumamoto', component: KumamotoComponent },
  { path: 'tulsa', component: TulsaComponent },
  { path: 'hiroshima', component: HiroshimaComponent },
  { path: 'krakow', component: KrakowComponent },
  // the ** will catch anything that did not match any of the above routes
  { path: '**', component: PagenotfoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
