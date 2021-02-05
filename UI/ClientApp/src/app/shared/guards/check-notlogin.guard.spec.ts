import { TestBed, async, inject } from '@angular/core/testing';

import { CheckNotloginGuard } from './check-notlogin.guard';

describe('CheckNotloginGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CheckNotloginGuard]
    });
  });

  it('should ...', inject([CheckNotloginGuard], (guard: CheckNotloginGuard) => {
    expect(guard).toBeTruthy();
  }));
});
