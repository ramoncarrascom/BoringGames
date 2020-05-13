export interface IBoringToeNewGameRequestModel {
    playerAId: number;
    playerBId: number;
}

export class BoringToeNewGameRequestModel implements IBoringToeNewGameRequestModel {
    playerAId: number;
    playerBId: number;

    constructor(playerAId: number, playerBId: number) {
        this.playerAId = playerAId;
        this.playerBId = playerBId;
    }
}
