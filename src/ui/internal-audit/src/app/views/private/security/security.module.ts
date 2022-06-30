import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SecurityRoutingModule } from './security-routing.module';
import { UserRegistrationComponent } from './user-registration/user-registration.component';
//import { ButtonModule, CardModule, FormModule, GridModule} from '@coreui/angular-pro';
import { DesignationComponent } from './designation/designation.component';
import { DataTablesModule } from 'angular-datatables';
import { UserlistComponent } from './userlist/userlist.component';
import { ButtonModule, CardModule, FormModule, GridModule,MultiSelectModule,ModalModule} from '@coreui/angular-pro';
import { ReactiveFormsModule,FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    UserRegistrationComponent,
    DesignationComponent,
    UserlistComponent
  ],
  imports: [
    CommonModule,
    SecurityRoutingModule,
    GridModule,
    CardModule,
    FormModule,
    MultiSelectModule,    
    ModalModule,
    ButtonModule,
    ReactiveFormsModule,
    DataTablesModule,
    FormsModule
   
  ]
})
export class SecurityModule { }
