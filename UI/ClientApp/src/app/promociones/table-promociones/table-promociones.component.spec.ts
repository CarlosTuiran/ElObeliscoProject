import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TablePromocionesComponent } from './table-promociones.component';

describe('TablePromocionesComponent', () => {
  let component: TablePromocionesComponent;
  let fixture: ComponentFixture<TablePromocionesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TablePromocionesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TablePromocionesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
