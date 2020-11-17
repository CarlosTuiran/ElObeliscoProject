import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TablePruebasComponent } from './table-pruebas.component';

describe('TablePruebasComponent', () => {
  let component: TablePruebasComponent;
  let fixture: ComponentFixture<TablePruebasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TablePruebasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TablePruebasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
