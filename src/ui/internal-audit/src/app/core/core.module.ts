import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from './auth/auth.service';
import { HttpService } from './services/http.service';
import { RoutingService } from './services/routing.service';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import {RequestInterceptor} from './interceptors/request.interceptor'
import { ReactiveFormsModule } from '@angular/forms';
import { DataTablesModule } from 'angular-datatables';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    DataTablesModule
  ],
  providers:[
    { provide: HTTP_INTERCEPTORS, useClass: RequestInterceptor, multi: true },
    AuthService,HttpService,RoutingService,
  ],

})
export class CoreModule { }
