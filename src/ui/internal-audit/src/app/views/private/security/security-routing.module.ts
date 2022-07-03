import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { AccessPrivilegeComponent } from './access-privilege/access-privilege.component';
import { DesignationComponent } from './designation/designation.component';
import{UserRegistrationComponent} from './user-registration/user-registration.component'
import { UserRoleComponent } from './user-role/user-role.component';
import { UserlistComponent } from './userlist/userlist.component';


const routes: Routes = [
  {
    path:'userRegistration',component:UserRegistrationComponent
  },
  {
    path:'designation',
    component:DesignationComponent
  },
  {
    path:'changepassword',
    component:ChangePasswordComponent
  },
  { path: 'userRegistration/:id', component: UserRegistrationComponent },
  {
    path:'userlist',
    component:UserlistComponent
  },
  {
    path: 'designation',
    component: DesignationComponent
  },
  {
    path: 'access-privilege',
    component: AccessPrivilegeComponent
  },
  {
    path:'userrole',
    component: UserRoleComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SecurityRoutingModule { }
