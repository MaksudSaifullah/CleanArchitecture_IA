import { HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpService } from '../services/http.service';
@Injectable({
  providedIn: 'root',
})
export class AuthService {

  constructor(private http:HttpService) { }

  authenticate(username:string,password:string):Observable<any>{
    return this.http.post('api/v1/authentication',{email:username,password:password});
  }
}
