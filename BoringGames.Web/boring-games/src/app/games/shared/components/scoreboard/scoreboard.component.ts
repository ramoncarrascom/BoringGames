import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { PlayerDisplayComponent } from '../index';
import { PlayerModel, PlayerDataModel } from '../../models/index';

@Component({
  selector: 'shared-scoreboard',
  templateUrl: './scoreboard.component.html',
  styleUrls: ['./scoreboard.component.scss'],
})
export class ScoreboardComponent implements OnInit, OnChanges {

  @Input() Players: PlayerDataModel[];

  public players: PlayerDataModel[];

  constructor() { 
    this.players = new Array<PlayerDataModel>();
  }

  ngOnChanges(changes: SimpleChanges): void {
    console.log('Scoreboard changes', changes);
    this.checkPlayersArrayChange(changes);
  }

  ngOnInit() {}

  private checkPlayersArrayChange(changes: SimpleChanges) {
    if (changes && changes.Players && changes.Players.currentValue) {
      this.players = changes.Players.currentValue;
    }
  }

}
