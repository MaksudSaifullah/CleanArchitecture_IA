import { Injectable } from '@angular/core';
import { HotToastService } from '@ngneat/hot-toast';
import Swal, { SweetAlertResult } from 'sweetalert2';

@Injectable({providedIn: 'root'})
export class AlertService {
  toastrService : HotToastService;
  constructor(private _toastrService: HotToastService) {
    this.toastrService = _toastrService;
  }
  success(message: string){
    this._toastrService.success(message,{
      style: {
        border: '1px solid #ddd',
        padding: '16px',
        color: '#1E1E1E',
        background: '#E8F6F0',

      },
      position:'top-right',
      iconTheme: {
        primary: '#49CC90',
        secondary: '#FFFAEE',

      },
    });
  }
  
  error(message: string){
    this._toastrService.error(message,{
      style: {
        border: '1px solid #ddd',
        padding: '16px',
        color: '#eb4039',
        background: '#ffc2b3',

      },
      position:'top-right',
      iconTheme: {
        primary: '#eb4039',
        secondary: '#FFFAEE',

      },
    });
  }
  confirmDialog():Promise<SweetAlertResult<any>>{
    return Swal.fire({
      title: 'Are you sure?',
      text: "You won't be able to revert this!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    });
  }
  successDialog(type:string|undefined,message:string|undefined){
    Swal.fire(
      type?? 'Completed.',
      message?? 'Your operation completed successfully.',
    'success'
    )
  }
warningDialog(type:string|undefined,message:string|undefined){
  Swal.fire(
    type?? 'Completed.',
    message?? 'Your operation completed successfully.',
  'warning'
  )
  }
  errorDialog(type:string|undefined,message:string|undefined){
    Swal.fire(
      type?? 'Unsuccessful.',
      message?? 'Your operation cannot be completed.',
    'error'
    )
    }
}
