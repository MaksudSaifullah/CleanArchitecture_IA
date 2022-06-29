import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class CutomvalidatorService {

  MatchPassword(password: string, confirmPassword: string) {
    return (formGroup: FormGroup) => {
      const passwordControl = formGroup.controls[password];
      const confirmPasswordControl = formGroup.controls[confirmPassword];

      if (!passwordControl || !confirmPasswordControl) {
        return null;
      }

      if (confirmPasswordControl.errors && !confirmPasswordControl.errors['passwordMismatch']) {
        return null;
      }

      if (passwordControl.value !== confirmPasswordControl.value) {
        confirmPasswordControl.setErrors({ passwordMismatch: true });
      } else {
        confirmPasswordControl.setErrors(null);
      }
      return null;
    }
  }
  CheckDropDownValue(val:string){
    return (formGroup: FormGroup) => {
      const dropDownvalueControl = formGroup.controls[val];     

      if (!dropDownvalueControl || !dropDownvalueControl) {
        return null;
      }
      if (dropDownvalueControl.value === "0") {
        dropDownvalueControl.setErrors({ val:true });
      }
      
      return null;
    }
   
  }

}
