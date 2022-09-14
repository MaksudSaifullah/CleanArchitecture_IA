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
import { WorkpaperComponent } from './workpaper/workpaper.component';
import { LoProductivityTabComponent } from './risk-assessment-view/lo-productivity-tab/lo-productivity-tab.component';
import { LoanDisbursementTabComponent } from './risk-assessment-view/loan-disbursement-tab/loan-disbursement-tab.component';
import { FraudTabComponent } from './risk-assessment-view/fraud-tab/fraud-tab.component';
import { WorkpaperCreateComponent } from './workpaper/workpaper-create/workpaper-create.component';
import { AuditViewComponent } from './audit-view/audit-view.component';
import { ScheduleViewComponent } from './schedule-view/schedule-view.component';
import { ScheduleConfigurationComponent } from './schedule-configuration/schedule-configuration.component';
import { ScheduleExecutionComponent } from './schedule-execution/schedule-execution.component';
import { NewIssueComponent } from './new-issue/new-issue.component';
import { IssueListComponent } from './issue-list/issue-list.component';
import { AuditPlanViewComponent } from './audit-plan-view/audit-plan-view.component';
import { ClosingMeetingMinutesComponent } from './closing-meeting-minutes/closing-meeting-minutes.component';
import { WeightScoreConfigComponent } from './weight-score-config/weight-score-config.component';
import { ClosingMeetingMinutesCreateComponent } from './closing-meeting-minutes/closing-meeting-minutes-create/closing-meeting-minutes-create.component';
import { IssueViewComponent } from './issue-view/issue-view.component';
import { ChecklistComponent } from './checklist/checklist.component';
import { ChecklistCreateComponent } from './checklist/checklist-create/checklist-create.component';


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
    WorkpaperComponent,
    LoProductivityTabComponent,
    LoanDisbursementTabComponent,
    FraudTabComponent,
    WorkpaperComponent,
    WorkpaperCreateComponent,
    AuditViewComponent,
    ScheduleViewComponent,
    ScheduleConfigurationComponent,
    ScheduleExecutionComponent,
    AuditScheduleComponent,
    AuditScheduleComponent,
    WorkpaperComponent,
    NewIssueComponent,
    IssueListComponent,
    AuditPlanViewComponent,
    IssueListComponent,
    ClosingMeetingMinutesComponent,
    IssueListComponent,
    WeightScoreConfigComponent,
    ClosingMeetingMinutesCreateComponent,
    IssueViewComponent,
    ChecklistComponent,
    ChecklistCreateComponent
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
