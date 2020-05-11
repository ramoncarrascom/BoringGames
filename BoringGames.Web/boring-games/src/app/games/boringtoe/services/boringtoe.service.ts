import { Injectable } from '@angular/core';
import { PlayerModel } from '../../shared/models';

@Injectable({
  providedIn: 'root'
})
export class BoringtoeService {

  constructor() { }

  public getPlayer(name: string): PlayerModel {
    return new PlayerModel(name);
  }

}
