import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { NewComponent } from './new/new.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ShowComponent } from './show/show.component';
import { SharksComponent } from './sharks/sharks.component';

const routes: Routes = [
  { path: 'new',component: NewComponent },
  { path: 'sharks',component: SharksComponent },
  { path: 'show/:id',component: ShowComponent },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
