import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PrivateRoutingModule } from './private-routing.module';
import { PrivateComponent } from './private.component';
import { ProfileComponent } from './components/profile/profile.component';
import { HeaderComponent } from './components/layout/header/header.component';
import { FooterComponent } from './components/layout/footer/footer.component';
import { SideMenuComponent } from './components/layout/side-menu/side-menu.component';
import { HomeComponent } from './components/home/home.component';


@NgModule({
  declarations: [
    PrivateComponent,
    ProfileComponent,
    HeaderComponent,
    FooterComponent,
    SideMenuComponent,
    HomeComponent
  ],
  imports: [
    CommonModule,
    PrivateRoutingModule
  ]
})
export class PrivateModule { }
