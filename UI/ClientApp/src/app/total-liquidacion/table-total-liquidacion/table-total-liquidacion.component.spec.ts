import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableTotalLiquidacionComponent } from './table-total-liquidacion.component';

describe('TableTotalLiquidacionComponent', () => {
  let component: TableTotalLiquidacionComponent;
  let fixture: ComponentFixture<TableTotalLiquidacionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableTotalLiquidacionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableTotalLiquidacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
