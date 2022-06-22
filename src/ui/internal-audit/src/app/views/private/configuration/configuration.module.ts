import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ConfigurationRoutingModule } from './configuration-routing.module';
import { CountryComponent } from './country/country.component';
import { HttpClientModule } from '@angular/common/http';
import { DataTablesModule } from "angular-datatables";
import { ButtonModule, FormModule } from '@coreui/angular-pro';
import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';

@NgModule({
  declarations: [
    CountryComponent
  ],
  imports: [
    CommonModule,
    ConfigurationRoutingModule,
    HttpClientModule,
    DataTablesModule,
    ButtonModule,
    FormModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
  ]
})
export class ConfigurationModule { }
