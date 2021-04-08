import { TestBed } from '@angular/core/testing';

import { BirthdayAlertService } from './birthday-alert.service';

describe('BirthdayAlertService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BirthdayAlertService = TestBed.get(BirthdayAlertService);
    expect(service).toBeTruthy();
  });
});
