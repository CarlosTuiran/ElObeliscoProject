import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableImpuestoComponent } from './table-impuesto.component';

describe('TableImpuestoComponent', () => {
  let component: TableImpuestoComponent;
  let fixture: ComponentFixture<TableImpuestoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableImpuestoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableImpuestoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
