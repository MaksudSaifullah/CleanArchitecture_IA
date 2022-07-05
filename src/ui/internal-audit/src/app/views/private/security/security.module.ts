import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SecurityRoutingModule } from './security-routing.module';
import { UserRegistrationComponent } from './user-registration/user-registration.component';
//import { ButtonModule, CardModule, FormModule, GridModule} from '@coreui/angular-pro';
import { DesignationComponent } from './designation/designation.component';
import { DataTablesModule } from 'angular-datatables';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { UserlistComponent } from './userlist/userlist.component';
import { ButtonModule, CardModule, FormModule, GridModule,MultiSelectModule,ModalModule, NavModule, TabsModule, AccordionModule} from '@coreui/angular-pro';
import { ReactiveFormsModule,FormsModule } from '@angular/forms';
import { AccessPrivilegeComponent } from './access-privilege/access-privilege.component';
import { UserRoleComponent } from './user-role/user-role.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RequestInterceptor } from 'src/app/core/interceptors/request.interceptor';
import {CdkAccordionModule} from '@angular/cdk/accordion';

@NgModule({
  declarations: [
    UserRegistrationComponent,
    DesignationComponent,
    ChangePasswordComponent,
    UserlistComponent,
    AccessPrivilegeComponent,
    UserRoleComponent,

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
    FormsModule,
    TabsModule,
    NavModule,
    HttpClientModule,
    AccordionModule,
    CdkAccordionModule
  ],
  providers:[
  ]
})
export class SecurityModule { }
