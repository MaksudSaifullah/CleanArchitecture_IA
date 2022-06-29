import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../../../core/services/http.service';
import { country } from '../../../../core/interfaces/configuration/country.interface';
import { designation } from '../../../../core/interfaces/common/designation.interface';
import { role } from '../../../../core/interfaces/security/role.interface';
import { FormService } from '../../../../core/services/form.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import {CutomvalidatorService} from'src/app/core/services/cutomvalidator.service'

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


  constructor(private http: HttpService, private fb: FormBuilder,  private customValidator: CutomvalidatorService) {
    this.LoadDropDownValues();

    this.countryForm = this.fb.group({
      id: [''],
      empName: ['', [Validators.required, Validators.maxLength(20), Validators.minLength(4)]],
      empEmail: ['', [Validators.required,Validators.pattern(/^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/)]],
      empDesignation: [null,[Validators.required]],
      userName: ['',[Validators.required]],
      userPassword: ['',[Validators.required]],
      userConfirmPassword: ['',[Validators.required]],
      roleList:['',[Validators.required]],
      countryListSelected:['',[Validators.required]]
    },
    {
      validator: this.customValidator.MatchPassword('userPassword', 'userConfirmPassword'),           
    }
    )


  }

  ngOnInit(): void {

  }
  get countryFormControl() {
    return this.countryForm.controls;
  }

  LoadCountry() {
    this.http.paginatedPost('country/paginated',20,1,{}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<country>;
      this.countries = convertedResp.items;     
    })
  }

  LoadDesignation() {
      this.http.paginatedPost('designation/paginated',100,1,{}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<designation>;
      this.designations = convertedResp.items;     
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
          this.countryForm.markAllAsTouched();
          return;
        }
      } 
       

}
