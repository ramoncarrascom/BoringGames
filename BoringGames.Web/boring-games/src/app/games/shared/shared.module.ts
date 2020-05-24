import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { PlayerDisplayComponent, ScoreboardComponent } from './components/index';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
  ],
  declarations: [
    PlayerDisplayComponent,
    ScoreboardComponent
  ],
  exports: [
    PlayerDisplayComponent,
    ScoreboardComponent
  ]
})
export class SharedModule {}
