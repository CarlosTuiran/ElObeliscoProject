import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CantidadMinimaAlertComponent } from './cantidad-minima-alert.component';

describe('CantidadMinimaAlertComponent', () => {
  let component: CantidadMinimaAlertComponent;
  let fixture: ComponentFixture<CantidadMinimaAlertComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CantidadMinimaAlertComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CantidadMinimaAlertComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
