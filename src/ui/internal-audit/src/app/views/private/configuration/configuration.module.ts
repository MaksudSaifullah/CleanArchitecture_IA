import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ConfigurationRoutingModule } from './configuration-routing.module';
import { CountryComponent } from './country/country.component';
import { HttpClientModule } from '@angular/common/http';
import { DataTablesModule } from "angular-datatables";
import { ButtonModule, FormModule, ModalModule } from '@coreui/angular-pro';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    CountryComponent
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
  ]
})
export class ConfigurationModule { }
