import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PublicRoutingModule } from './public-routing.module';
import { AboutComponent } from './components/about/about.component';
import { LoginComponent } from './components/login/login.component';
import { ButtonModule, CardModule, FormModule, GridModule } from '@coreui/angular-pro';
import { IconModule } from '@coreui/icons-angular';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RECAPTCHA_V3_SITE_KEY, RecaptchaV3Module, RecaptchaFormsModule, RecaptchaModule } from "ng-recaptcha";
import { environment } from 'src/environments/environment';

@NgModule({
  declarations: [
    AboutComponent,
    LoginComponent
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
    RecaptchaFormsModule,
    RecaptchaModule,
  ],
  providers:[{ provide: RECAPTCHA_V3_SITE_KEY, useValue: environment.captcha_public_key }]
})
export class PublicModule { }
