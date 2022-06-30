import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DesignationComponent } from './designation/designation.component';
import{UserRegistrationComponent} from './user-registration/user-registration.component'
import { UserRoleComponent } from './user-role/user-role.component';


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
    path:'userrole',
    component: UserRoleComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SecurityRoutingModule { }
