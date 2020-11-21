import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableTercerosComponent } from './table-terceros.component';

describe('TableTercerosComponent', () => {
  let component: TableTercerosComponent;
  let fixture: ComponentFixture<TableTercerosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableTercerosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableTercerosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
