import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';
import { NgModule } from '@angular/core';

import { BoringtoeRoutingModule } from './boringtoe-routing.module';

import { BoringtoeComponent } from './boringtoe.component';



@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    BoringtoeRoutingModule
  ],
  declarations: [BoringtoeComponent]
})
export class BoringtoeModule {}
