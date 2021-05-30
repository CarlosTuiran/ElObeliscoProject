import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TableParametrosComponent } from './table-parametros.component';

describe('TableParametrosComponent', () => {
  let component: TableParametrosComponent;
  let fixture: ComponentFixture<TableParametrosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TableParametrosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TableParametrosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
