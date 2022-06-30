import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SecurityRoutingModule } from './security-routing.module';
import { UserRegistrationComponent } from './user-registration/user-registration.component';
import { UserlistComponent } from './userlist/userlist.component';
import { ButtonModule, CardModule, FormModule, GridModule,MultiSelectModule} from '@coreui/angular-pro';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DataTablesModule } from 'angular-datatables';

@NgModule({
  declarations: [
    UserRegistrationComponent,
    UserlistComponent
  ],
  imports: [
    CommonModule,
    SecurityRoutingModule,
    GridModule,
    CardModule,
    FormModule,
    MultiSelectModule,
    ReactiveFormsModule,
    FormsModule,
    DataTablesModule
   
  ]
})
export class SecurityModule { }
