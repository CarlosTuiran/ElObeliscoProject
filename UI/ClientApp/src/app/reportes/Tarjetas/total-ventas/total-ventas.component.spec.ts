import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TotalVentasComponent } from './total-ventas.component';

describe('TotalVentasComponent', () => {
  let component: TotalVentasComponent;
  let fixture: ComponentFixture<TotalVentasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TotalVentasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TotalVentasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
