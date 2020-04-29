import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { BoringtoeComponent } from './boringtoe.component';

describe('BoringtoeComponent', () => {
  let component: BoringtoeComponent;
  let fixture: ComponentFixture<BoringtoeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BoringtoeComponent ],
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
