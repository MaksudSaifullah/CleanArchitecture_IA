import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';

const routes: Routes = [{
  path:'dashboard',
  component:DashboardComponent,
},
{
  path: 'configuration',
  loadChildren: () =>
    import('./configuration/configuration.module').then((m) => m.ConfigurationModule)
},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PrivateRoutingModule { }
