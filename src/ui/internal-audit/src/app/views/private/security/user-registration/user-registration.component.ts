import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../../../core/services/http.service';
import { country } from '../../../../core/interfaces/configuration/country.interface';
import { designation } from '../../../../core/interfaces/common/designation.interface';
import { role } from '../../../../core/interfaces/security/role.interface';
import { FormService } from '../../../../core/services/form.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { CutomvalidatorService } from 'src/app/core/services/cutomvalidator.service'
import { userRegistrationRequestData, UserCountry, UserRole } from 'src/app/core/interfaces/security/user-registration.interface'

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


  constructor(private http: HttpService, private fb: FormBuilder, private customValidator: CutomvalidatorService) {
    this.LoadDropDownValues();

    this.countryForm = this.fb.group({
      id: [''],
      empName: ['', [Validators.required, Validators.maxLength(20), Validators.minLength(4)]],
      empEmail: ['', [Validators.required, Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$")]],
      empDesignation: [null, [Validators.required]],
      userName: ['', [Validators.required]],
      userPassword: ['', [Validators.required]],
      userConfirmPassword: ['', [Validators.required]],
      roleList: ['', [Validators.required]],
      countryListSelected: ['', [Validators.required]]
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

  onSubmit(): void {
    console.log(this.countryForm.value);
    let useca: UserRole[] = this.countryForm.value.roleList as UserRole[];
    useca.forEach((element: any) => {
      console.log(element);
    });
    console.log(useca);

    if (this.countryForm.valid) {
      let useca: UserCountry[] = [{ countryId: "", isActive: true, userId: "" }];


      let registrationModel: userRegistrationRequestData = {
        employee:
        {
          email: "",
          designationId: "",
          userId: "",
          photoId: "",
          isActive: true,
          name: ""
        },
        user:
        {
          id: "",
          isAccountExpired: false,
          isAccountLocked: false,
          isEnabled: true,
          isPasswordExpired: false,
          password: "",
          userName: ""
        },
        userCountry: [{ countryId: "", isActive: true, userId: "" }],
        userRole: [{ roleId: "", userId: "" }]
      };

    }
    else {
      this.countryForm.markAllAsTouched();
      return;
    }
  }


}
