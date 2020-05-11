import { Component, OnInit } from '@angular/core';
import { AlertController } from '@ionic/angular';
import { PlayerModel } from '../shared/models';
import { BoringtoeService } from './services/boringtoe.service';

@Component({
  selector: 'app-boringtoe',
  templateUrl: './boringtoe.component.html',
  styleUrls: ['./boringtoe.component.scss'],
})
export class BoringtoeComponent implements OnInit {

  public playerA: PlayerModel;
  public playerB: PlayerModel;

  constructor(private alert: AlertController, private service: BoringtoeService) {
    console.log('BoringToeComponent.Ctor');
  }

  ngOnInit() {
    console.log('BoringToeComponent.OnInit');
    this.playerA = this.service.getPlayer('Player A');
    this.playerB = this.service.getPlayer('Player B');
  }

  private async getPlayerName() {
    const alert = await this.alert.create({
      header: 'Player name',
      inputs: [
        {
          name: 'playerName',
          type: 'text',
          placeholder: 'Player Name'
        }
      ],
      buttons: [
       {
          text: 'Begin',
          handler: (data) => {
            console.log('Begin', data);
          }
        }
      ]
    });

    await alert.present();
  }

}
