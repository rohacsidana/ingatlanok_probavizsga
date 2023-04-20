import { TestBed } from '@angular/core/testing';

import { KategoriakService } from './kategoriak.service';

describe('KategoriakService', () => {
  let service: KategoriakService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(KategoriakService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
