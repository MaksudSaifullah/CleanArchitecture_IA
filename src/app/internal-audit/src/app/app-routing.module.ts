import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './public/components/login/login.component';
import { NotFoundComponent } from './public/components/notfound/not-found/not-found.component';
import { RegisterComponent } from './public/components/register/register.component';

const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},

  //{path: 'dashboard', loadChildren: () => import('./private/private.module').then((m) => m.PrivateModule)},

  {path: '', redirectTo: '/login', pathMatch: 'full'},
  {path: '**', component: NotFoundComponent}
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes,{paramsInheritanceStrategy: 'always'})
    ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
