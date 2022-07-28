import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {CutomvalidatorService} from "../../../../core/services/cutomvalidator.service";
import {HttpService} from "../../../../core/services/http.service";
import {RoutingService} from "../../../../core/services/routing.service";
import {PasswordResetInterface} from "../../../../core/interfaces/password-reset.interface";
import {ActivatedRoute} from "@angular/router";
import {CommonResponseInterface} from "../../../../core/interfaces/common-response.interface";
import {AlertService} from "../../../../core/services/alert.service";
@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})
export class ResetPasswordComponent implements OnInit {
  forgotPasswordForm: FormGroup;
  isInvalidCode: boolean = false;
  constructor(private fb: FormBuilder,private customValidator: CutomvalidatorService,
              private httpService: HttpService, private routingService: RoutingService,private route: ActivatedRoute,
              private alertService:AlertService) {

    this.forgotPasswordForm = this.fb.group({
      postCode:[],
      newPassword: ['',[Validators.required,Validators.minLength(5)]],
      confirmPassword: ['',[Validators.required,Validators.minLength(5)]],
    },{
      validator: this.customValidator.MatchPassword('newPassword', 'confirmPassword'),
    }
    );
  }

  ngOnInit(): void {
    let code = this.route.snapshot.params['code'];
    this.httpService.post("authentication/VerifyPasswordResetLink",{emailCode:code}).subscribe(x=>{
      let convertedResponse = x as PasswordResetInterface;
      if(convertedResponse.success){
        this.isInvalidCode = false;
        this.forgotPasswordForm.controls['postCode'].setValue(convertedResponse.postCode);
      }
      else{
        this.isInvalidCode = true;
      }
    });
  }

  submit() {
    if (this.forgotPasswordForm.valid){
      this.httpService.post('authentication/UpdateUserPasswordByPostCode',this.forgotPasswordForm.value).subscribe(x=>{
        let convertedResponse = x as CommonResponseInterface;
        if(convertedResponse.success){
          this.alertService.success("Password Reset Successful");
          this.routingService.navigate('/login');
        }
        else{
          this.alertService.error(convertedResponse.message);
        }
      })
    }
  }
}
