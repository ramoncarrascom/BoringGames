import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-boringtoe',
  templateUrl: './boringtoe.component.html',
  styleUrls: ['./boringtoe.component.scss'],
})
export class BoringtoeComponent implements OnInit {

  constructor() {
    console.log('BoringToeComponent.Ctor');
  }

  ngOnInit() {
    console.log('BoringToeComponent.OnInit');
  }

}
