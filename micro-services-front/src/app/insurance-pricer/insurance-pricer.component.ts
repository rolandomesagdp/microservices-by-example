import { Component } from '@angular/core';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Driver } from '../insurance/driver.interface';
import { HttpClient } from '@angular/common/http';
import { InsuranceOffer } from '../insurance/insurance-offer.interface';
import { tap } from 'rxjs';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-insurance-pricer',
  imports: [
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    ReactiveFormsModule,
    MatButtonModule
  ],
  templateUrl: './insurance-pricer.component.html',
  styleUrl: './insurance-pricer.component.scss'
})
export class InsurancePricerComponent {
  driverForm: FormGroup;

  constructor (private formBuilder: FormBuilder, private httpClient: HttpClient) {
    this.driverForm = this.formBuilder.group({
      driverId: ['', Validators.required],
      yearsOfExperience: [0, Validators.required],
      driverLicencePoints: [0, Validators.required]
    });
  }

  onSubmit(): void {
    const driver: Driver = this.driverForm.value;
    console.log(driver);
    const url: string = `${environment.insurancePricerBaseUrl}/InsurancePrice`;
    this.httpClient.post<InsuranceOffer>(url, driver).pipe(
      tap((offer: InsuranceOffer) => {
        console.log(offer);
      })
    ).subscribe();
  }
}
