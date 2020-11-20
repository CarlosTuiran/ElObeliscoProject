import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TipoMovimientoSelectComponent } from './tipo-movimiento-select.component';

describe('TipoMovimientoSelectComponent', () => {
  let component: TipoMovimientoSelectComponent;
  let fixture: ComponentFixture<TipoMovimientoSelectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TipoMovimientoSelectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TipoMovimientoSelectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
