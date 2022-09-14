import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuditFrequencyComponent } from './audit-frequency/audit-frequency.component';
import { RiskAssessmentComponent } from './risk-assessment/risk-assessment.component';
import { RiskAssessmentViewComponent } from './risk-assessment-view/risk-assessment-view.component';
import { RiskCriteriaComponent } from './risk-criteria/risk-criteria.component';
import { TopicHeadComponent } from './topic-head/topic-head.component';
import { AuditComponent } from './audit/audit.component';
import { AuditScheduleComponent } from './audit-schedule/audit-schedule.component';
import { WorkpaperComponent } from './workpaper/workpaper.component';
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

const routes: Routes = [
  {
    path:'topichead',
    component:TopicHeadComponent

  },
  {
    path:'risk-criteria',
    component: RiskCriteriaComponent
  },
  {
    path:'risk-assessment',
    component: RiskAssessmentComponent
  },
  {
    path:'audit-frequency',
    component: AuditFrequencyComponent
  },
  {
    path:'audit',
    component: AuditComponent
  },
  {
    path:'audit-schedule',
    component: AuditScheduleComponent
  },
  {
    path:'risk-assessment-view/:id',
    component: RiskAssessmentViewComponent
  },
  {
    path:'audit-plan-view/:id',
    component: AuditPlanViewComponent
  },
  { path: 'userRegistration/:id', component: RiskAssessmentViewComponent },
  {
    path:'workpaper',
    component: WorkpaperComponent
  },
  {
    path:'workpaperCreate',
    component: WorkpaperCreateComponent
  },
  { path: 'workpaperCreate/:id', 
    component: WorkpaperCreateComponent 
  },
  {
    path:'audit-view',
    component: AuditViewComponent
  },
  { 
    path: 'audit-view/:id', 
    component: AuditViewComponent },
  { 
    path: 'audit/:id', 
    component: AuditComponent 
   },
   { 
    path: 'schedule-view', 
    component: ScheduleViewComponent 
   },
   { 
    path: 'schedule-view/:id/:auditParamId', 
    component: ScheduleViewComponent 
   },
   { 
    path: 'schedule-configuration', 
    component: ScheduleConfigurationComponent 
   },
   { 
    path: 'schedule-execution', 
    component: ScheduleExecutionComponent 
   },
  {
    path:'issue-list',
    component:IssueListComponent
  },
  {
    path:'new-issue',
    component:NewIssueComponent
  },
  {
    path:'new-issue/:id',
    component:NewIssueComponent
  },
  {
    path:'issue-view/:id',
    component:IssueViewComponent
  },
  {
    path:'closing-meeting-minutes',
    component: ClosingMeetingMinutesComponent
  },
  {
    path:'closing-meeting-minutes-create',
    component: ClosingMeetingMinutesCreateComponent
  },
  { path: 'closing-meeting-minutes-create/:id', 
  component: ClosingMeetingMinutesCreateComponent 
  },
  {
    path:'weight-score-config',
    component:WeightScoreConfigComponent
  },
  { 
    path: 'schedule-execution/:scheduleParamId/:auditParamId', 
    component: ScheduleExecutionComponent 
   },
   {
    path:'checklist',
    component: ChecklistComponent
   },
   {
    path:'checklist-create',
    component: ChecklistCreateComponent
   },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BranchAuditRoutingModule { }
