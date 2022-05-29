import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CountryComponent } from './common/country/country.component';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Configuration'
    },
  children:[
    {
      path: 'country',
      component: CountryComponent,
      data: 
        {
          title: 'Country',
        },
    },
  ]
  }

];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    [RouterModule.forChild(routes)],
  ],
  exports: [RouterModule],
})
export class ConfigurationRoutingModule { }
