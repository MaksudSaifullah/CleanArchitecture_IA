import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../../../core/services/http.service';
import { country } from '../../../../core/interfaces/configuration/country.interface';
import { designation } from '../../../../core/interfaces/common/designation.interface';
import { role } from '../../../../core/interfaces/security/role.interface';
import { FormService } from '../../../../core/services/form.service';
import { FormBuilder, FormControl, FormGroup, Validators, FormArray } from '@angular/forms';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { ActivatedRoute,Router } from '@angular/router';
import { CutomvalidatorService } from 'src/app/core/services/cutomvalidator.service'
import { userRegistrationRequestData, UserCountry, UserRole, UserResponse } from 'src/app/core/interfaces/security/user-registration.interface'
import {AlertService} from '../../../../core/services/alert.service';
import { param } from 'jquery';
import { cibToshiba } from '@coreui/icons';


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
  userResponse:UserResponse []=[]; //| undefined;
  userCountry: UserCountry[]=[];
  displayUserStatus = false;
  selectedUserCountry: UserCountry []=[];
  selectedUserRole: UserRole[]=[];
  employeeId:string='';
  paramId:string ='';

  constructor(private http: HttpService, private router : Router, private fb: FormBuilder, private activateRoute: ActivatedRoute, private customValidator: CutomvalidatorService,private AlertService: AlertService) {
    
    this.LoadDropDownValues();
    this.countryForm = this.fb.group({
      id: [''],
      empName: ['', [Validators.required, Validators.maxLength(20), Validators.minLength(4)]],
      empEmail: ['', [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]],
      empDesignation: [null,[Validators.required]],
      userName: ['',[Validators.required]],
      userPassword: ['',[Validators.required]],
      userConfirmPassword: ['',[Validators.required]],
      roleList: ['',[Validators.required]],
      countryListSelected: [false,[Validators.required]],
      isEnabled: [''],
      accountExpired:[''],
      passwordExpired:[''],
      accountLocked:[''],
      //userRoleList:[this.selectedUserRole]
    },
      {
        validator: this.customValidator.MatchPassword('userPassword', 'userConfirmPassword'),
      }
      
    )
  }
 
 
  ngOnInit(): void {

   this.paramId = this.activateRoute.snapshot.params['id'];
    //console.log(paramId)
    if(this.paramId === undefined){
      console.log("user add method called")
    }
    else{
      this.displayUserStatus = true;
      this.LoadUserById(this.paramId);
    }
  }
  get countryFormControl() {
    return this.countryForm.controls;
  }

  LoadCountry() {
    this.http.paginatedPost('country/paginated', 100, 1, {}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<country>;
      this.countries = convertedResp.items;
      //console.log(this.countries)
    })
  }

  LoadDesignation() {
    this.http.paginatedPost('designation/paginated', 100, 1, {}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<designation>;
      this.designations = convertedResp.items;
    })
  }
  LoadRole() {
    this.http.paginatedPost('role/paginated', 100, 1, {}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<role>;
      this.roles = convertedResp.items;
    })
  }
  LoadDropDownValues() {
    this.LoadCountry();
    this.LoadDesignation();
    this.LoadRole();
  }

  LoadUserById(Id:any):void {
    this.http
      .getById('UserRegistration','Id?Id='+Id)
      .subscribe(res => {
           const userData = res as UserResponse;
           this.employeeId=userData.employee.id;

           this.selectedUserCountry = userData.userCountries;
           this.selectedUserRole = userData.userRoles;
           console.log('user country')
            console.log( this.selectedUserCountry)
          //  console.log(this.selectedUserRole)
           this.countryForm.patchValue({id: userData.id,  empEmail:userData.employee?.email, empName: userData.employee?.name,empDesignation:userData.employee?.designationId,userName:userData.userName,userPassword:userData.password,userConfirmPassword:userData.password,
           roleList:userData.userRoles,countryListSelected:'', isEnabled:userData.isEnabled, accountExpired:userData.isAccountExpired, passwordExpired:userData.isPasswordExpired, accountLocked:userData.isAccountLocked});
      });
      
  }

  isChecked(id:any){
   // debugger;
  //  console.log('inner user country')
  //  console.log( this.selectedUserCountry)
     const that=this;
    for (let country of that.selectedUserCountry){
      if(country.countryId == id){
       // console.log('sldsdfsdf')
        let country: UserCountry = { countryId: id.toString() ,isActive:true,userId:this.paramId===undefined?'':this.paramId}
        const index =  this.userCountry.findIndex(x=>x.countryId == id);
        this.userCountry.splice(index, 1);
        this.userCountry.push(country);
        return true;
      }
     }
     return false;
  }
  isSelected(id:any){
    //debugger;
    for (let role of this.selectedUserRole){
      if(role.roleId==id){
        return true;
      }
     }
     return false;
  }



  onSubmit(): void {

    const that=this;
    let userList: UserRole[] = [];

    if (this.countryForm.valid) {     

      let useca: UserRole[] = this.countryForm.value.roleList as UserRole[];

      if (Array.isArray(useca)) {
        useca.forEach(function (value) {
          let urole: UserRole = { roleId: value.toString(),userId: that.paramId===undefined?'':that.paramId}
        userList.push(urole);
        }); 
        
      }
   
      const RequestModel = {
        employee: {
          userId: this.displayUserStatus == false ? null : this.countryForm.value.id,
          id: this.displayUserStatus == false ? null : this.employeeId,
          email: this.countryForm.value.empEmail,
          designationId: this.countryForm.value.empDesignation,         
          photoId: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          isActive: true,
          name: this.countryForm.value.empName
        },
        user: { 
          id: this.displayUserStatus == false ? null : this.countryForm.value.id,
          isAccountExpired: this.displayUserStatus == false ? false : this.countryForm.value.accountExpired,
          isAccountLocked: this.displayUserStatus == false ? false : this.countryForm.value.accountLocked,
          isEnabled: this.displayUserStatus == false ? true : this.countryForm.value.isEnabled,
          isPasswordExpired: this.displayUserStatus == false ? false : this.countryForm.value.passwordExpired,
          password:this.countryForm.value.userPassword,
          userName: this.countryForm.value.userName
        },
        userCountry: this.userCountry,
        userRole: userList
      };
      //let registrationModel: userRegistrationRequestData = RequestModel;
      console.log('requesat model')
      console.log(JSON.stringify(RequestModel));

      //console.log(paramId)
      if(this.paramId === undefined){
        console.log('add')
        this.http.post('UserRegistration',RequestModel).subscribe(x=>{    
          this.AlertService.success('User Saved Successful');
          this.router.navigate(['security/userlist'], {
            queryParams: {
              myParam: 'inserted', 
            },
          });
        })
      }
      else{
        console.log('edit')
        this.http.put('UserRegistration',RequestModel,this.paramId).subscribe(x=>{    
          this.AlertService.success('User Updated Successful');
          this.router.navigate(['security/userlist'], {
            queryParams: {
              myParam: 'updated', 
            },
          });
        })
      }

      


    }
    else {
      this.countryForm.markAllAsTouched();
      return;
    }
  }
  eventCheck(e:any) { 
   // debugger; 
    const that=this;
    console.log(that.userCountry);
    //console.log(e.target);
    let exists = this.userCountry.includes(e.target.id.toString());   
    if (e.target.checked) {    
      let country: UserCountry = { countryId: e.target.id.toString() ,isActive:true,userId:that.paramId==undefined?'':that.paramId}
      this.userCountry.push(country);
    } else {      
       const index =  this.userCountry.findIndex(x=>x.countryId == e.target.id);
       this.userCountry.splice(index, 1);
    }
    console.log(that.userCountry);
  }

 



}
