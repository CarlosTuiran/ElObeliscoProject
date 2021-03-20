import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TopClientesPieChartComponent } from './top-clientes-pie-chart.component';

describe('TopClientesPieChartComponent', () => {
  let component: TopClientesPieChartComponent;
  let fixture: ComponentFixture<TopClientesPieChartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TopClientesPieChartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TopClientesPieChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
