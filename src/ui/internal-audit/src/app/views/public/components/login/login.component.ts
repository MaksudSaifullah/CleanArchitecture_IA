import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/core/auth/auth.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  constructor(private authService: AuthService,private fb:FormBuilder) {
    this.loginForm = this.fb.group({
      username:['',[Validators.required,Validators.minLength(5)]],
      password:['',[Validators.required,Validators.minLength(5)]],
    });
   }

  ngOnInit(): void {

  }
  async onSubmit() {
    if(this.loginForm.valid){
      var result = await this.authService.authenticate(this.loginForm.value.username,this.loginForm.value.password);
      console.log(result);
    }

  }
}
