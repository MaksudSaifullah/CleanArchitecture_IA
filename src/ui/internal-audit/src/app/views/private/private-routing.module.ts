import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { UploadDocumentComponent } from './upload-document/upload-document/upload-document.component';

const routes: Routes = [{
  path:'dashboard',
  component:DashboardComponent,
},
{
  path:'upload-document',
  component:UploadDocumentComponent,
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
{
  path: 'branch-audit',
  loadChildren: () =>
    import('./branch-audit/branch-audit.module').then((m) => m.BranchAuditModule)
},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PrivateRoutingModule { }
