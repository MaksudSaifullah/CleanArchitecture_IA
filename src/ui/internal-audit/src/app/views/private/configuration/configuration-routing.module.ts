import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CountryComponent } from './country/country.component';
import { RiskProfileComponent } from './riskProfile/risk-profile.component';

const routes: Routes = [
  {
    path:'country',
    component:CountryComponent
  },
  {
    path:'risk-profile',
    component:RiskProfileComponent
  }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ConfigurationRoutingModule { }
