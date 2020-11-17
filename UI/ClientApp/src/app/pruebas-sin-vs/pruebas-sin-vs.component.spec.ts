import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PruebasSinVSComponent } from './pruebas-sin-vs.component';

describe('PruebasSinVSComponent', () => {
  let component: PruebasSinVSComponent;
  let fixture: ComponentFixture<PruebasSinVSComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PruebasSinVSComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PruebasSinVSComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
