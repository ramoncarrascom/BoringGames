import { Component, OnInit, OnChanges, Input, SimpleChanges } from '@angular/core';
import { PlayerDataModel, PlayerModel } from '../../models/index';

@Component({
  selector: 'shared-playerdisplay',
  templateUrl: './playerdisplay.component.html',
  styleUrls: ['./playerdisplay.component.scss'],
})

export class PlayerDisplayComponent implements OnInit, OnChanges {

  /**
   * Player's data
   * @example 'Player A Name'
   */
  @Input() Player: PlayerDataModel;

  public player: PlayerDataModel;

  /**
   * Constructor
   */
  constructor() {
    this.player = new PlayerDataModel('Player 1', new PlayerModel(1, '', 'Player A', 0, false), false);
  }

  /**
   * OnChanges implementation
   * @param changes Changes
   */
  ngOnChanges(changes: SimpleChanges): void {
    console.log(changes);
    this.checkPlayerChange(changes);
  }

  ngOnInit() {}

  /**
   * Checks if Player Name has changed. If so, it changes the Player's name
   * @param changes Object from ngOnChanges
   */
  private checkPlayerChange(changes: SimpleChanges) {
    if (changes && changes.Player && changes.Player.currentValue) {
      this.player = changes.Player.currentValue;
    }
  }

}
