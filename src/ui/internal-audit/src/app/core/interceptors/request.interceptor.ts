import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoginUserInterface } from '../interfaces/login-user.interface';

// @Injectable({providedIn: 'root'})
export class RequestInterceptor implements HttpInterceptor {

  constructor() {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    var localStorageAuthenticatedUser = localStorage.getItem('authenticatedUser');
    if(localStorageAuthenticatedUser != null){
      var user = JSON.parse(localStorageAuthenticatedUser) as LoginUserInterface;
      if(user?.success == true){
        return next.handle(request.clone({
          headers: request.headers.append('Authorization','Bearer '+ user.token)
        }));
      }
    }
    return next.handle(request);
  }
}
