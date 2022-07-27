import { HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map, Observable, of } from 'rxjs';
import { HttpService } from '../services/http.service';
import { LoginUserInterface} from '../interfaces/login-user.interface'
@Injectable({
  providedIn: 'root',
})
export class AuthService {

  constructor(private http:HttpService) { }

   authenticate(username:string,password:string,token:string){
    return this.http.post('authentication',{email:username,password:password,captchaToken:token});
  }
}
