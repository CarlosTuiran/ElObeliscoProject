import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableDetallesComponent } from './table-detalles.component';

describe('TableDetallesComponent', () => {
  let component: TableDetallesComponent;
  let fixture: ComponentFixture<TableDetallesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableDetallesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableDetallesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
