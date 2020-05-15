import { Component, OnInit } from '@angular/core';
import { AlertController } from '@ionic/angular';
import { PlayerModel, PlayerDataModel } from '../shared/models/index';
import { BoringtoeService } from './services/boringtoe.service';
import { BoringToeNewGameRequestModel } from './models/boring-toe-new-game-request.model';

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

  /**
   * OnInit implementation
   */
  async ngOnInit() {
    console.log('BoringToeComponent.OnInit');
    await this.initPlayers();
    console.log('ngOnInit end');
  }

  /**
   * Shows popup to get player's names
   */
  private async initPlayers() {

    let resp: string[];
    resp = new Array<string>();

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
            this.initPlayer('Player A', data.playerA);
            this.initPlayer('Player B', data.playerB);
          }
        }
      ]
    });

    await alert.present();

  }

  /**
   * Inits a player and pushes data to players array
   * @param playerReference Player reference
   * @param playerName Player's name
   */
  private initPlayer(playerReference: string, playerName: string) {
    this.service.getPlayer(playerName)
      .subscribe(player => {
        console.log(playerReference, player);
        this.players.push(
          new PlayerDataModel(playerReference, new PlayerModel(player, '', playerName, 0, false))
        );
      });
  }

}
