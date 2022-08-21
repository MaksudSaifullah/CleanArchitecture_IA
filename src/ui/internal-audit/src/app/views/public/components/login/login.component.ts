import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { AuthService } from 'src/app/core/auth/auth.service';
import { LoginUserInterface } from 'src/app/core/interfaces/login-user.interface';
import { RoutingService } from 'src/app/core/services/routing.service';
import {AlertService} from "../../../../core/services/alert.service";
import {HttpService} from "../../../../core/services/http.service";
import {ProfileUpdateResponse} from "../../../../core/interfaces/security/user-registration.interface";
import {UserStore} from "../../../../shared/user.store";
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  token: string|undefined;

  constructor(private userStore : UserStore,private httpService : HttpService,private authService: AuthService,private routingService: RoutingService,private fb:FormBuilder,private alertService:AlertService) {
    this.loginForm = this.fb.group({
      username:['',[Validators.required,Validators.minLength(5)]],
      password:['',[Validators.required,Validators.minLength(5)]],
      captchaToken:[''],
    });
    this.token = undefined;
   }

  ngOnInit(): void {
    var authenticatedUser = localStorage.getItem('authenticatedUser');
    if(authenticatedUser != null){
      this.routingService.navigate('/dashboard');
    }
  }

  resolve(event:any): void {

    console.debug(`Token [${this.token}] generated`);
  }
  bindToken(token:string){
    this.loginForm.controls['captchaToken'].setValue(token);
  }
  async onSubmit() {
    if(this.loginForm.valid){
      var result = this.authService.authenticate(this.loginForm.value.username,this.loginForm.value.password, this.loginForm.value.captchaToken).subscribe(x=>{
        var data= x as LoginUserInterface;
        if(data.success)
        {
          localStorage.setItem('authenticatedUser',JSON.stringify(x));
          this.alertService.success('Login Successful');
          this.routingService.navigate('/dashboard');
          this.httpService.get<any>('UserRegistration/GetUserProfile').subscribe(x=>{
            let convertedResponse = x as ProfileUpdateResponse;
            this.userStore.update({
              fullName: convertedResponse.fullName,
              profileImage:convertedResponse.profileImageUrl
            });
          })
        }
        else{
          this.alertService.error(data.message);
        }
      });

    }

  }
}
