import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from './auth/auth.service';
import { HttpService } from './services/http.service';
import { RoutingService } from './services/routing.service';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import {RequestInterceptor} from './interceptors/request.interceptor'
import { ReactiveFormsModule } from '@angular/forms';
import { DataTablesModule } from 'angular-datatables';
import { NgxUiLoaderModule } from 'ngx-ui-loader';
import {GlobalInterceptor} from './interceptors/global.interceptor'


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    DataTablesModule,
    NgxUiLoaderModule
  ],
  providers:[
     AuthService,HttpService,RoutingService,
     { provide: HTTP_INTERCEPTORS, useClass: RequestInterceptor, multi: true },
     { provide: HTTP_INTERCEPTORS, useClass: GlobalInterceptor, multi: true },
    AuthService,HttpService,RoutingService,
  ],

})
export class CoreModule { }
