export interface IPlayerModel {
    name: string;
}

export class PlayerModel implements IPlayerModel {

    name: string;

    constructor(name: string) {
        this.name = null;
    }

}
