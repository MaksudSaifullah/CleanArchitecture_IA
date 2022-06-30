import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../../../core/services/http.service';
import { country } from '../../../../core/interfaces/configuration/country.interface';
import { designation } from '../../../../core/interfaces/common/designation.interface';
import { role } from '../../../../core/interfaces/security/role.interface';
import { FormService } from '../../../../core/services/form.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
  styleUrls: ['./user-registration.component.scss']
})
export class UserRegistrationComponent implements OnInit {
  countries: country[] = [];
  designations: designation[] = [];
  roles: role[] = [];
  countryForm: FormGroup;
  formService: FormService = new FormService();

  constructor(private http: HttpService, private fb: FormBuilder,private activateRoute:ActivatedRoute) {
    this.LoadDropDownValues();

    this.countryForm = this.fb.group({
      id: [''],
      empName: ['', [Validators.required, Validators.maxLength(20), Validators.minLength(4)]],
      empEmai: ['', [Validators.required, Validators.maxLength(30), Validators.minLength(7)]],
      empDesignation: ['',[Validators.required]],
      countryListSelected:['']
    })

  }

  ngOnInit(): void {
    let id = this.activateRoute.snapshot.params['id'];
    //console.log(`route id ${id}`);
    if(id !=null || id!=""){
      this.LoadUserById(id);
      console.log(id)
    }
  }


  LoadCountry() {
    this.http.paginatedPost('country/paginated',20,1,{}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<country>;
      this.countries = convertedResp.items;
     
      console.log(this.countries);
    })
  }

  LoadDesignation() {
    this.http.get('designation/all').subscribe(resp => {
      this.designations = (resp as designation[]);
      console.log(this.designations);
    })
  }
  LoadUserById(Id:string) {
    this.http.getById('UserRegistration', Id).subscribe(resp => {
     // this.designations = (resp as designation[]);

    

      console.log(resp);
    })
  }

  LoadRole() {
    this.http.get('role/all').subscribe(resp => {
      this.roles = (resp as role[]);
      console.log(this.roles);
    })
  }
  LoadDropDownValues() {
    this.LoadCountry();
    this.LoadDesignation();
    this.LoadRole();
  }
  onSubmit():void{
    console.log(this.countryForm.value);
      if(this.countryForm.valid){
        
        }
        else{
          
        }
      }  

}
