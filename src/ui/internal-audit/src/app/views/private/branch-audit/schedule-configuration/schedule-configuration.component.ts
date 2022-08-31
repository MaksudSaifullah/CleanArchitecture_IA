import { Component, OnInit, ViewChild } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Branch } from 'src/app/core/interfaces/branch-audit/branch.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { User } from 'src/app/core/interfaces/security/user-registration.interface';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';
import { AlertService } from '../../../../core/services/alert.service';
import { ScheduleRiskOwner } from 'src/app/core/interfaces/branch-audit/scheduleOwner.interface';
import { ScheduleActionOwner } from 'src/app/core/interfaces/branch-audit/scheduleOwner.interface';
import { ScheduleSetDate } from 'src/app/core/interfaces/branch-audit/scheduleOwner.interface';
import { ScheduleRiskOwnerResponse } from 'src/app/core/interfaces/branch-audit/scheduleOwner.interface';
import { ScheduleActionOwnerResponse } from 'src/app/core/interfaces/branch-audit/scheduleOwner.interface';
import { CommonResponseInterface } from 'src/app/core/interfaces/common-response.interface';

@Component({
  selector: 'app-schedule-configuration',
  templateUrl: './schedule-configuration.component.html',
  styleUrls: ['./schedule-configuration.component.scss']
})
export class ScheduleConfigurationComponent implements OnInit {
  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings[] = [];
  dataTableService: DatatableService = new DatatableService();
  countryIdGlobal: any = '00000000-0000-0000-0000-000000000000';
  brancheWithRiskOwner: Branch[] = [];
  brancheWithActionOwner: Branch[] = [];
  scheduleConfigRiskOwnerForm: FormGroup;
  scheduleConfigActionOwnerForm: FormGroup;
  scheduleConfigSetDateForm: FormGroup;
  users: User[]=[];
  formService: FormService = new FormService();
  scheduleParamId: string='';
  auditParamId: string='';

  constructor(private http: HttpService, private fb: FormBuilder, private AlertService: AlertService, private router: Router, private activateRoute: ActivatedRoute) {
    this.scheduleConfigRiskOwnerForm = this.fb.group({
      id: [''],
      branchId: [null],
      riskOwnerId:['',[Validators.required]],
    })
    this.scheduleConfigActionOwnerForm = this.fb.group({
      id: [''],
      branchId: [null],
      actionOwnerId: ['']
    })
    this.scheduleConfigSetDateForm = this.fb.group({
      id: [''],
      //scheduleId: [null],
      auditInitiationDate: [''],
      planningAndScopingStartDate: [''],
      planningAndScopingEndDate: [''],
      fieldWorkStartDate: [''],
      fieldWorkEndDate: [''],
    })
    
  }
  ngOnDestroy(): void {

  }
  ngOnInit(): void {
    this.scheduleParamId=this.activateRoute.snapshot.queryParams['sId']; 
    this.auditParamId=this.activateRoute.snapshot.queryParams['aId']; 
    this.LoadDataRiskOwner();
    this.LoadDataActionOwner();
    this.LoadUser();
   // this.LoadBranch();
  }

  LoadUser() {
    this.http.paginatedPost('userlist/Paginated', 100, 1, {"userName": "","employeeName": "","userRole": ""}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<User>;
      this.users = convertedResp.items;
    })
  }
  RedirectToScheduleView(){
    this.router.navigate(['branch-audit/schedule-view'],{ queryParams: { sId: this.scheduleParamId,aId:this.auditParamId } });
  }
//   LoadBranch(){
//   this.http.get('commonValueAndType/getBranch?countryId='+'414d221c-0df6-ec11-b3b0-00155d610b18' +'&pageNumber=1&pageSize=10000').subscribe(resp => {
//     let convertedResp = resp as paginatedResponseInterface<Branch>;
//     this.brancheWithRiskOwner = convertedResp.items;
//     this.countryIdGlobal = '414d221c-0df6-ec11-b3b0-00155d610b18'
//     this.dataTableService.redraw(this.datatableElement);
//    })
//  }

//---------------RISK OWNER START---------------
  LoadDataRiskOwner() {
    const that = this;
    this.dtOptions[0] = {
      pagingType: 'full_numbers',
      pageLength: 10,
      serverSide: true,
      processing: true,
      searching: false,
      ordering: false,
      ajax: (dataTablesParameters: any, callback) => {
        this.http.get('commonValueAndType/getBranch?countryId=414d221c-0df6-ec11-b3b0-00155d610b18&pageNumber=1&pageSize=10')
        .subscribe(resp => that.brancheWithRiskOwner = this.dataTableService.datatableMap(resp, callback));
      },

    };
  }

  onSubmitRiskOwner(modalId:any){
    const localmodalId = modalId;
    let scheduleRiskOwnerList: ScheduleRiskOwner[] = [];
 
    if (this.scheduleConfigRiskOwnerForm.valid) {  

      let riskOwners: ScheduleRiskOwner[] = this.scheduleConfigRiskOwnerForm.value.riskOwnerList as ScheduleRiskOwner[];
      if (Array.isArray(riskOwners)) {
        riskOwners.forEach(function (value) {
          let riskOwner: ScheduleRiskOwner = { id : null as any, scheduleId:'', branchId: '',userId:''}
          scheduleRiskOwnerList.push(riskOwner);
        }); 
      }
      const scheduleConfigRiskOwnerFormValue = this.scheduleConfigRiskOwnerForm.getRawValue();
      const RequestModelForRiskOwner = {
        
        id:  null as any,
        // to do
        
      };
      console.log(RequestModelForRiskOwner);
      // this.http.post('AuditSchedule',RequestModelForRiskOwner).subscribe(x=>{
      //     this.formService.onSaveSuccess(localmodalId,this.datatableElement);
      //     this.AlertService.success('Risk Owner Saved Successful');
      // });
      
      if(this.formService.isEdit(this.scheduleConfigRiskOwnerForm.get('id') as FormControl)){
        this.http.put('scheduleConfiguration',this.scheduleConfigRiskOwnerForm.value,null).subscribe(x=>{
          let resp = x as CommonResponseInterface;
            if(resp.success){
              this.formService.onSaveSuccess(localmodalId,this.datatableElement);
              this.AlertService.success('Risk Owner Saved Successful');
            }
            else{
              this.AlertService.errorDialog('Unsuccessful', 'Duplicate Value ');
            }

        });
      }
      else{
       
        this.http.post('scheduleConfiguration',this.scheduleConfigRiskOwnerForm.value).subscribe(x=>{
          let resp = x as CommonResponseInterface;
            if(resp.success){
              this.formService.onSaveSuccess(localmodalId,this.datatableElement);
              this.AlertService.success('Risk Owner Saved Successful');
            }
            else{
              this.AlertService.errorDialog('Unsuccessful', 'Duplicate Value ');
            }
        });
      }

    }
  }
  
  editRiskOwner(modalId:any, config:any):void {
    const localmodalId = modalId;
   
    this.http
      .getById('scheduleConfiguration',config.id)
      .subscribe(res => {
          const response = res as ScheduleRiskOwnerResponse;
          this.scheduleConfigRiskOwnerForm.setValue({id : response.id, branchId : response.branchId, scheduleId: response.scheduleId, riskOwnerList: response.riskOwners});
      });
      localmodalId.visible = true;
  }

 

//---------------RISK OWNER END---------------

//---------------ACTION OWNER START---------------
  LoadDataActionOwner() {
    console.log('skdflskdf')
    const that = this;
    this.dtOptions[1] = {
      pagingType: 'full_numbers',
      pageLength: 10,
      serverSide: true,
      processing: true,
      searching: false,
      ordering: false,
      ajax: (dataTablesParameters: any, callback) => {
        this.http.get('commonValueAndType/getBranch?countryId=414d221c-0df6-ec11-b3b0-00155d610b18&pageNumber=1&pageSize=10')
        .subscribe(resp => that.brancheWithActionOwner = this.dataTableService.datatableMap(resp, callback));
      },
    };
  }

  onSubmitActionOwner(modalId:any){
    const localmodalId = modalId;
      let scheduleActionOwnerList: ScheduleActionOwner[] = [];
  
      if (this.scheduleConfigActionOwnerForm.valid) {  

        let riskOwners: ScheduleActionOwner[] = this.scheduleConfigActionOwnerForm.value.riskOwnerList as ScheduleActionOwner[];
        if (Array.isArray(riskOwners)) {
          riskOwners.forEach(function (value) {
            let riskOwner: ScheduleActionOwner = { id : null as any, scheduleId:'', branchId: '',userId:''}
            scheduleActionOwnerList.push(riskOwner);
          }); 
        }
        const scheduleConfigActionOwnerFormValue = this.scheduleConfigActionOwnerForm.getRawValue();
        const RequestModelForActionOwner = {
          
          id:  null as any,
          // to do
          
        };
        console.log(RequestModelForActionOwner);
      
        if(this.formService.isEdit(this.scheduleConfigActionOwnerForm.get('id') as FormControl)){
          this.http.put('scheduleConfiguration',this.scheduleConfigActionOwnerForm.value,null).subscribe(x=>{
            let resp = x as CommonResponseInterface;
              if(resp.success){
                this.formService.onSaveSuccess(localmodalId,this.datatableElement);
                this.AlertService.success('Action Owner Saved Successful');
              }
              else{
                this.AlertService.errorDialog('Unsuccessful', 'Duplicate Value ');
              }

          });
        }
        else{
        
          this.http.post('scheduleConfiguration',this.scheduleConfigActionOwnerForm.value).subscribe(x=>{
            let resp = x as CommonResponseInterface;
              if(resp.success){
                this.formService.onSaveSuccess(localmodalId,this.datatableElement);
                this.AlertService.success('Action Owner Saved Successful');
              }
              else{
                this.AlertService.errorDialog('Unsuccessful', 'Duplicate Value ');
              }
          });
        }


      }
  }

  editActionOwner(modalId:any, config:any):void {
    const localmodalId = modalId; 
    this.http
      .getById('scheduleConfiguration',config.id)
      .subscribe(res => {
          const response = res as ScheduleActionOwnerResponse;
          this.scheduleConfigRiskOwnerForm.setValue({id : response.id, branchId : response.branchId, scheduleId: response.scheduleId, actionOwnerList: response.actionOwners});
      });
      localmodalId.visible = true;
  }

//---------------ACTION OWNER END---------------

//---------------SET DATE START---------------
onSubmitSetDate(modalId:any){
  const localmodalId = modalId;
  if(this.scheduleConfigSetDateForm.valid){
    if(this.formService.isEdit(this.scheduleConfigSetDateForm.get('id') as FormControl)){
      this.http.put('scheduleConfiguration',this.scheduleConfigSetDateForm.value,null).subscribe(x=>{
        let resp = x as CommonResponseInterface;
          if(resp.success){
            this.formService.onSaveSuccess(localmodalId,this.datatableElement);
            this.AlertService.success('Set Date Saved Successful');
          }
          else{
            this.AlertService.errorDialog('Unsuccessful', 'Duplicate Value ');
          }

      });
    }
    else{
      this.http.post('scheduleConfiguration',this.scheduleConfigSetDateForm.value).subscribe(x=>{
        let resp = x as CommonResponseInterface;
          if(resp.success){
            this.formService.onSaveSuccess(localmodalId,this.datatableElement);
            this.AlertService.success('Set Date Saved Successful');
          }
          else{
            this.AlertService.errorDialog('Unsuccessful', 'Duplicate Value ');
          }
      });
    }
  }

}

editSetDate(modalId:any):void {
  const localmodalId = modalId; 
  this.http
    .getById('scheduleConfiguration',this.scheduleParamId)
    .subscribe(res => {
        const response = res as ScheduleSetDate;
        this.scheduleConfigRiskOwnerForm.setValue({id : response.id, scheduleId : response.scheduleId, auditIniciationDate: response.auditIniciationDate, 
          planningAndScopingStartDate: response.planningAndScopingStartDate,
          planningAndScopingEndDate: response.planningAndScopingEndDate,
          fieldWorkStartDate: response.fieldWorkStartDate,
          fieldWorkEndDate: response.fieldWorkEndDate});
    });
    localmodalId.visible = true;
}

//---------------SET DATE END---------------

}
