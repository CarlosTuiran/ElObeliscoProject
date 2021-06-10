import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormLibroContableComponent } from './form-libro-contable.component';

describe('FormLibroContableComponent', () => {
  let component: FormLibroContableComponent;
  let fixture: ComponentFixture<FormLibroContableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormLibroContableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormLibroContableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
