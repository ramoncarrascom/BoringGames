export interface IPlayerModel {
    id: number;
    guidId: string;
    name: string;
    points: number;
    winner: boolean;
}

export class PlayerModel implements IPlayerModel {

    name: string;
    id: number;
    guidId: string;
    points: number;
    winner: boolean;

    constructor(id: number, guidId: string, name: string, points: number, winner: boolean) {
        this.id = id;
        this.guidId = guidId;
        this.name = name;
        this.points = points;
        this.winner = winner;
    }

}
