import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ConfigurationRoutingModule } from './configuration-routing.module';
import { CountryComponent } from './country/country.component';
import { HttpClientModule } from '@angular/common/http';
import { DataTablesModule } from "angular-datatables";
import { ButtonModule, FormModule, ModalModule } from '@coreui/angular-pro';
import { ReactiveFormsModule } from '@angular/forms';
import { RiskProfileComponent } from './riskProfile/risk-profile.component';
import { EmailConfigComponent } from './emailConfig/emailConfig.component';
import { IconModule } from '@coreui/icons-angular';


@NgModule({
  declarations: [
    CountryComponent,
    RiskProfileComponent,
    EmailConfigComponent
  ],
  imports: [
    CommonModule,
    ConfigurationRoutingModule,
    HttpClientModule,
    DataTablesModule,
    ModalModule,
    ButtonModule,
    FormModule,
    ReactiveFormsModule,
    IconModule,
    
  ]
})
export class ConfigurationModule { }
