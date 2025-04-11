import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InsurancePricerComponent } from './insurance-pricer.component';

describe('InsurancePricerComponent', () => {
  let component: InsurancePricerComponent;
  let fixture: ComponentFixture<InsurancePricerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InsurancePricerComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InsurancePricerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
