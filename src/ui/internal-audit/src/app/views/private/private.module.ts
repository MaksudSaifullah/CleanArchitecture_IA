import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PrivateRoutingModule } from './private-routing.module';
import {DashboardComponent} from './dashboard/dashboard.component';
import { DataTablesModule } from "angular-datatables";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {
  ButtonModule,
  CardModule,
  FormModule,
  GridModule,
  MultiSelectModule,
  AccordionModule,
  AvatarModule
} from '@coreui/angular-pro';
import { IconModule } from '@coreui/icons-angular';
import { ChartjsModule } from '@coreui/angular-chartjs';
import { UploadDocumentComponent } from './upload-document/upload-document/upload-document.component';
@NgModule({
  declarations: [
    DashboardComponent,
    UploadDocumentComponent
  ],
  imports: [
    CommonModule,
    PrivateRoutingModule,
    DataTablesModule,
    ButtonModule,
    CardModule,
    FormModule,
    FormsModule,
    ReactiveFormsModule,
    MultiSelectModule,
    GridModule,
    IconModule,
    ChartjsModule,
    AccordionModule,
    AvatarModule
  ]
})
export class PrivateModule { }
