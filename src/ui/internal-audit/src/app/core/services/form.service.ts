import { Injectable } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AlertService } from './alert.service';
import { DatatableService } from './datatable.service';

@Injectable({providedIn: 'root'})
export class FormService {
  dataTableService: DatatableService = new DatatableService();

  constructor() { }
  isEdit(formControl:any):boolean{
    formControl = formControl as FormControl;
      if(formControl.value == null || formControl.value == ''){
          return false;
      }
      return true;
  }

     onSaveSuccess(modalId:any,dtElement : any){
      modalId.visible = false;
      this.dataTableService.redraw(dtElement);
    }


}
