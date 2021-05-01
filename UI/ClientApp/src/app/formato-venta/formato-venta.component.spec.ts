import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormatoVentaComponent } from './formato-venta.component';

describe('FormatoVentaComponent', () => {
  let component: FormatoVentaComponent;
  let fixture: ComponentFixture<FormatoVentaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormatoVentaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormatoVentaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
