import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RiskAssessmentComponent } from './risk-assessment/risk-assessment.component';
import { RiskCriteriaComponent } from './risk-criteria/risk-criteria.component';
import { TopicHeadComponent } from './topic-head/topic-head.component';
import { AuditComponent } from './audit/audit.component';

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
    path:'audit',
    component: AuditComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BranchAuditRoutingModule { }
