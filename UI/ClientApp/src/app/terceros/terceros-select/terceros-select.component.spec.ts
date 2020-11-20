import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TercerosSelectComponent } from './terceros-select.component';

describe('TercerosSelectComponent', () => {
  let component: TercerosSelectComponent;
  let fixture: ComponentFixture<TercerosSelectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TercerosSelectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TercerosSelectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
