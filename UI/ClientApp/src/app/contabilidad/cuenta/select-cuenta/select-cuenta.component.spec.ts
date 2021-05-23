import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectCuentaComponent } from './select-cuenta.component';

describe('SelectCuentaComponent', () => {
  let component: SelectCuentaComponent;
  let fixture: ComponentFixture<SelectCuentaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SelectCuentaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectCuentaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
