import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PublicRoutingModule } from './public-routing.module';
import { PublicComponent } from './public.component';
import { AboutComponent } from './components/about/about.component';
import { NotFoundComponent } from './components/notfound/not-found/not-found.component';


@NgModule({
  declarations: [
    PublicComponent,
    AboutComponent,
    NotFoundComponent
  ],
  imports: [
    CommonModule,
    PublicRoutingModule
  ]
})
export class PublicModule { }
