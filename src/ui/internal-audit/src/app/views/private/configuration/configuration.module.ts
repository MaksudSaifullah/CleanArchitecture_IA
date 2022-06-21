import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ConfigurationRoutingModule } from './configuration-routing.module';
import { CountryComponent } from './country/country.component';
import { HttpClientModule } from '@angular/common/http';
import { DataTablesModule } from "angular-datatables";

@NgModule({
  declarations: [
    CountryComponent
  ],
  imports: [
    CommonModule,
    ConfigurationRoutingModule,
    HttpClientModule,
    DataTablesModule
  ]
})
export class ConfigurationModule { }
