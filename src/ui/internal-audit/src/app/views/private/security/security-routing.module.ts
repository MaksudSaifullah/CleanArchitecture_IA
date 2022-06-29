import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccessPrivilegeComponent } from './access-privilege/access-privilege.component';
import { DesignationComponent } from './designation/designation.component';
import{UserRegistrationComponent} from './user-registration/user-registration.component'


const routes: Routes = [
  {
    path:'userRegistration',
    component:UserRegistrationComponent
  },
  {
    path:'designation',
    component:DesignationComponent
  },
  {
    path:'access-privilege',
    component:AccessPrivilegeComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SecurityRoutingModule { }
