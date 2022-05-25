import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route, RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { AboutComponent } from './components/about/about.component';
import { RegisterComponent } from './components/register/register.component';


const routes: Routes = [
  {

    path: '',
    data: {
      title: 'Public',
    },
    children:[
      {
        path: 'login',
        component: LoginComponent,
        data: 
          {
            title: 'login',
          },
      },
      {
        path: 'about',
        component: AboutComponent,
        data: 
          {
            title: 'About',
          },
      },
      {
        path: 'register',
        component: RegisterComponent,
        data: 
          {
            title: 'Register',
          },
      },
    ]
}];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    [RouterModule.forChild(routes)],
  ],
  exports: [RouterModule],

})
export class PublicRoutingModule { }
