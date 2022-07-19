import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BranchAuditRoutingModule } from './branch-audit-routing.module';
import { TopicHeadComponent } from './topic-head/topic-head.component';


@NgModule({
  declarations: [
    TopicHeadComponent
  ],
  imports: [
    CommonModule,
    BranchAuditRoutingModule
  ]
})
export class BranchAuditModule { }
