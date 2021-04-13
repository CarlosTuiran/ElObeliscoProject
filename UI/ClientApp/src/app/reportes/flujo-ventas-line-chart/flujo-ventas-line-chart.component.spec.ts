import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FlujoVentasLineChartComponent } from './flujo-ventas-line-chart.component';

describe('FlujoVentasLineChartComponent', () => {
  let component: FlujoVentasLineChartComponent;
  let fixture: ComponentFixture<FlujoVentasLineChartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FlujoVentasLineChartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FlujoVentasLineChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
