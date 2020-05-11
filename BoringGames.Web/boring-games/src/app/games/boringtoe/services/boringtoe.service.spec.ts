import { TestBed } from '@angular/core/testing';

import { BoringtoeService } from './boringtoe.service';

describe('BoringtoeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BoringtoeService = TestBed.get(BoringtoeService);
    expect(service).toBeTruthy();
  });
});
