import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableInventarioComponent } from './table-inventario.component';

describe('TableInventarioComponent', () => {
  let component: TableInventarioComponent;
  let fixture: ComponentFixture<TableInventarioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableInventarioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableInventarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
