import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { BoringtoeComponent } from './boringtoe.component';
import { GridComponent } from './grid/grid.component';
import { ScoreboardComponent, PlayerDisplayComponent } from '../shared/components';
import { CellComponent } from './cell/cell.component';
import { HttpClient, HttpHandler } from '@angular/common/http';

describe('BoringtoeComponent', () => {
  let component: BoringtoeComponent;
  let fixture: ComponentFixture<BoringtoeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BoringtoeComponent, GridComponent, CellComponent,
                    ScoreboardComponent, PlayerDisplayComponent ],
      providers: [HttpClient, HttpHandler],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(BoringtoeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
