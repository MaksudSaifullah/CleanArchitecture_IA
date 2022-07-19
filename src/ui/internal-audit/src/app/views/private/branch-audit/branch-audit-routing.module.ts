import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TopicHeadComponent } from './topic-head/topic-head.component';

const routes: Routes = [
  {
    path:'topichead',
    component:TopicHeadComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BranchAuditRoutingModule { }
