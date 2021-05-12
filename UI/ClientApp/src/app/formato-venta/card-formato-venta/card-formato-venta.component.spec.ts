import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CardFormatoVentaComponent } from './card-formato-venta.component';

describe('CardFormatoVentaComponent', () => {
  let component: CardFormatoVentaComponent;
  let fixture: ComponentFixture<CardFormatoVentaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CardFormatoVentaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CardFormatoVentaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
