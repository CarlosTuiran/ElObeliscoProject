import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableBodegasComponent } from './table-bodegas.component';

describe('TableBodegasComponent', () => {
  let component: TableBodegasComponent;
  let fixture: ComponentFixture<TableBodegasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableBodegasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableBodegasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
