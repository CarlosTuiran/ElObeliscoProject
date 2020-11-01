import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NominaFormComponent } from './nomina-form.component';

describe('NominaFormComponent', () => {
  let component: NominaFormComponent;
  let fixture: ComponentFixture<NominaFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NominaFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NominaFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
