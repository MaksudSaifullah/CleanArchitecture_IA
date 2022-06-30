import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, MaxLengthValidator, Validators } from '@angular/forms';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.scss']
})
export class ChangePasswordComponent implements OnInit {
  changePasswordForm : FormGroup;
  constructor(private fb: FormBuilder) {
      this.changePasswordForm = fb.group({
        'currentPassword': ['',Validators.minLength(5)],
        'newPassword': ['',Validators.minLength(5)],
        'confirmPassword': ['',Validators.minLength(5)],
      })
   }

  ngOnInit(): void {
  }

}
