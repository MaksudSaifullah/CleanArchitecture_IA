import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BranchAuditRoutingModule } from './branch-audit-routing.module';
import { TopicHeadComponent } from './topic-head/topic-head.component';
import { RiskCriteriaComponent } from './risk-criteria/risk-criteria.component';
import { RiskAssessmentComponent } from './risk-assessment/risk-assessment.component';


@NgModule({
  declarations: [
    TopicHeadComponent,
    RiskCriteriaComponent,
    RiskAssessmentComponent
  ],
  imports: [
    CommonModule,
    BranchAuditRoutingModule
  ]
})
export class BranchAuditModule { }
