import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PromedioVentasComponent } from './promedio-ventas.component';

describe('PromedioVentasComponent', () => {
  let component: PromedioVentasComponent;
  let fixture: ComponentFixture<PromedioVentasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PromedioVentasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PromedioVentasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
