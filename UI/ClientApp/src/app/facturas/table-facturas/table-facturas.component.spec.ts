import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableFacturasComponent } from './table-facturas.component';

describe('TableFacturasComponent', () => {
  let component: TableFacturasComponent;
  let fixture: ComponentFixture<TableFacturasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableFacturasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableFacturasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
