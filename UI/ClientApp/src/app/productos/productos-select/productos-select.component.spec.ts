import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductosSelectComponent } from './productos-select.component';

describe('ProductosSelectComponent', () => {
  let component: ProductosSelectComponent;
  let fixture: ComponentFixture<ProductosSelectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductosSelectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductosSelectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
