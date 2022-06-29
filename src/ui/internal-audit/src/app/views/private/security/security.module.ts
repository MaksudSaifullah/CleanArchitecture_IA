import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SecurityRoutingModule } from './security-routing.module';
import { UserRegistrationComponent } from './user-registration/user-registration.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ButtonModule, CardModule, FormModule, GridModule,ModalModule,MultiSelectModule} from '@coreui/angular-pro';
//import { ButtonModule, CardModule, FormModule, GridModule} from '@coreui/angular-pro';
import { DesignationComponent } from './designation/designation.component';
import { DataTablesModule } from 'angular-datatables';

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
    FormModule,
    MultiSelectModule,
    ReactiveFormsModule,
    ModalModule,
    ButtonModule,
    ReactiveFormsModule,
    DataTablesModule
   
  ]
})
export class SecurityModule { }
