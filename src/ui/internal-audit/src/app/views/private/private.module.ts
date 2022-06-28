import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PrivateRoutingModule } from './private-routing.module';
import {DashboardComponent} from './dashboard/dashboard.component';
import { DataTablesModule } from "angular-datatables";
import { ButtonModule, CardModule, FormModule,MultiSelectModule  } from '@coreui/angular-pro';
import { UserlistComponent } from './userlist/userlist.component';
@NgModule({
  declarations: [
    DashboardComponent,
    UserlistComponent
  ],
  imports: [
    CommonModule,
    PrivateRoutingModule,
    DataTablesModule,
    ButtonModule,
    CardModule,
    FormModule,
    MultiSelectModule 
  ]
})
export class PrivateModule { }
