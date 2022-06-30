import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { DesignationComponent } from './designation/designation.component';
import{UserRegistrationComponent} from './user-registration/user-registration.component'
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
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SecurityRoutingModule { }
