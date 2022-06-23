import { Injectable } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Injectable({providedIn: 'root'})
export class FormService {
  constructor() { }
  isEdit(formControl:any):boolean{
    formControl = formControl as FormControl;
      if(formControl.value == null || formControl.value == ''){
          return false;
      }
      return true;
  }
}
