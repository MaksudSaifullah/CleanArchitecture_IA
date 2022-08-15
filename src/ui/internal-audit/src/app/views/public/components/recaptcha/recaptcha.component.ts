import {Component, EventEmitter, OnInit, Output, ViewChild} from '@angular/core';
import {RecaptchaLoaderService, ReCaptchaV3Service} from "ng-recaptcha";
import {environment} from "../../../../../environments/environment";
import {IconSetService} from "@coreui/icons-angular";

@Component({
  selector: 'app-recaptcha',
  templateUrl: './recaptcha.component.html',
  styleUrls: ['./recaptcha.component.scss']
})
export class RecaptchaComponent implements OnInit {
  captchaKey:string = environment.captcha_public_key;
  @Output() tokenEventEmitter = new EventEmitter<string>();
  constructor(private recaptchaLoaderService:RecaptchaLoaderService) { }

  ngOnInit(): void {

  }
  reload(){

    this.recaptchaLoaderService.ready.subscribe(x=>{
      x.reset();
    });
  }
  resolved(captchaResponse: string) {
    this.tokenEventEmitter.emit(captchaResponse);
  }
}
