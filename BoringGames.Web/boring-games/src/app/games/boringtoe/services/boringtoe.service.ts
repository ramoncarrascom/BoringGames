import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { PlayerModel, NewPlayerRequestModel } from '../../shared/models';
import { HttpClient } from '@angular/common/http';
import { BoringToeNewGameRequestModel } from '../models/index';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BoringtoeService {

  private GAME_URL: string = environment.baseUrl + '/api/v1/BoringToe';
  private PLAYER_URL: string = environment.baseUrl + '/api/v1/Player';

  /**
   * Ctor
   */
  constructor(private httpClient: HttpClient) {
  }

  /**
   * Creates a new Player in backend
   * @param name Player's name
   */
  public getPlayer(name: string): Observable<number> {
    let req: NewPlayerRequestModel;
    req = new NewPlayerRequestModel(name);
    return this.httpClient.post<number>(this.PLAYER_URL, req);
  }

  /**
   * Creates a new game in backend
   * @param data Player's ids
   */
  public newGame(data: BoringToeNewGameRequestModel): Observable<number> {
    return this.httpClient.post<number>(this.GAME_URL, data);
  }
}
