import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SecurityRoutingModule } from './security-routing.module';
import { UserRegistrationComponent } from './user-registration/user-registration.component';
import { ButtonModule, CardModule, FormModule, GridModule,MultiSelectModule} from '@coreui/angular-pro';


@NgModule({
  declarations: [
    UserRegistrationComponent
  ],
  imports: [
    CommonModule,
    SecurityRoutingModule,
    GridModule,
    CardModule,
    FormModule,
    MultiSelectModule
   
  ]
})
export class SecurityModule { }
