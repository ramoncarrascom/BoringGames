import { Component, OnInit } from '@angular/core';
import { AlertController } from '@ionic/angular';
import { PlayerModel, PlayerDataModel } from '../shared/models/index';
import { BoringtoeService } from './services/boringtoe.service';
import { BoringToeNewGameRequestModel, Coordinate, BoringToeMovementRequestModel } from './models';

@Component({
  selector: 'app-boringtoe',
  templateUrl: './boringtoe.component.html',
  styleUrls: ['./boringtoe.component.scss'],
})
export class BoringtoeComponent implements OnInit {

  public players: PlayerDataModel[];
  public gameId: number;
  public currentPlayer: number;
  public gridData: string;

  constructor(private alert: AlertController, private service: BoringtoeService) {
    console.log('BoringToeComponent.Ctor');
    this.players = new Array<PlayerDataModel>();
  }

  /**
   * OnInit implementation
   */
  async ngOnInit() {
    console.log('BoringToeComponent.OnInit');
    this.gameId = 0;
    await this.initPlayers();
    console.log('ngOnInit end');
  }

  /**
   * Start buttn click handler
   */
  public startOnClick() {
    if (this.players.length === 2) {

      const playerAId: number = this.players[0].player.id;
      const playerBId: number = this.players[1].player.id;
      const newGameReq: BoringToeNewGameRequestModel = new BoringToeNewGameRequestModel(playerAId, playerBId);
      this.service.newGame(newGameReq).subscribe(
        resp => { this.gameId = resp;
                  this.currentPlayer = 0;
                  this.gridData = '';
                  console.log('New game Id', resp);
                }
      );

    } else {

      this.initPlayers();

    }
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
    this.service.newPlayer(playerName)
      .subscribe(player => {
        console.log(playerReference, player);
        this.players.push(
          new PlayerDataModel(playerReference, new PlayerModel(player, '', playerName, 0, false))
        );
      });
  }

  /**
   * Grid's cell click handler
   * @param $event Coordinates
   */
  public cellOnClick($event: Coordinate) {
    console.log('Coordinate on boringtoe', $event);
    const req: BoringToeMovementRequestModel =
      new BoringToeMovementRequestModel(this.players[this.currentPlayer].player.id, $event.x, $event.y);
    this.service.moveGame(this.gameId, req).subscribe(
      resp => this.gridData = resp.grid
    );
  }
}
