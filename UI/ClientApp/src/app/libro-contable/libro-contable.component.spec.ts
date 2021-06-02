import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LibroContableComponent } from './libro-contable.component';

describe('LibroContableComponent', () => {
  let component: LibroContableComponent;
  let fixture: ComponentFixture<LibroContableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LibroContableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LibroContableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
