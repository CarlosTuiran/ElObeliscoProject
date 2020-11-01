import { TestBed } from '@angular/core/testing';

import { TotalLiquidacionService } from './total-liquidacion.service';

describe('TotalLiquidacionService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TotalLiquidacionService = TestBed.get(TotalLiquidacionService);
    expect(service).toBeTruthy();
  });
});
