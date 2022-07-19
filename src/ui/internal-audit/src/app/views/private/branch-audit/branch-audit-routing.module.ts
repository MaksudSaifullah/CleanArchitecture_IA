import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RiskCriteriaComponent } from './risk-criteria/risk-criteria.component';
import { TopicHeadComponent } from './topic-head/topic-head.component';

const routes: Routes = [
  {
    path:'topichead',
    component:TopicHeadComponent

  },
  {
    path:'risk-criteria',
    component: RiskCriteriaComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BranchAuditRoutingModule { }
