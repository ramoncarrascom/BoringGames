import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';
import { NgModule } from '@angular/core';

import { BoringtoeRoutingModule } from './boringtoe-routing.module';

import { BoringtoeComponent } from './boringtoe.component';
import { GridComponent } from './grid/grid.component';
import { CellComponent } from './cell/cell.component';



@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    BoringtoeRoutingModule
  ],
  declarations: [
    BoringtoeComponent,
    GridComponent,
    CellComponent
  ]
})
export class BoringtoeModule {}
