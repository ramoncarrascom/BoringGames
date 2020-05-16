export interface IBoringToeMovementRequestModel {
    playerId: number;
    xCoord: number;
    yCoord: number;
}

export class BoringToeMovementRequestModel implements IBoringToeMovementRequestModel {
    playerId: number;
    xCoord: number;
    yCoord: number;

    constructor(playerId: number, xCoord: number, yCoord: number) {
        this.playerId = playerId;
        this.xCoord = xCoord;
        this.yCoord = yCoord;
    }
}
