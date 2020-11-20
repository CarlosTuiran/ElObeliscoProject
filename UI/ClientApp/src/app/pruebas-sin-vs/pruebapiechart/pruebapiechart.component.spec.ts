import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PruebapiechartComponent } from './pruebapiechart.component';

describe('PruebapiechartComponent', () => {
  let component: PruebapiechartComponent;
  let fixture: ComponentFixture<PruebapiechartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PruebapiechartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PruebapiechartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
