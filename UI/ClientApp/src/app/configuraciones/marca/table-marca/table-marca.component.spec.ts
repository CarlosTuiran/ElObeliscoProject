import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableMarcaComponent } from './table-marca.component';

describe('TableMarcaComponent', () => {
  let component: TableMarcaComponent;
  let fixture: ComponentFixture<TableMarcaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableMarcaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableMarcaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
