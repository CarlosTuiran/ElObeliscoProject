import { TestBed } from '@angular/core/testing';

import { PruebasSinVSService } from './pruebas-sin-vs.service';

describe('PruebasSinVSService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PruebasSinVSService = TestBed.get(PruebasSinVSService);
    expect(service).toBeTruthy();
  });
});
