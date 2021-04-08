import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogoTipoTerceroComponent } from './dialogo-tipo-tercero.component';

describe('DialogoTipoTerceroComponent', () => {
  let component: DialogoTipoTerceroComponent;
  let fixture: ComponentFixture<DialogoTipoTerceroComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogoTipoTerceroComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogoTipoTerceroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
