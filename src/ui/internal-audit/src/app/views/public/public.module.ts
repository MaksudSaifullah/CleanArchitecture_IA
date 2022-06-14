import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PublicRoutingModule } from './public-routing.module';
import { AboutComponent } from './components/about/about.component';
import { LoginComponent } from './components/login/login.component';
import { ButtonModule, CardModule, FormModule, GridModule } from '@coreui/angular-pro';
import { IconModule } from '@coreui/icons-angular';



@NgModule({
  declarations: [
    AboutComponent,
    LoginComponent
  ],
  imports: [
    CommonModule,
    PublicRoutingModule,
    CardModule,
    ButtonModule,
    GridModule,
    IconModule,
    FormModule
  ]
})
export class PublicModule { }
