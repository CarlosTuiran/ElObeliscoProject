import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TopEmpleadosPieChartComponent } from './top-empleados-pie-chart.component';

describe('TopEmpleadosPieChartComponent', () => {
  let component: TopEmpleadosPieChartComponent;
  let fixture: ComponentFixture<TopEmpleadosPieChartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TopEmpleadosPieChartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TopEmpleadosPieChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
