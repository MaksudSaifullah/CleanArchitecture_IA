import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../../../core/services/http.service';
import { country } from '../../../../core/interfaces/configuration/country.interface';
import { designation } from '../../../../core/interfaces/common/designation.interface';
import { role } from '../../../../core/interfaces/security/role.interface';
import { FormService } from '../../../../core/services/form.service';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { ActivatedRoute } from '@angular/router';
import { CutomvalidatorService } from 'src/app/core/services/cutomvalidator.service'
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
  userResponse:UserResponse []=[]; //| undefined;
  userCountry: UserCountry[]=[];
  displayUserStatus = false;
  notifyBackAlertOptions = [
    { name: 'Option 1', id: '1' },
    { name: 'Option 2', id: '2' },
    { name: 'Option 3', id: '3' },
    { name: 'Option 4', id: '4' }
  ];

  constructor(private http: HttpService, private fb: FormBuilder, private activateRoute: ActivatedRoute, private customValidator: CutomvalidatorService,private AlertService: AlertService) {
    
    let paramId = this.activateRoute.snapshot.params['id'];
    //console.log(paramId)
    if(paramId === undefined){
      console.log("user add method called")
      console.log('hh')
   // console.log(this.checkArray)
   // this.LoadDropDownValues();
    }
    else{
      this.displayUserStatus = true;
     this.LoadUserById(paramId);
      console.log('hh')
  //  console.log(this.checkArray)
  // this.LoadDropDownValues();
    }
    
    const notifyBackOptions=['1','2'];
    const notificationControls = this.notifyBackAlertOptions.map(
      x => new FormControl(notifyBackOptions.includes(x.id))
    );



    // this.LoadDropDownValues();

    this.countryForm = this.fb.group({
      id: [''],
      empName: ['', [Validators.required, Validators.maxLength(20), Validators.minLength(4)]],
      empEmail: ['', [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]],
      empDesignation: [null,[Validators.required]],
      userName: ['',[Validators.required]],
      userPassword: ['',[Validators.required]],
      userConfirmPassword: ['',[Validators.required]],
      roleList: ['',[Validators.required]],
      notifyBackOptions: this.fb.array(notificationControls),
      isEnabled: [''],
      accountExpired:[''],
      passwordExpired:[''],
      accountLocked:['']
    },
      {
        validator: this.customValidator.MatchPassword('userPassword', 'userConfirmPassword'),
      }
      
    )
  }
  get notifyBackOptionsArr(): FormArray {
    return this.countryForm.get('notifyBackOptions') as FormArray;
  }
  ngOnInit(): void {
  //   let paramId = this.activateRoute.snapshot.params['id'];
  //   //console.log(paramId)
  //   if(paramId === undefined){
  //     console.log("user add method called")
  //     console.log('hh')
  //  // console.log(this.checkArray)
  //  // this.LoadDropDownValues();
  //   }
  //   else{
  //     this.displayUserStatus = true;
  //    this.LoadUserById(paramId);
  //     console.log('hh')
  // //  console.log(this.checkArray)
  // // this.LoadDropDownValues();
  //   }
    
  }
  get countryFormControl() {
    return this.countryForm.controls;
  }

  LoadCountry() {
    this.http.paginatedPost('country/paginated', 20, 1, {}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<country>;
      this.countries = convertedResp.items;
      // for(let country of this.countries) {
      //   this.checkarray.push(country.id);

      // }
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
          // this.countries = userData.userCountries
          console.log(userData.userCountries)
         // this.checkArray=userData.userCountries?.countryId;
          // console.log('sadasdsda')
          // console.log(this.countryListSelected)
           this.countryForm.setValue({id: userData.id,  empEmail:userData.employee?.email, empName: userData.employee?.name,empDesignation:userData.employee?.designationId,userName:userData.userName,userPassword:userData.password,userConfirmPassword:userData.password,
            roleList:userData.userRoles,countryListSelected:'',isEnabled:userData.isEnabled, accountExpired:userData.isAccountExpired, passwordExpired:userData.isPasswordExpired, accountLocked:userData.isAccountLocked});
          
          //  for(let i=0; i < userData.userRoles?.length; i++){
          //   this.countryForm.setValue({roleList:{
          //     options:[
          //       {
          //         value: userData.userRoles?.
          //         text: userData.userRoles.
          //       }
          //     ]
          //   }})
          //  }
          // for(let country of userData.userCountries) {
          //   this.notifyBackOptions.push(country.countryId);

          // }
          console.log('checking loop')
         // console.log(this.notifyBackOptions)
          this.countryForm.get('countryListSelected')?.reset();
          this.LoadCountry();
        // for(let country of this.countries) {
        //   if(userData.userCountries?.find(x=>x.countryId==country.id)){
        //     console.log('result')
        //     console.log( country.id)
        //     //console.log(this.countryForm.get('countryListSelected')?.value)
        //     console.log(this.countryForm.value.countryListSelected.value)
        //     this.countryForm.value.countryListSelected.id ==true;

        //     // this.countryForm.setValue({
        //     //   "countryListSelected":true
        //     // })

        //   }
        // }

      });
      
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
