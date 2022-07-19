import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BranchAuditRoutingModule } from './branch-audit-routing.module';
import { TopicHeadComponent } from './topic-head/topic-head.component';
import { RiskCriteriaComponent } from './risk-criteria/risk-criteria.component';


@NgModule({
  declarations: [
    TopicHeadComponent,
    RiskCriteriaComponent
  ],
  imports: [
    CommonModule,
    BranchAuditRoutingModule
  ]
})
export class BranchAuditModule { }
