import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectPruebaComponent } from './select-prueba.component';

describe('SelectPruebaComponent', () => {
  let component: SelectPruebaComponent;
  let fixture: ComponentFixture<SelectPruebaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SelectPruebaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectPruebaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
