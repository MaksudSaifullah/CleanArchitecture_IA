import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {ReCaptchaV3Service} from "ng-recaptcha";
import {environment} from "../../../../../environments/environment";

@Component({
  selector: 'app-recaptcha',
  templateUrl: './recaptcha.component.html',
  styleUrls: ['./recaptcha.component.scss']
})
export class RecaptchaComponent implements OnInit {
  captchaKey:string = environment.captcha_public_key;
  @Output() tokenEventEmitter = new EventEmitter<string>();
  constructor() { }

  ngOnInit(): void {

  }
  resolved(captchaResponse: string) {
    this.tokenEventEmitter.emit(captchaResponse);
  }
}
