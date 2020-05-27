import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { CellComponent } from './cell.component';
import { SimpleChange } from '@angular/core';
import { element } from 'protractor';

describe('CellComponent', () => {
  let component: CellComponent;
  let fixture: ComponentFixture<CellComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CellComponent ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(CellComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  describe('ngOnChanges must set Cells value', () => {

    it('if input is A, then Cell must be X', () => {

      component.ngOnChanges({
        data: new SimpleChange(null, 'A', false)
      });
      fixture.detectChanges();

      const myDiv = fixture.debugElement.nativeElement.querySelector('#cell-data');
      expect(myDiv.innerHTML).toBe(' X ');
    });

    it('if input is B, then Cell must be Y', () => {

      component.ngOnChanges({
        data: new SimpleChange(null, 'B', false)
      });
      fixture.detectChanges();

      const myDiv = fixture.debugElement.nativeElement.querySelector('#cell-data');
      expect(myDiv.innerHTML).toBe(' O ');
    });

    it('if input is <space>, then Cell must be <space>', () => {

      component.ngOnChanges({
        data: new SimpleChange(null, ' ', false)
      });
      fixture.detectChanges();

      const myDiv = fixture.debugElement.nativeElement.querySelector('#cell-data');
      expect(myDiv.innerHTML).toBe('   ');
    });

  });
});
