import { TestBed } from '@angular/core/testing';

import { TipoMovimientosService } from './tipo-movimientos.service';

describe('TipoMovimientosService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TipoMovimientosService = TestBed.get(TipoMovimientosService);
    expect(service).toBeTruthy();
  });
});
