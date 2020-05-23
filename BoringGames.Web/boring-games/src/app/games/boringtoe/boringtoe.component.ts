import { Component, OnInit } from '@angular/core';
import { AlertController, ToastController } from '@ionic/angular';
import { PlayerModel, PlayerDataModel } from '../shared/models/index';
import { BoringtoeService } from './services/boringtoe.service';
import { BoringToeNewGameRequestModel, Coordinate, BoringToeMovementRequestModel, BoringToeMoveResponseModel } from './models';

@Component({
  selector: 'app-boringtoe',
  templateUrl: './boringtoe.component.html',
  styleUrls: ['./boringtoe.component.scss'],
})
export class BoringtoeComponent implements OnInit {

  public players: PlayerDataModel[];
  public gameId: number;
  public currentPlayer: number;
  public winnerPlayer: number;
  public gameOver: boolean;
  public gridData: string;

  constructor(private alert: AlertController, private service: BoringtoeService,
              private toast: ToastController) {
    console.log('BoringToeComponent.Ctor');
    this.players = new Array<PlayerDataModel>();
  }

  /**
   * OnInit implementation
   */
  async ngOnInit() {
    console.log('BoringToeComponent.OnInit');
    this.gameId = 0;
    this.winnerPlayer = null;
    this.gameOver = false;
    this.currentPlayer = 0;
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
                  this.setCurrentPlayer(0);
                  this.winnerPlayer = null;
                  this.gameOver = false;
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
          new PlayerDataModel(playerReference, new PlayerModel(player, '', playerName, 0, false), false)
        );
      });
  }

  /**
   * Sets the current player
   */
  private setCurrentPlayer(arrayId: number) {
    this.currentPlayer = arrayId;
    this.players.forEach(
      (data: PlayerDataModel, id: number) => {
        if (id === arrayId) {
          data.current = true;
        } else {
          data.current = false;
        }
      }
    );
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
      resp => this.manageMovementResponse(resp)
    );
  }

  /**
   * Manages response's actions
   * @param response Service response
   */
  private async manageMovementResponse(response: BoringToeMoveResponseModel) {
    this.gridData = response.grid;
    if (response.repeat) {
      const toast = await this.toast.create({
        message: 'This cell is already in use - Please try again',
        color: 'warning',
        duration: 5000,
        position: 'top'
      });
      toast.present();
    }
    if (response.gameOver) {
      this.itsGameOver();
    }
    if (response.winner) {
      this.updateWinnerPlayer(response.winner);
    } else {
      if (!response.gameOver) {
        this.updateNextPlayer(response.player);
      }
    }

  }

  /**
   * Manages game's flow when there's a 'Next player'
   * @param responsePlayer Next player from service
   */
  private updateNextPlayer(responsePlayer: PlayerModel) {
    this.players.forEach(
      (item: PlayerDataModel, index: number) => {
        if (item.player.id === responsePlayer.id) {
          this.setCurrentPlayer(index);
        }
      }
    );
  }

  /**
   * Manages game's flow when there's a 'Winner player'
   * @param responsePlayer Winner player from service
   */
  private updateWinnerPlayer(responsePlayer: PlayerModel) {
    this.players.forEach(
      (item: PlayerDataModel, index: number) => {
        if (item.player.id === responsePlayer.id) {
          this.winnerPlayer = index;
        }
      }
    );
  }

  /**
   * Manages game's flow when it's game over
   */
  private itsGameOver() {
    this.gameOver = true;
  }
}
