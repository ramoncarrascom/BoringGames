import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

import { BoringtoeRoutingModule } from './boringtoe-routing.module';

import { BoringtoeComponent } from './boringtoe.component';
import { GridComponent } from './grid/grid.component';
import { CellComponent } from './cell/cell.component';
import { SharedModule } from '../shared/shared.module';
import { BoringtoeService } from './services/boringtoe.service';

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
  ],
  providers: [
    BoringtoeService
  ]
})
export class BoringtoeModule {}
