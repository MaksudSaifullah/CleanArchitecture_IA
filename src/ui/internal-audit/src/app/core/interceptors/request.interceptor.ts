import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoginUserInterface } from '../interfaces/login-user.interface';

@Injectable()
export class RequestInterceptor implements HttpInterceptor {

  constructor() {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    var localStorageAuthenticatedUser = localStorage.getItem('authenticatedUser');
    if(localStorageAuthenticatedUser != null){
      var user = JSON.parse(localStorage.getItem('authenticatedUser') || '') as LoginUserInterface;
      if(user?.success == true){
        request.headers.append('Authorization','Bearer '+ user.token )
      }
    }
    return next.handle(request);
  }
}
