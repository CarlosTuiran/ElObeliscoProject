import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TopVentaProductosPieChartComponent } from './top-venta-productos-pie-chart.component';

describe('TopVentaProductosPieChartComponent', () => {
  let component: TopVentaProductosPieChartComponent;
  let fixture: ComponentFixture<TopVentaProductosPieChartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TopVentaProductosPieChartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TopVentaProductosPieChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
