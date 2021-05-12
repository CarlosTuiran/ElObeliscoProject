import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormFormatoVentaComponent } from './form-formato-venta.component';

describe('FormFormatoVentaComponent', () => {
  let component: FormFormatoVentaComponent;
  let fixture: ComponentFixture<FormFormatoVentaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormFormatoVentaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormFormatoVentaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
