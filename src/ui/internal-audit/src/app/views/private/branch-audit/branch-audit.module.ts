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
import { RiskAssessmentComponent } from './risk-assessment/risk-assessment.component';
import { AuditFrequencyComponent } from './audit-frequency/audit-frequency.component';
import { RiskAssessmentViewComponent } from './risk-assessment-view/risk-assessment-view.component';
import { OverdueTabComponentComponent } from './risk-assessment-view/overdue-tab/overdue-tab-component';
import { StaffTurnoverComponent } from './risk-assessment-view/staff-turnover/staff-turnover.component';
import { AuditComponent } from './audit/audit.component';
import { AuditScheduleComponent } from './audit-schedule/audit-schedule.component';
import { AverageTabComponent } from './risk-assessment-view/average-tab/average-tab.component';
import { CollectionTabComponent } from './risk-assessment-view/collection-tab/collection-tab.component';
import { IssueComponent } from './issue/issue.component';
import { WorkpaperComponent } from './workpaper/workpaper.component';


@NgModule({
  declarations: [
    TopicHeadComponent,
    RiskCriteriaComponent,
    RiskAssessmentComponent,
    AuditFrequencyComponent,
    RiskAssessmentViewComponent,
    OverdueTabComponentComponent,
    StaffTurnoverComponent,
    AuditFrequencyComponent,

    AuditComponent,
      AverageTabComponent,
      CollectionTabComponent,
    AuditComponent,
      AuditScheduleComponent,
    AuditScheduleComponent,
    IssueComponent,
    WorkpaperComponent
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
