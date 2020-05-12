import { Component, OnInit } from '@angular/core';
import { AlertController } from '@ionic/angular';
import { PlayerModel, PlayerDataModel } from '../shared/models/index';
import { BoringtoeService } from './services/boringtoe.service';

@Component({
  selector: 'app-boringtoe',
  templateUrl: './boringtoe.component.html',
  styleUrls: ['./boringtoe.component.scss'],
})
export class BoringtoeComponent implements OnInit {

  public players: PlayerDataModel[];

  constructor(private alert: AlertController, private service: BoringtoeService) {
    console.log('BoringToeComponent.Ctor');
    this.players = new Array<PlayerDataModel>();
  }

  ngOnInit() {
    console.log('BoringToeComponent.OnInit');
    this.getPlayersName();
  }

  private async getPlayersName() {
    const alert = await this.alert.create({
      header: 'Player name',
      inputs: [
        {
          name: 'playerA',
          type: 'text',
          placeholder: 'Player A Name'
        },
        {
          name: 'playerB',
          type: 'text',
          placeholder: 'Player B Name'
        }
      ],
      buttons: [
       {
          text: 'Begin',
          handler: (data) => {
            this.players.push(new PlayerDataModel('Player 1', this.service.getPlayer(data.playerA)));
            this.players.push(new PlayerDataModel('Player 2', this.service.getPlayer(data.playerB)));
          }
        }
      ]
    });

    await alert.present();
  }

}
