export interface INewPlayerRequestModel {
    name: string;
}

export class NewPlayerRequestModel implements INewPlayerRequestModel {
    name: string;
    
    constructor(name: string) {
        this.name = name;
    }
}