import { Component, Input, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { role } from 'src/app/core/interfaces/security/role.interface';
import { ModuleList, RoleBody, RoleSelectedList, RoleSelectedListResponse, UserRoleAccessPrivilege } from 'src/app/core/interfaces/security/user-role-accessprivilege.interface';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';
import { AlertService } from '../../../../core/services/alert.service';

@Component({
  selector: 'app-user-role',
  templateUrl: './user-role.component.html',
  styleUrls: ['./user-role.component.scss']
})
export class UserRoleComponent implements OnInit {

  @Input('tabPaneIdx')
  tabIndex!: string;

  @ViewChildren(DataTableDirective)
  dtElements: QueryList<DataTableDirective> | undefined;
  // datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings[] = [];
  roles: role[] = [];
  userPrivilegeList: UserRoleAccessPrivilege[] = [];
  rolesDropdown: role[] = [];
  modules: ModuleList[] = [];
  roleForm: FormGroup;
  privilegeForm: FormGroup;
  formService: FormService = new FormService();
  dataTableService: DatatableService = new DatatableService();
  dtTrigger: Subject<any> = new Subject<any>();
  featureId: any = '00000000-0000-0000-0000-000000000000';
  //featureId:any='684852df-0deb-ec11-b3b0-00155d610b18';
  roleSelected: boolean = false;
  rolewisePrivilegelist:RoleSelectedListResponse={};
  roleUserSelectionMaster:RoleBody[]=[];

  constructor(private http: HttpService, private fb: FormBuilder, private AlertService: AlertService) {
    this.loadDropDownValues();
    this.roleForm = this.fb.group({
      id: [''],
      name: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]],
      description: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      isActive: [''],
    })

    this.privilegeForm = this.fb.group({
      id: [''],
      role: [null, [Validators.required]],
      module: [null, [Validators.required]],

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

    this.dtOptions[1] = {
      pagingType: 'full_numbers',
      pageLength: 10,
      serverSide: true,
      processing: true,
      searching: false,
      ajax: (dataTablesParameters: any, callback) => {
        this.http
          .paginatedPost(
            'role/paginated', dataTablesParameters.length, ((dataTablesParameters.start / dataTablesParameters.length) + 1), {}
          ).subscribe(resp => that.roles = this.dataTableService.datatableMap(resp, callback));
      },
    };

    // const that = this;

  }

  LoadDataAccessprivilege() {
    const that = this;

    this.dtOptions[0] = {
      pagingType: 'full_numbers',
      pageLength: 10,
      serverSide: true,
      processing: true,
      searching: false,
      ajax: (dataTablesParameters: any, callback) => {
        this.http
          .get('ModuleFeature?featureId=' + this.featureId).subscribe(resp => that.userPrivilegeList = this.dataTableService.datatableMap(resp, callback, 'ef'));
      },
    };
  }
  onSubmit(modalId: any): void {
    const localmodalId = modalId;
    if (this.roleForm.valid) {
      if (this.formService.isEdit(this.roleForm.get('id') as FormControl)) {
        this.http.put('role', this.roleForm.value, null).subscribe(x => {
          this.formService.onSaveSuccess(localmodalId, this.ReloadAllDataTable());
          this.AlertService.success('User Role Updated Successful');

        });
      }
      else {
        this.http.post('role', this.roleForm.value).subscribe(x => {
          this.formService.onSaveSuccess(localmodalId, this.ReloadAllDataTable());
          this.AlertService.success('User Role Saved Successful');
        });
      }
    }
  }

  edit(modalId: any, role: any): void {
    const localmodalId = modalId;
    this.http
      .getById('role', role.id)
      .subscribe(res => {
        const roleResponse = res as role;
        console.log(roleResponse);
        this.roleForm.setValue({ id: roleResponse.id, name: roleResponse.name, description: roleResponse.description, isActive: roleResponse.isActive });
      });
    localmodalId.visible = true;
  }
  delete(id: string) {
    const that = this;
    this.AlertService.confirmDialog().then(res => {
      if (res.isConfirmed) {
        this.http.delete('role/' + id, {}).subscribe(response => {
          this.AlertService.successDialog('Deleted', 'Role deleted successfully.');
          this.ReloadAllDataTable();
        })
      }
    });
  }
  reset() {
    this.roleForm.reset();
  }

  loadRole() {
    this.http.paginatedPost('role/paginated', 100, 1, {}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<role>;
      this.rolesDropdown = convertedResp.items;
    })
  }
  loadModule() {
    //UserRoleAccessPrivilege
    this.http.get("module/all").subscribe(resp => {
      let response = resp as ModuleList[];
      this.modules = response;
    })
  }
  loadDropDownValues() {
    this.loadRole();
    this.loadModule();
  }
  onChangRole(e: any) {
    e.value.length > 30 ? this.roleSelected = true : this.roleSelected = false;
    if (this.roleSelected && (this.privilegeForm?.value.module == null ||this.privilegeForm?.value.module == 'null'  )) {     
      this.privilegeForm.patchValue({module:'00000000-0000-0000-0000-000000000000'}); 
      this.dataTableService.redraw(this.dtElements?.get(1));   
    }
    if(this.roleSelected){
      this.loadCheckboxList(this.privilegeForm?.value.role);
    }
  }
  onChangModule(e: any) {   
    console.log('checking items'); 
    console.log(this.roleUserSelectionMaster); 
    console.log('checking endddddddddddddddddddddd'); 
    if(e.value != 'null' && (this.privilegeForm?.value.role != 'null')){    
      this.roleSelected = true;  
      this.featureId = e.value;     
      this.dataTableService.redraw(this.dtElements?.get(1));
      this.loadCheckboxList(this.privilegeForm?.value.role);
    }else{
      this.roleSelected = false;
    }
  }
  loadCheckboxList(roleid:any) {
    let requestModel:RoleSelectedList={pageNumber:1,pageSize:1000,roleId:roleid,searchTerm:''};  
    this.http.post('ModulewiseRolePrivilege/paginatedByRoleId',requestModel).subscribe(resp => {
      let convertedResp = resp as RoleSelectedListResponse;
      this.rolewisePrivilegelist = convertedResp;     
    });
  }

  isChecked(type:any,moduleId:any,featureId:any) {
    let dataFiltered = this.rolewisePrivilegelist.items?.find(x=>x.auditFeatureId?.toUpperCase()==featureId.toUpperCase() && x.auditModuleId?.toUpperCase()==moduleId.toUpperCase());
    let result=false;
    let isview=false;
    let iscreate=false;
    let isedit=false;
    let isDelete=false;
    let roleid=this.privilegeForm.value?.role;
   if(type == 'view'){
    result= dataFiltered?.isView == undefined ? false:true;   
    isview=true;
   }
   else if(type =='create'){
    result= dataFiltered?.isCreate == undefined ? false:true;    
    iscreate=true;
   }else if(type == 'edit'){
    let result= dataFiltered?.isEdit == undefined ? false:true;
    isedit=true;
   }else{
    let result= dataFiltered?.isDelete == undefined ? false:true;
    isDelete=true;
   }
   
   if(result){
    let userselection:RoleBody ={auditFeatureId:featureId,auditModuleId:moduleId,roleId:roleid,isView:isview,isCreate:iscreate,isDelete:isDelete,isEdit:isedit};
    let ifFound = this.roleUserSelectionMaster.find(x=>x.auditFeatureId?.toUpperCase()==featureId.toUpperCase() && x.auditModuleId?.toUpperCase() ==moduleId.toUpperCase() && x.roleId?.toUpperCase()==roleid.toUpperCase());
    if(ifFound){
      let index = this.roleUserSelectionMaster.indexOf(ifFound);
     if(isDelete){
      this.roleUserSelectionMaster[index].isDelete=isDelete;
     }
     else if(iscreate){
      this.roleUserSelectionMaster[index].isCreate=iscreate;
     }
     else if(isview){
      this.roleUserSelectionMaster[index].isEdit=isedit;
     }
     else {
      this.roleUserSelectionMaster[index].isDelete=isDelete;
     }
     
    }else{
      this.roleUserSelectionMaster.push(userselection);
    }
   }
    return result;
  }
  private ReloadAllDataTable() {
    this.dtElements?.forEach((dtElement: DataTableDirective, index: number) => {
      this.dataTableService.redraw(dtElement);
    });
  }
}


