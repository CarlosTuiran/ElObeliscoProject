import { TestBed } from '@angular/core/testing';

import { CantidadMinimaAlertService } from './cantidad-minima-alert.service';

describe('CantidadMinimaAlertService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CantidadMinimaAlertService = TestBed.get(CantidadMinimaAlertService);
    expect(service).toBeTruthy();
  });
});
