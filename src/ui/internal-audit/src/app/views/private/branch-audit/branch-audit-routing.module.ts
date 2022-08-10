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
  { path: 'userRegistration/:id', component: RiskAssessmentViewComponent },
  },
  {
    path:'workpaper',
    component: WorkpaperComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BranchAuditRoutingModule { }
