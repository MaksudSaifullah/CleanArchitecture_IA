import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, MaxLengthValidator, Validators } from '@angular/forms';
import { CutomvalidatorService } from 'src/app/core/services/cutomvalidator.service';
import { FormService } from 'src/app/core/services/form.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.scss']
})
export class ChangePasswordComponent implements OnInit {
  changePasswordForm : FormGroup;
  public formService: FormService;
  constructor(private fb: FormBuilder, private cutomvalidatorService: CutomvalidatorService,private _formService : FormService) {
    this.formService = _formService;
    this.changePasswordForm = fb.group({
        currentPassword: ['',[Validators.required,Validators.minLength(5)]],
        newPassword: ['',[Validators.required,Validators.minLength(5)]],
        confirmPassword: ['',[Validators.required,Validators.minLength(5)]],
      })
   }

  ngOnInit(): void {
  }
  submit(){
    if(this.changePasswordForm.valid){
    }
  }
}
