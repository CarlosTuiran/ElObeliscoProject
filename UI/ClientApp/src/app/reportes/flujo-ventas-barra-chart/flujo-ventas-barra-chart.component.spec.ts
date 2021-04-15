import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FlujoVentasBarraChartComponent } from './flujo-ventas-barra-chart.component';

describe('FlujoVentasBarraChartComponent', () => {
  let component: FlujoVentasBarraChartComponent;
  let fixture: ComponentFixture<FlujoVentasBarraChartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FlujoVentasBarraChartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FlujoVentasBarraChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
