import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { GamesRoutingModule } from './games-routing.module';

import { GamesComponent } from './games.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    GamesRoutingModule
  ],
  declarations: [GamesComponent]
})
export class GamesModule {}
