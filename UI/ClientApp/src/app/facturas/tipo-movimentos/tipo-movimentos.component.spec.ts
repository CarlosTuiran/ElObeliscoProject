import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TipoMovimentosComponent } from './tipo-movimentos.component';

describe('TipoMovimentosComponent', () => {
  let component: TipoMovimentosComponent;
  let fixture: ComponentFixture<TipoMovimentosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TipoMovimentosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TipoMovimentosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
