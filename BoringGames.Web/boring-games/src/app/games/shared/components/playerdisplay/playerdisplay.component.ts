import { Component, OnInit, OnChanges, Input, SimpleChanges } from '@angular/core';

@Component({
  selector: 'shared-playerdisplay',
  templateUrl: './playerdisplay.component.html',
  styleUrls: ['./playerdisplay.component.scss'],
})

export class PlayerDisplayComponent implements OnInit, OnChanges {

  /**
   * Player's reference
   * @example 'Player A'
   */
  @Input() PlayerReference: string;

  /**
   * Player's name
   * @example 'Player A Name'
   */
  @Input() PlayerName: string;

  public playerReference: string;
  public playerName: string;

  /**
   * Constructor
   */
  constructor() {
    this.playerName = 'PlayerName';
    this.playerReference = 'Player A';
  }

  /**
   * OnChanges implementation
   * @param changes Changes
   */
  ngOnChanges(changes: SimpleChanges): void {
    console.log(changes);
    this.checkPlayerReference(changes);
    this.checkPlayerName(changes);
  }

  ngOnInit() {}

  /**
   * Checks if Player Reference has changed. If so, it changes the Player's reference
   * @param changes Object from ngOnChanges
   */
  private checkPlayerReference(changes: SimpleChanges) {
    if (changes && changes.PlayerReference && changes.PlayerReference.currentValue) {
      this.playerReference = changes.PlayerReference.currentValue;
    }
  }

  /**
   * Checks if Player Name has changed. If so, it changes the Player's name
   * @param changes Object from ngOnChanges
   */
  private checkPlayerName(changes: SimpleChanges) {
    if (changes && changes.PlayerName && changes.PlayerName.currentValue) {
      this.playerName = changes.PlayerName.currentValue;
    }
  }

}
