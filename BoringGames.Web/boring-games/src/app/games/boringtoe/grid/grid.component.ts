import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'boringtoe-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss'],
})
export class GridComponent implements OnInit {

  private gridArray: string[][];

  /**
   * Constructor
   */
  constructor() {
    this.updateGrid('AB BA AB ');
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

  private cellOnClick(xCoord: number, yCoord: number): void {
    console.log(xCoord, yCoord);
  }
}
