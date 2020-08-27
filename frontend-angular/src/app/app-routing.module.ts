import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TanqueListComponent } from './tanque/tanque-list/tanque-list.component';

const appRoutes: Routes = [
  { path: "home", component: TanqueListComponent },

  { path: 'tanques', component: TanqueListComponent },

  { path: "", redirectTo: "/home", pathMatch: "full" }
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
