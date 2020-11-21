import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableLiquidacionComponent } from './table-liquidacion.component';

describe('TableLiquidacionComponent', () => {
  let component: TableLiquidacionComponent;
  let fixture: ComponentFixture<TableLiquidacionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableLiquidacionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableLiquidacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
