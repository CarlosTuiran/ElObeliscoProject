import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogoCrearFacturaComponent } from './dialogo-crear-factura.component';

describe('DialogoCrearFacturaComponent', () => {
  let component: DialogoCrearFacturaComponent;
  let fixture: ComponentFixture<DialogoCrearFacturaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogoCrearFacturaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogoCrearFacturaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
