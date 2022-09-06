import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RiskConfigurationsComponent } from './risk-configurations/risk-configurations.component';

const routes: Routes = [
  {
    path:'risk-configurations',
    component:RiskConfigurationsComponent

  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProcessAndControlAuditRoutingModule { }
