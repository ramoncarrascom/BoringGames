import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';
import { NgModule } from '@angular/core';

import { BoringtoeRoutingModule } from './boringtoe-routing.module';

import { BoringtoeComponent } from './boringtoe.component';
import { GridComponent } from './grid/grid.component';
import { CellComponent } from './cell/cell.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    BoringtoeRoutingModule,
    SharedModule
  ],
  declarations: [
    BoringtoeComponent,
    GridComponent,
    CellComponent,
  ]
})
export class BoringtoeModule {}
