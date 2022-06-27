import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PrivateRoutingModule } from './private-routing.module';
import {DashboardComponent} from './dashboard/dashboard.component';
import { DataTablesModule } from "angular-datatables";
import { ButtonModule, CardModule, FormModule } from '@coreui/angular-pro';
@NgModule({
  declarations: [
    DashboardComponent,
  ],
  imports: [
    CommonModule,
    PrivateRoutingModule,
    DataTablesModule,
    ButtonModule,
    CardModule,
    FormModule
  
  
  ]
})
export class PrivateModule { }
