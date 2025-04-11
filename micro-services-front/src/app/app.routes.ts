import { Routes } from '@angular/router';
import { InsurancePricerComponent } from './insurance-pricer/insurance-pricer.component';

export const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: `pricer` },
  { path: 'pricer', component: InsurancePricerComponent },
  { path: '**', redirectTo: 'pricer' }
];
