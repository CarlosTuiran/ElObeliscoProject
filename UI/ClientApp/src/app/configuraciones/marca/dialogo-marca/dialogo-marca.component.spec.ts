import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogoMarcaComponent } from './dialogo-marca.component';

describe('DialogoMarcaComponent', () => {
  let component: DialogoMarcaComponent;
  let fixture: ComponentFixture<DialogoMarcaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogoMarcaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogoMarcaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
