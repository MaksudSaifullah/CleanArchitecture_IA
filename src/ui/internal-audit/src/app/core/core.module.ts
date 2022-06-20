import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from './auth/auth.service';
import { HttpService } from './services/http.service';
import { RoutingService } from './services/routing.service';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import {RequestInterceptor} from './interceptors/request.interceptor'


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    HttpClientModule
  ],
  providers:[
     AuthService,HttpService,RoutingService,{ provide: HTTP_INTERCEPTORS, useClass: RequestInterceptor, multi: true }
  ],

})
export class CoreModule { }
