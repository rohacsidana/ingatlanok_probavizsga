import { TestBed } from '@angular/core/testing';

import { IngatlanokService } from './ingatlanok.service';

describe('IngatlanokService', () => {
  let service: IngatlanokService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(IngatlanokService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
