import { TestBed } from '@angular/core/testing';

import { LibroContableService } from './libro-contable.service';

describe('LibroContableService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LibroContableService = TestBed.get(LibroContableService);
    expect(service).toBeTruthy();
  });
});
