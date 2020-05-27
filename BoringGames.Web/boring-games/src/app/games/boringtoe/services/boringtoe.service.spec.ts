import { TestBed } from '@angular/core/testing';

import { BoringtoeService } from './boringtoe.service';
import { HttpClient, HttpHandler } from '@angular/common/http';

describe('BoringtoeService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [HttpClient, HttpHandler]
  }));

  it('should be created', () => {
    const service: BoringtoeService = TestBed.get(BoringtoeService);
    expect(service).toBeTruthy();
  });
});
