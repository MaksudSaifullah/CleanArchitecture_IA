import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormService } from 'src/app/core/services/form.service';
import { accessPrivilegeConfig } from 'src/app/core/interfaces/security/access-privilege.interface'
import {AlertService} from '../../../../core/services/alert.service';
import { HttpService } from 'src/app/core/services/http.service';
@Component({
  selector: 'app-access-privilege',
  templateUrl: './access-privilege.component.html',
  styleUrls: ['./access-privilege.component.scss']
})
export class AccessPrivilegeComponent implements OnInit {
  accessPrivilegeConfigData: accessPrivilegeConfig[] = [];
  accessPrivilegeForm: FormGroup;
  formService: FormService = new FormService();
 

  
  constructor(private http: HttpService , private fb: FormBuilder, private AlertService: AlertService) {
    this.accessPrivilegeForm = this.fb.group({
      //passwordPolicy_id: [''],
      minLength: ['', [Validators.required]],
      maxLength: ['', [Validators.required]],
      isAlphabetMandatory: ['', [Validators.required]],
      alphabetLength: [''],
      isNumberMandatory: ['', [Validators.required]],
      numericLength: [''],
      isSpecialCharsMandatory: ['', [Validators.required]],
      specialCharsLength: [''],
      isPasswordChangeForcedOnFirstLogin: ['', [Validators.required]],
      isPasswordResetForcedPeriodically: ['', [Validators.required]],
      forcePasswordResetDays: ['', [Validators.required]],
      notifyPasswordResetDays: ['', [Validators.required]],

     // userLockingPolicy_id : [''],
      isLockedOnNoLoginActivity : ['', [Validators.required]],
      noLoginActivityDays : [''],
      isLockedOnFailedLoginAttempts : ['', [Validators.required]],
      numberOfFailedLoginAttempts : [''],
      failedLoginAttemptsDuration : [''],
      failedLoginLockedDuration : [''],
      isUnlockedOnByAdmin : ['', Validators.required],
      unlockedOnByAdminDuration : ['', Validators.required],

     // sessionPolicy_id: [''],
      sessionPolicy_duration: ['', [Validators.required]]
    })
  }
  ngOnDestroy(): void {

  }
  ngOnInit(): void {
    this.loadData();
  };

  onSubmit():void 
  {
    // const RequestModel = {
    //   passwordPolicy: {
    //     id:                                this.accessPrivilegeForm.value.passwordPolicy_id,
    //     minLength:                         this.accessPrivilegeForm.value.minLength,
    //     maxLength:                         this.accessPrivilegeForm.value.maxLength,
    //     isAlphabetMandatory:               this.accessPrivilegeForm.value.isAlphabetMandatory,
    //     alphabetLength:                    this.accessPrivilegeForm.value.alphabetLength,
    //     isNumberMandatory:                 this.accessPrivilegeForm.value.isNumberMandatory,
    //     numericLength:                     this.accessPrivilegeForm.value.numericLength,
    //     isSpecialCharsMandatory:           this.accessPrivilegeForm.value.isSpecialCharsMandatory,
    //     specialCharsLength:                this.accessPrivilegeForm.value.specialCharsLength,
    //     isPasswordChangeForcedOnFirstLogin:this.accessPrivilegeForm.value.isPasswordChangeForcedOnFirstLogin,
    //     isPasswordResetForcedPeriodically: this.accessPrivilegeForm.value.isPasswordResetForcedPeriodically,
    //     forcePasswordResetDays:            this.accessPrivilegeForm.value.forcePasswordResetDays,
    //     notifyPasswordResetDays:           this.accessPrivilegeForm.value.notifyPasswordResetDays,
    //     effectiveFrom:                     this.accessPrivilegeForm.value.effectiveFrom,
    //     effectiveTo:                       this.accessPrivilegeForm.value.effectiveTo,
    //   },
    //   userLockingPolicy: {         
    //     id:                          this.accessPrivilegeForm.value.userLockingPolicy_id,
    //     isLockedOnNoLoginActivity:   boolean;
    //     noLoginActivityDays:         number;
    //     lockedOnFailedLoginAttempts: boolean;
    //     numberOfFailedLoginAttempts: number;
    //     failedLoginAttemptsDuration: number;
    //     failedLoginLockedDuration:   number;
    //     unlockedOnByAdmin:           boolean;
    //     unlockedOnByAdminDuration:   number;
    //     effectiveFrom:               Date;
    //     effectiveTo:                 Date;
    //   },
    //   sessionPolicy: {
    //     email: this.countryForm.value.empEmail,
    //     designationId: this.countryForm.value.empDesignation,         
    //     photoId: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    //     isActive: true,
    //     name: this.countryForm.value.empName
    //   }
    // };
   
    
      if(this.accessPrivilegeForm.valid){    
        console.log(this.accessPrivilegeForm.value);    
        this.http.put('accessPrivilege',this.accessPrivilegeForm.value,null).subscribe(x=>{
         // console.log(x);
          //this.formService.onSaveSuccess(localmodalId,this.datatableElement);
          this.AlertService.success('Country Saved Successful');
        });
      }
      else{
        this.AlertService.error('Invalid Information');
      }
  }
  

  loadData():void {
    //const localmodalId = modalId;
    //console.log(country.id)

    this.http
      .get('accessPrivilege')
      .subscribe(res => {
          const response = res as unknown as accessPrivilegeConfig;
          //console.log(response.passwordPolicy.minLength);
          this.accessPrivilegeForm.setValue({minLength : response.passwordPolicy.minLength, 
            maxLength : response.passwordPolicy.maxLength,
            isAlphabetMandatory : response.passwordPolicy.isAlphabetMandatory,
            alphabetLength : response.passwordPolicy.alphabetLength,
            isNumberMandatory : response.passwordPolicy.isNumberMandatory,
            numericLength : response.passwordPolicy.numericLength,
            isSpecialCharsMandatory : response.passwordPolicy.isSpecialCharsMandatory,
            specialCharsLength : response.passwordPolicy.specialCharsLength,
            isPasswordChangeForcedOnFirstLogin: response.passwordPolicy.isPasswordChangeForcedOnFirstLogin,
            isPasswordResetForcedPeriodically: response.passwordPolicy.isPasswordResetForcedPeriodically,
            forcePasswordResetDays : response.passwordPolicy.forcePasswordResetDays,
            notifyPasswordResetDays : response.passwordPolicy.notifyPasswordResetDays,

            isLockedOnNoLoginActivity : response.userLockingPolicy.isLockedOnNoLoginActivity,
            noLoginActivityDays : response.userLockingPolicy.noLoginActivityDays,
            isLockedOnFailedLoginAttempts : response.userLockingPolicy.lockedOnFailedLoginAttempts,
            numberOfFailedLoginAttempts : response.userLockingPolicy.numberOfFailedLoginAttempts,
            failedLoginAttemptsDuration : response.userLockingPolicy.failedLoginAttemptsDuration,
            failedLoginLockedDuration : response.userLockingPolicy.failedLoginLockedDuration,
            isUnlockedOnByAdmin : response.userLockingPolicy.unlockedOnByAdmin,
            unlockedOnByAdminDuration: response.userLockingPolicy.unlockedOnByAdminDuration,

            sessionPolicy_duration : response.sessionPolicy.duration,
          });
      });    
  }
  // onCheckAlphabet():void{
  //   var checkBox = document.getElementById("alphabet");
  //   var maxAlphabet = document.getElementById("maxAlphabet");
  //   if (checkBox.chec == true){
  //     maxAlphabet.style.display = "block";
  //   } else {
  //     maxAlphabet.style.display = "none";
  //   }
  // }

}
