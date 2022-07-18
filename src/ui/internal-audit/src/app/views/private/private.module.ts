import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PrivateRoutingModule } from './private-routing.module';
import {DashboardComponent} from './dashboard/dashboard.component';
import { DataTablesModule } from "angular-datatables";
import { ButtonModule, CardModule, FormModule,GridModule,MultiSelectModule,AccordionModule } from '@coreui/angular-pro';
import { FormsModule } from '@angular/forms';
import { IconModule } from '@coreui/icons-angular';
import { ChartjsModule } from '@coreui/angular-chartjs';
@NgModule({
  declarations: [
    DashboardComponent
  ],
  imports: [
    CommonModule,
    PrivateRoutingModule,
    DataTablesModule,
    ButtonModule,
    CardModule,
    FormModule,
    FormsModule,
    MultiSelectModule,
    GridModule,
    IconModule,
    ChartjsModule,
    AccordionModule
  ]
})
export class PrivateModule { }
