import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, MaxLengthValidator, Validators } from '@angular/forms';
import { AlertService } from 'src/app/core/services/alert.service';
import { CutomvalidatorService } from 'src/app/core/services/cutomvalidator.service';
import { FormService } from 'src/app/core/services/form.service';
import { TupleInterface } from 'src/app/core/interfaces/tuple.interface';
import { HttpService } from 'src/app/core/services/http.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.scss']
})
export class ChangePasswordComponent implements OnInit {
  changePasswordForm : FormGroup;
  public formService: FormService;
  constructor(private customValidator:CutomvalidatorService,private fb: FormBuilder, private cutomvalidatorService: CutomvalidatorService,private _formService : FormService,private http: HttpService, private alertService:AlertService) {
    this.formService = _formService;
    this.changePasswordForm = fb.group({
        currentPassword: ['',[Validators.required,Validators.minLength(5)]],
        newPassword: ['',[Validators.required,Validators.minLength(5)]],
        confirmPassword: ['',[Validators.required,Validators.minLength(5)]],
      },{
        validator: this.customValidator.MatchPassword('newPassword', 'confirmPassword'),
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
        let convertedResponse = x as TupleInterface<boolean,string>;
        if(convertedResponse.item1){
          this.alertService.success(convertedResponse.item2);
          this.changePasswordForm.reset();
        }
        else{
          this.alertService.error(convertedResponse.item2);
        }
      });
    }
  }

  passwordMatchError() : boolean {
    return this.changePasswordForm.get('newPassword')?.value == this.changePasswordForm.get('confirmPassword')?.value;
  }
}
