import { TestBed } from '@angular/core/testing';

import { FormatoVentaService } from './formato-venta.service';

describe('FormatoVentaService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: FormatoVentaService = TestBed.get(FormatoVentaService);
    expect(service).toBeTruthy();
  });
});
