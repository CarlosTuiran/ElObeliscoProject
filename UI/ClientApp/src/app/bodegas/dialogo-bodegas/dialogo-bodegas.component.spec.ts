import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogoBodegasComponent } from './dialogo-bodegas.component';

describe('DialogoBodegasComponent', () => {
  let component: DialogoBodegasComponent;
  let fixture: ComponentFixture<DialogoBodegasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogoBodegasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogoBodegasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
