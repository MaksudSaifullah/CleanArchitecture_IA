import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../../../core/services/http.service';
import { country } from '../../../../core/interfaces/configuration/country.interface';
import { designation } from '../../../../core/interfaces/common/designation.interface';
import { role } from '../../../../core/interfaces/security/role.interface';
import { FormService } from '../../../../core/services/form.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { ActivatedRoute } from '@angular/router';
import { CutomvalidatorService } from 'src/app/core/services/cutomvalidator.service'
import { userRegistrationRequestData, UserCountry, UserRole, UserResponse } from 'src/app/core/interfaces/security/user-registration.interface'
import { userRegistrationRequestData, UserCountry, UserRole, UserResponse } from 'src/app/core/interfaces/security/user-registration.interface'
import {AlertService} from '../../../../core/services/alert.service';

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
  userRequestModel: any;
  userResponse:UserResponse | undefined;
  userCountry: UserCountry[]=[];

  constructor(private http: HttpService, private fb: FormBuilder, private activateRoute: ActivatedRoute, private customValidator: CutomvalidatorService,private AlertService: AlertService) {
    this.LoadDropDownValues();

    this.countryForm = this.fb.group({
      id: [''],
      empName: ['', [Validators.required, Validators.maxLength(20), Validators.minLength(4)]],
      empEmail: ['', [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]],
      empDesignation: [null],
      userName: [''],
      userPassword: [''],
      userConfirmPassword: [''],
      roleList: [''],
      countryListSelected: ['']
    },
      {
        validator: this.customValidator.MatchPassword('userPassword', 'userConfirmPassword'),
      }
      
    )

    let Id = this.activateRoute.snapshot.params['id'];
    if(Id !=null || Id!=""){
      this.LoadUserById(Id);
    }
  }

  ngOnInit(): void {
    
  }
  get countryFormControl() {
    return this.countryForm.controls;
  }

  LoadCountry() {
    this.http.paginatedPost('country/paginated', 20, 1, {}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<country>;
      this.countries = convertedResp.items;
    })
  }

  LoadDesignation() {
    this.http.paginatedPost('designation/paginated', 100, 1, {}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<designation>;
      this.designations = convertedResp.items;
    })
  }
  LoadUserById(Id:any):void {
   // debugger
    this.http
      .getById('UserRegistration','Id?Id='+Id)
      .subscribe(res => {
       // console.log(res)
           const userData = res as UserResponse;
           console.log(userData.id)
           this.countryForm.setValue({id: userData.id,  empEmail:userData.employee?.email, empName: userData.employee?.name,empDesignation:userData.employee?.designationId,userName:userData.userName,userPassword:userData.password,userConfirmPassword:userData.password,roleList:'',countryListSelected:''});
    
      });
      
  }

  LoadRole() {
    this.http.get('role/all').subscribe(resp => {
      this.roles = (resp as role[]);
      //console.log(this.roles);
    })
  }
  LoadDropDownValues() {
    this.LoadCountry();
    this.LoadDesignation();
    this.LoadRole();
  }

  onSubmit(): void {
    console.log(this.countryForm.value.countryListSelected);
    let userList: UserRole[] = [];

    if (this.countryForm.valid) {     

      let useca: UserRole[] = this.countryForm.value.roleList as UserRole[];

      if (Array.isArray(useca)) {
        useca.forEach(function (value) {
          let urole: UserRole = { roleId: value.toString() }
        userList.push(urole);
        }); 
        
      }
   
      const RequestModel = {
        employee: {
          email: this.countryForm.value.empEmail,
          designationId: this.countryForm.value.empDesignation,         
          photoId: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          isActive: true,
          name: this.countryForm.value.empName
        },
        user: {         
          isAccountExpired: false,
          isAccountLocked: false,
          isEnabled: true,
          isPasswordExpired: false,
          password:this.countryForm.value.userPassword,
          userName: this.countryForm.value.userName
        },
        userCountry: this.userCountry,
        userRole: userList
      };
      //let registrationModel: userRegistrationRequestData = RequestModel;
      console.log('requesat model')
      console.log(JSON.stringify(RequestModel));

      this.http.post('UserRegistration',RequestModel).subscribe(x=>{    
        this.AlertService.success('Country Saved Successful');
        window.location.reload();
      })


    }
    else {
      this.countryForm.markAllAsTouched();
      return;
    }
  }
  eventCheck(e:any) {  
    console.log(this.userCountry);
    let exists = this.userCountry.includes(e.target.id.toString());   
    if (e.target.checked) {    
      let country: UserCountry = { countryId: e.target.id.toString() ,isActive:true}
      this.userCountry.push(country);
    } else {      
       const index =  this.userCountry.findIndex(x=>x.countryId == e.target.id);
       this.userCountry.splice(index, 1);
    }
  }

}
