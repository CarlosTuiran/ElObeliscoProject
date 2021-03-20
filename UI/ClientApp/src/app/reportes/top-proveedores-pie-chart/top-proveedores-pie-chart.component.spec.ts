import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TopProveedoresPieChartComponent } from './top-proveedores-pie-chart.component';

describe('TopProveedoresPieChartComponent', () => {
  let component: TopProveedoresPieChartComponent;
  let fixture: ComponentFixture<TopProveedoresPieChartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TopProveedoresPieChartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TopProveedoresPieChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
