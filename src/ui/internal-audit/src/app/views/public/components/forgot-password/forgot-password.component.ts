import { Component, OnInit } from '@angular/core';
import {HttpService} from "../../../../core/services/http.service";
import {AlertService} from "../../../../core/services/alert.service";
import {CommonResponseInterface} from "../../../../core/interfaces/common-response.interface";

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss']
})
export class ForgotPasswordComponent implements OnInit {
  email:string = '';
  isResetLinkSent : boolean = false;
  constructor(private httpService:HttpService,private alertService: AlertService) { }

  ngOnInit(): void {
  }
  submit():void{
    if(this.email != '' && this.email != null){
      this.httpService.post('authentication/SendPasswordReset',{"email":this.email}).subscribe(x=>{
        let res = x as CommonResponseInterface;
        this.email = '';
        if(res.success){
          this.alertService.success(res.message);
          this.isResetLinkSent = true;
        }
        else{
          this.alertService.error(res.message);
        }
      });
    }
    else {
      this.alertService.error('Username or Email is not Valid');
    }
  }
}
