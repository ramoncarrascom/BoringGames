import { PlayerModel } from '../../shared/models';

export interface IBoringToeMoveResponseModel {
        player: PlayerModel;
        grid: string;
        winner: PlayerModel;
        gameOver: boolean;
        repeat: boolean;
}

export class BoringToeMoveResponseModel implements IBoringToeMoveResponseModel {
    player: PlayerModel;
    grid: string;
    winner: PlayerModel;
    gameOver: boolean;
    repeat: boolean;

    constructor() {
        this.player = null;
        this.grid = null;
        this.winner = null;
        this.gameOver = null;
        this.repeat = null;
    }

}
