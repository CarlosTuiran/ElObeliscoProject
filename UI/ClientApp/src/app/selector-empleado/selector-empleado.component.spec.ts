import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectorEmpleadoComponent } from './selector-empleado.component';

describe('SelectorEmpleadoComponent', () => {
  let component: SelectorEmpleadoComponent;
  let fixture: ComponentFixture<SelectorEmpleadoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SelectorEmpleadoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectorEmpleadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
