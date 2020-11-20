import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PromocionesSelectComponent } from './promociones-select.component';

describe('PromocionesSelectComponent', () => {
  let component: PromocionesSelectComponent;
  let fixture: ComponentFixture<PromocionesSelectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PromocionesSelectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PromocionesSelectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
