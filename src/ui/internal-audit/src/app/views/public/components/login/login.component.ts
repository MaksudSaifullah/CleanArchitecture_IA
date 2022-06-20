import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { AuthService } from 'src/app/core/auth/auth.service';
import { LoginUserInterface } from 'src/app/core/interfaces/login-user.interface';
import { RoutingService } from 'src/app/core/services/routing.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  token: string|undefined;

  constructor(private authService: AuthService,private routingService: RoutingService,private fb:FormBuilder) {
    this.loginForm = this.fb.group({
      username:['',[Validators.required,Validators.minLength(5)]],
      password:['',[Validators.required,Validators.minLength(5)]],
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

  async onSubmit() {
    if(this.loginForm.valid){
      var result = this.authService.authenticate(this.loginForm.value.username,this.loginForm.value.password).subscribe(x=>{
        var data= x as LoginUserInterface;
        if(data.success)
        {
          localStorage.setItem('authenticatedUser',JSON.stringify(x));
          this.routingService.navigate('/dashboard');
        }
      });

    }

  }
}
