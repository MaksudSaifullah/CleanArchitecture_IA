import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DesignationComponent } from './designation/designation.component';
import{UserRegistrationComponent} from './user-registration/user-registration.component'
import { UserlistComponent } from './userlist/userlist.component';


const routes: Routes = [
  {
    path:'userRegistration',component:UserRegistrationComponent
  },
  {
    path: 'userRegistration/:id', component: UserRegistrationComponent },
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
