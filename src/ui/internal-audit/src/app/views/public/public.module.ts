import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PublicRoutingModule } from './public-routing.module';
import { AboutComponent } from './components/about/about.component';
import { LoginComponent } from './components/login/login.component';
import { ButtonModule, CardModule, FormModule, GridModule } from '@coreui/angular-pro';
import { IconModule } from '@coreui/icons-angular';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { RecaptchaComponent } from './components/recaptcha/recaptcha.component';
import {
  RECAPTCHA_V3_SITE_KEY,
  RecaptchaLoaderService,
  RecaptchaModule,
  RecaptchaV3Module,
  ReCaptchaV3Service
} from "ng-recaptcha";
import { ResetPasswordComponent } from './components/reset-password/reset-password.component';
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
@NgModule({
  declarations: [
    AboutComponent,
    LoginComponent,
    RecaptchaComponent,
    ResetPasswordComponent,
    ForgotPasswordComponent
  ],
  imports: [
    CommonModule,
    FormModule,
    PublicRoutingModule,
    CardModule,
    ButtonModule,
    GridModule,
    IconModule,
    FormModule,
    ReactiveFormsModule,
    HttpClientModule,
    RecaptchaV3Module,
    RecaptchaModule,
    FormsModule
  ],
  providers:[ReCaptchaV3Service,RecaptchaLoaderService,{
    provide: RECAPTCHA_V3_SITE_KEY,
    useValue: environment.captcha_public_key,
  }]
})
export class PublicModule { }
