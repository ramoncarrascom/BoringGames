import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-games',
  templateUrl: './games.component.html',
  styleUrls: ['./games.component.scss'],
})
export class GamesComponent implements OnInit {

  constructor() {
    console.log('Games ctor');
  }

  ngOnInit() {
    console.log('Games init');
  }

}
