import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TotalOrdenesComponent } from './total-ordenes.component';

describe('TotalOrdenesComponent', () => {
  let component: TotalOrdenesComponent;
  let fixture: ComponentFixture<TotalOrdenesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TotalOrdenesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TotalOrdenesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
