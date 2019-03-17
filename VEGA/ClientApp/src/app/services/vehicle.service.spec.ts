import { TestBed, inject } from '@angular/core/testing';

import { VehicleService as MakeService } from "./vehicle.service";

describe('MakeService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MakeService]
    });
  });

  it('should be created', inject([MakeService], (service: MakeService) => {
    expect(service).toBeTruthy();
  }));
});
