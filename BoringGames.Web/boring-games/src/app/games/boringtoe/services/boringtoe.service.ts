import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { PlayerModel } from '../../shared/models';
import { HttpClient } from '@angular/common/http';
import { BoringToeNewGameRequestModel } from '../models/index';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BoringtoeService {

  private NEW_GAME_URL: string = environment.baseUrl + '/api/v1/BoringToe';

  /**
   * Ctor
   */
  constructor(private httpClient: HttpClient) {
  }

  public getPlayer(name: string): PlayerModel {
    return new PlayerModel(1, '', name, 0, false);
  }

  /**
   * Creates a new game in backend
   * @param data Player's ids
   */
  public newGame(data: BoringToeNewGameRequestModel): Observable<number> {
    return this.httpClient.post<number>(this.NEW_GAME_URL, data);
  }
}
