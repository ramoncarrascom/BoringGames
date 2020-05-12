import { PlayerModel } from '.';

export interface IPlayerDataModel {
    playerReference: string;
    player: PlayerModel;
}

export class PlayerDataModel implements IPlayerDataModel {

    playerReference: string;
    player: PlayerModel;

    constructor(playerReference: string, player: PlayerModel) {
        this.playerReference = playerReference;
        this.player = player;
    }
    
}
