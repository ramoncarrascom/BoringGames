import { PlayerModel } from '.';

export interface IPlayerDataModel {
    playerReference: string;
    player: PlayerModel;
    current: boolean;
}

export class PlayerDataModel implements IPlayerDataModel {

    playerReference: string;
    player: PlayerModel;
    current: boolean;

    constructor(playerReference: string, player: PlayerModel, current: boolean) {
        this.playerReference = playerReference;
        this.player = player;
        this.current = current;
    }
    
}
