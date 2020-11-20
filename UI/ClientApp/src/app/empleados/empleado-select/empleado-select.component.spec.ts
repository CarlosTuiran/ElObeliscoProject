import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmpleadoSelectComponent } from './empleado-select.component';

describe('EmpleadoSelectComponent', () => {
  let component: EmpleadoSelectComponent;
  let fixture: ComponentFixture<EmpleadoSelectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmpleadoSelectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmpleadoSelectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
