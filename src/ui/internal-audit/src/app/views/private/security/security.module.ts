import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SecurityRoutingModule } from './security-routing.module';
import { UserRegistrationComponent } from './user-registration/user-registration.component';
import { ButtonModule, CardModule, FormModule, GridModule} from '@coreui/angular-pro';
import { DesignationComponent } from './designation/designation.component';


@NgModule({
  declarations: [
    UserRegistrationComponent,
    DesignationComponent
  ],
  imports: [
    CommonModule,
    SecurityRoutingModule,
    GridModule,
    CardModule,
    FormModule
   
  ]
})
export class SecurityModule { }
