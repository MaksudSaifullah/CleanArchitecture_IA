import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { UserlistComponent } from './userlist/userlist.component';

const routes: Routes = [{
  path:'dashboard',
  component:DashboardComponent,
},
{
  path: 'configuration',
  loadChildren: () =>
    import('./configuration/configuration.module').then((m) => m.ConfigurationModule)
},
{
  path: 'security',
  loadChildren: () =>
    import('./security/security.module').then((m) => m.SecurityModule)
},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PrivateRoutingModule { }
