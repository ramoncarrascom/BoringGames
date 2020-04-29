import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { BoringtoeComponent } from './boringtoe.component';

const routes: Routes = [
  {
    path: '',
    component: BoringtoeComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class BoringtoeRoutingModule {}
