import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../../../core/services/http.service';
import { country } from '../../../../core/interfaces/configuration/country.interface';
import { designation } from '../../../../core/interfaces/common/designation.interface';
import { role } from '../../../../core/interfaces/security/role.interface';

@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
  styleUrls: ['./user-registration.component.scss']
})
export class UserRegistrationComponent implements OnInit {
  countries: country[] = [];
  designations: designation[] = [];
  roles: role[] = [];
  
  constructor(private http: HttpService) {  
     this.LoadCountry(); 
     this.LoadDesignation(); 
     this.LoadRole(); 
    }

  ngOnInit(): void {

  }
  
  
  LoadCountry(){
    this.http.get('api/v1/country/all').subscribe(resp=>{
      this.countries= (resp as country[]);
      console.log(this.countries);
    })
  }

  LoadDesignation(){
    this.http.get('api/v1/designation/all').subscribe(resp=>{
      this.designations= (resp as designation[]);
      console.log(this.designations);
    })
  }

  LoadRole(){
    this.http.get('api/v1/role/all').subscribe(resp=>{
      this.roles= (resp as role[]);
      console.log(this.roles);
    })
  }

}
