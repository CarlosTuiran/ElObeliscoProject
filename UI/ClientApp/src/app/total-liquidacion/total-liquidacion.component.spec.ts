import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TotalLiquidacionComponent } from './total-liquidacion.component';

describe('TotalLiquidacionComponent', () => {
  let component: TotalLiquidacionComponent;
  let fixture: ComponentFixture<TotalLiquidacionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TotalLiquidacionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TotalLiquidacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
