import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableLibroContableComponent } from './table-libro-contable.component';

describe('TableLibroContableComponent', () => {
  let component: TableLibroContableComponent;
  let fixture: ComponentFixture<TableLibroContableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableLibroContableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableLibroContableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
