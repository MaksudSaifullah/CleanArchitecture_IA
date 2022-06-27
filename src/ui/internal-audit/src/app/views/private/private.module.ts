import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PrivateRoutingModule } from './private-routing.module';
import {DashboardComponent} from './dashboard/dashboard.component';
import { DataTablesModule } from "angular-datatables";
import { UserRegistrationComponent } from './security/user-registration/user-registration.component';
@NgModule({
  declarations: [
    DashboardComponent,
    UserRegistrationComponent
  ],
  imports: [
    CommonModule,
    PrivateRoutingModule,
    DataTablesModule
  ]
})
export class PrivateModule { }
