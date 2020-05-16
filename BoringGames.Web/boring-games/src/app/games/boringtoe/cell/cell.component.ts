import { Component, OnInit, Input, OnChanges, SimpleChanges, Output, EventEmitter } from '@angular/core';
import { core } from '@angular/compiler';
import { Coordinate } from '../models/coordinate.model';

@Component({
  selector: 'boringtoe-cell',
  templateUrl: './cell.component.html',
  styleUrls: ['./cell.component.scss'],
})
export class CellComponent implements OnInit, OnChanges {

  @Input() xCoord: number;
  @Input() yCoord: number;
  @Input() data: string;
  @Output() clickedCell: EventEmitter<Coordinate> = new EventEmitter<Coordinate>();

  public cellData: string;

  constructor() { }

  ngOnChanges(changes: SimpleChanges): void {
    console.log('CellComponent changes', changes);
    this.setCellData(changes.data.currentValue);
  }

  ngOnInit() {}

  private setCellData(data: string) {
    switch (data) {
      case 'A': this.cellData = 'X'; break;
      case 'B': this.cellData = 'O'; break;
      default: this.cellData = ' ';
    }
  }

  public onClick() {
    this.clickedCell.emit(new Coordinate(Number(this.xCoord), Number(this.yCoord)));
  }
}
