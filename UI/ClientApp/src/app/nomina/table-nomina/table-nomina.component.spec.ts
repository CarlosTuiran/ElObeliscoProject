import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableNominaComponent } from './table-nomina.component';

describe('TableNominaComponent', () => {
  let component: TableNominaComponent;
  let fixture: ComponentFixture<TableNominaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableNominaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableNominaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
