import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PublicRoutingModule } from './public-routing.module';
import { PublicComponent } from './public.component';
import { AboutComponent } from './components/about/about.component';
import { NotFoundComponent } from './components/notfound/not-found/not-found.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { AkitaNgRouterStoreModule } from '@datorama/akita-ng-router-store';
import { AkitaNgDevtools } from '@datorama/akita-ngdevtools';
import { environment } from 'src/environments/environment';


@NgModule({
  declarations: [
    PublicComponent,
    AboutComponent,
    NotFoundComponent,
    LoginComponent,
    RegisterComponent,
  ],
  imports: [
    CommonModule,
    PublicRoutingModule,
    AkitaNgRouterStoreModule,
    environment.production ? [] : AkitaNgDevtools.forRoot()
    
  ]
})
export class PublicModule { }
