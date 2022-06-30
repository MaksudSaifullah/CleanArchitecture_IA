import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { role } from 'src/app/core/interfaces/security/role.interface';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';
import {AlertService} from '../../../../core/services/alert.service';

@Component({
  selector: 'app-user-role',
  templateUrl: './user-role.component.html',
  styleUrls: ['./user-role.component.scss']
})
export class UserRoleComponent implements OnInit {
  
@ViewChild(DataTableDirective, {static: false})
datatableElement: DataTableDirective | undefined;
dtOptions: DataTables.Settings = {};
roles: role[] = [];
roleForm: FormGroup;
formService: FormService = new FormService();
dataTableService: DatatableService = new DatatableService();
dtTrigger: Subject<any> = new Subject<any>();

constructor(private http: HttpService , private fb: FormBuilder, private AlertService: AlertService) {
  this.roleForm = this.fb.group({
    id: [''],
    name: ['',[Validators.required,Validators.minLength(3),Validators.maxLength(20)]],
    description: ['',[Validators.required,Validators.minLength(3),Validators.maxLength(50)]],
    isActive: [''],
  })
}
ngOnDestroy(): void {

}
ngOnInit(): void {
  this.LoadData();
  };
LoadData() {
  const that = this;

  this.dtOptions = {
    pagingType: 'full_numbers',
    pageLength: 10,
    serverSide: true,
    processing: true,
    searching: false,
    ajax: (dataTablesParameters: any, callback) => {
      this.http
        .paginatedPost(
          'role/paginated',dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1),{}
        ).subscribe(resp => that.roles = this.dataTableService.datatableMap(resp,callback));
    },
  };

}

  onSubmit(modalId:any):void{
    const localmodalId = modalId;
      if(this.roleForm.valid){
        if(this.formService.isEdit(this.roleForm.get('id') as FormControl)){
          this.http.put('role',this.roleForm.value,null).subscribe(x=>{
            this.formService.onSaveSuccess(localmodalId,this.datatableElement);
            this.AlertService.success('User Role Updated Successful');

          });
        }
        else{
          this.http.post('role',this.roleForm.value).subscribe(x=>{
            this.formService.onSaveSuccess(localmodalId,this.datatableElement);
            this.AlertService.success('User Role Saved Successful');
          });
        }
      }
  }

  edit(modalId:any, role:any):void {
    const localmodalId = modalId;
    this.http
      .getById('role',role.id)
      .subscribe(res => {
          const roleResponse = res as role;
          console.log(roleResponse);
          this.roleForm.setValue({id : roleResponse.id, name : roleResponse.name, description: roleResponse.description, isActive: roleResponse.isActive});
      });
      localmodalId.visible = true;
  }
  delete(id:string){
    const that = this;
    this.AlertService.confirmDialog().then(res =>{
      if(res.isConfirmed){
          this.http.delete('role/'+ id ,{}).subscribe(response=>{
          this.AlertService.successDialog('Deleted','Role deleted successfully.');
          this.dataTableService.redraw(that.datatableElement);
        })
      }
    });
  }
  reset(){
    this.roleForm.reset();
  }
}
