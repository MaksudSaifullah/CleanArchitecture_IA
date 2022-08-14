import { Injectable } from '@angular/core';
import { AbstractControl, FormGroup } from '@angular/forms';

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

  checkEffectiveDateToAfterFrom(effectiveFrom:string, effectiveTo: string){
    return (formGroup: FormGroup)=>
    {   
      console.log('hhhhhhhhh')   
      const from = formGroup.controls['effectiveFrom'];
      const to = formGroup.controls['effectiveTo'];
      if (!from || !to) {
        return null;
      }
      if((to.value)<(from.value)){
        console.log('error')          
        return { invalidDateRange : true };
      }
      return null;

    }

  }

  checkAssessmentDateToAfterFrom(assessmentFrom:string, assessmentTo: string){
    return (formGroup: FormGroup)=>
    {    
      const from = formGroup.controls['assessmentFrom'];
      const to = formGroup.controls['assessmentTo'];
      if (!from || !to) {
        return null;
      }
      if((to.value)<(from.value)){      
        return { invalidDateRange : true };
      }
      return null;

    }

  }
}
