import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableFormatoVentaComponent } from './table-formato-venta.component';

describe('TableFormatoVentaComponent', () => {
  let component: TableFormatoVentaComponent;
  let fixture: ComponentFixture<TableFormatoVentaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableFormatoVentaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableFormatoVentaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
