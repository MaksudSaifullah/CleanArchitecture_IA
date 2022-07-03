import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, MaxLengthValidator, Validators } from '@angular/forms';
import { CutomvalidatorService } from 'src/app/core/services/cutomvalidator.service';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.scss']
})
export class ChangePasswordComponent implements OnInit {
  changePasswordForm : FormGroup;
  public formService: FormService;
  constructor(private fb: FormBuilder, private cutomvalidatorService: CutomvalidatorService,private _formService : FormService,private http: HttpService) {
    this.formService = _formService;
    this.changePasswordForm = fb.group({
        currentPassword: ['',[Validators.required,Validators.minLength(5)]],
        newPassword: ['',[Validators.required,Validators.minLength(5)]],
        confirmPassword: ['',[Validators.required,Validators.minLength(5)]],
      }
      )
   }

  ngOnInit(): void {
  }
  submit(){
    debugger;
    if(this.changePasswordForm.valid && this.passwordMatchError()){
      this.http.post('userregistration/ChangePassword',this.changePasswordForm.value).subscribe(x=>{
        debugger;
        console.log(x);
      });
      //console.log(this.changePasswordForm.value);
    }
  }

  passwordMatchError() : boolean {
    return this.changePasswordForm.get('newPassword')?.value == this.changePasswordForm.get('confirmPassword')?.value;
  }
}
