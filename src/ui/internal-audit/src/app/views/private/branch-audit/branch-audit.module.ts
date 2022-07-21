import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BranchAuditRoutingModule } from './branch-audit-routing.module';
import { TopicHeadComponent } from './topic-head/topic-head.component';
import { AccordionModule, ButtonModule, CardModule, FormModule, GridModule, ModalModule, MultiSelectModule, NavModule, TabsModule } from '@coreui/angular-pro';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DataTablesModule } from 'angular-datatables';
import { HttpClientModule } from '@angular/common/http';
import { CdkAccordionModule } from '@angular/cdk/accordion';
import { SecurityRoutingModule } from '../security/security-routing.module';
import { RiskCriteriaComponent } from './risk-criteria/risk-criteria.component';
import { IconModule } from '@coreui/icons-angular';


@NgModule({
  declarations: [
    TopicHeadComponent,
    RiskCriteriaComponent
  ],
  imports: [
    CommonModule,
    BranchAuditRoutingModule,
    GridModule,
    CardModule,
    FormModule,
    MultiSelectModule,
    ModalModule,
    ButtonModule,
    ReactiveFormsModule,
    DataTablesModule,
    FormsModule,
    TabsModule,
    NavModule,
    HttpClientModule,
    AccordionModule,
    CdkAccordionModule,
    IconModule,
 
    
  ]  
})
export class BranchAuditModule { }
