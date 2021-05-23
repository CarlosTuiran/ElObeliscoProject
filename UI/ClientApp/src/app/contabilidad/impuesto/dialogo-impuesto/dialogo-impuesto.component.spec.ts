import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogoImpuestoComponent } from './dialogo-impuesto.component';

describe('DialogoImpuestoComponent', () => {
  let component: DialogoImpuestoComponent;
  let fixture: ComponentFixture<DialogoImpuestoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogoImpuestoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogoImpuestoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
