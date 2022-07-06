import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { role } from 'src/app/core/interfaces/security/role.interface';
import { ModuleList, UserRoleAccessPrivilege } from 'src/app/core/interfaces/security/user-role-accessprivilege.interface';
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
dtOptionsAccessPrivilege: DataTables.Settings = {};
roles: role[] = [];
userPrivilegeList: UserRoleAccessPrivilege[] = [];
rolesDropdown: role[] = [];
modules: ModuleList[] = [];
roleForm: FormGroup;
privilegeForm: FormGroup;
formService: FormService = new FormService();
dataTableService: DatatableService = new DatatableService();
dtTrigger: Subject<any> = new Subject<any>();

constructor(private http: HttpService , private fb: FormBuilder, private AlertService: AlertService) {
  this.loadDropDownValues();
  this.roleForm = this.fb.group({
    id: [''],
    name: ['',[Validators.required,Validators.minLength(3),Validators.maxLength(20)]],
    description: ['',[Validators.required,Validators.minLength(3),Validators.maxLength(50)]],
    isActive: [''],
  })

  this.privilegeForm =this.fb.group({
    id: [''],
    role: [null,[Validators.required]],
    module: [null,[Validators.required]],
   
  })
}
ngOnDestroy(): void {

}
ngOnInit(): void {
  this.LoadData();
  this.LoadDataAccessprivilege();
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

LoadDataAccessprivilege(){
  const that = this;

  this.dtOptionsAccessPrivilege = {
    pagingType: 'full_numbers',
    pageLength: 10,
    serverSide: true,
    processing: true,
    searching: false,
    ajax: (dataTablesParameters: any, callback) => {
      this.http
      .get('ModuleFeature').subscribe(resp => that.userPrivilegeList = this.dataTableService.datatableMap(resp,callback,1));
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

  loadRole() {
    this.http.paginatedPost('role/paginated', 100, 1, {}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<role>;
      this.rolesDropdown = convertedResp.items;
    })
  }
  loadModule(){
    //UserRoleAccessPrivilege
    this.http.get("module/all").subscribe(resp => {
      let response = resp as ModuleList[];
      this.modules = response;
    })
  }
  loadDropDownValues(){
    this.loadRole();
    this.loadModule();
  }
  onChangRole(e:any){
    console.log(e.value)
  }
}
