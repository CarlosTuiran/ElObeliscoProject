import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InventarioPieChartComponent } from './inventario-pie-chart.component';

describe('InventarioPieChartComponent', () => {
  let component: InventarioPieChartComponent;
  let fixture: ComponentFixture<InventarioPieChartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InventarioPieChartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InventarioPieChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
