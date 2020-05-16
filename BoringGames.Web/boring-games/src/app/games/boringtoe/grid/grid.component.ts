import { Component, OnInit, Output, EventEmitter, Input, OnChanges, SimpleChanges } from '@angular/core';
import { Coordinate } from '../models/coordinate.model';

@Component({
  selector: 'boringtoe-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss'],
})
export class GridComponent implements OnInit, OnChanges {

  @Input() GridData: string;
  @Output() ClickedCell: EventEmitter<Coordinate> = new EventEmitter<Coordinate>();

  public gridArray: string[][];

  /**
   * Constructor
   */
  constructor() {
    this.updateGrid('         ');
  }

  /**
   * OnChanges implementation
   */
  ngOnChanges(changes: SimpleChanges): void {
    if (changes) {
      if (changes && changes.GridData && changes.GridData.currentValue) {
        this.updateGrid(changes.GridData.currentValue);
      }
    }
  }

  /**
   * OnInit implementation
   */
  ngOnInit() {
  }

  /**
   * Updates the grid array based on input string
   * @param data Original string to calculate grid
   */
  private updateGrid(data: string): void {

    this.gridArray = [
      [data.charAt(0), data.charAt(3), data.charAt(6)],
      [data.charAt(1), data.charAt(4), data.charAt(7)],
      [data.charAt(2), data.charAt(5), data.charAt(8)]
    ];

  }

  /**
   * Cell click event handler
   * @param $event Coordinates
   */
  public cellOnClick($event: Coordinate): void {
    this.ClickedCell.emit($event);
  }
}
