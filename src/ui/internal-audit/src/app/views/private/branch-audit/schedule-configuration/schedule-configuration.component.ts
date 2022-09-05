import { Component, OnInit, QueryList, ViewChild } from '@angular/core';
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
import { AuditScheduleOwner } from 'src/app/core/interfaces/branch-audit/scheduleOwner.interface';
import { AuditScheduleOwnerResponse } from 'src/app/core/interfaces/branch-audit/auditScheduleOwnerResponse.interface';
import { RiskOwner } from 'src/app/core/interfaces/branch-audit/auditScheduleOwnerResponse.interface';
import { ActionOwner } from 'src/app/core/interfaces/branch-audit/auditScheduleOwnerResponse.interface';
// import { ScheduleActionOwner } from 'src/app/core/interfaces/branch-audit/scheduleOwner.interface';
// import { ScheduleSetDate } from 'src/app/core/interfaces/branch-audit/scheduleOwner.interface';
// import { ScheduleRiskOwnerResponse } from 'src/app/core/interfaces/branch-audit/scheduleOwner.interface';
// import { ScheduleActionOwnerResponse } from 'src/app/core/interfaces/branch-audit/scheduleOwner.interface';
import { CommonResponseInterface } from 'src/app/core/interfaces/common-response.interface';
import { ScheduledBranch } from 'src/app/core/interfaces/branch-audit/scheduledBranch.interface';
import { Subject } from 'rxjs';
import { BaseResponse } from 'src/app/core/interfaces/common/base-response.interface';

@Component({
  selector: 'app-schedule-configuration',
  templateUrl: './schedule-configuration.component.html',
  styleUrls: ['./schedule-configuration.component.scss']
})
export class ScheduleConfigurationComponent implements OnInit {
  @ViewChild(DataTableDirective)
  //datatableElement: DataTableDirective | undefined;
  dtElements: QueryList<DataTableDirective> | undefined;
  dtOptions: DataTables.Settings[] = [];
  //dataTableService: DatatableService = new DatatableService();
  countryIdGlobal: any = '00000000-0000-0000-0000-000000000000';
  scheduledBranch: ScheduledBranch[] = [];
  auditScheduleRiskOwners: AuditScheduleOwner[]=[];
  auditScheduleActionOwners: AuditScheduleOwner[]=[];
  brancheWithActionOwner: Branch[] = [];
  scheduleConfigRiskOwnerForm: FormGroup;
  scheduleConfigActionOwnerForm: FormGroup;
  scheduleConfigSetDateForm: FormGroup;
  users: User[]=[];
  formService: FormService = new FormService();
  scheduleParamId: string='';
  auditParamId: string='';
  selectedRiskOwner:RiskOwner[]=[];
  selectedActionOwner:ActionOwner[]=[];
  dataTableService: DatatableService = new DatatableService();
  dtTrigger: Subject<any> = new Subject<any>();
  Data: Array<any> = [];

  constructor(private http: HttpService, private fb: FormBuilder, private AlertService: AlertService, private router: Router, private activateRoute: ActivatedRoute) {
    this.scheduleConfigRiskOwnerForm = this.fb.group({
      auditScheduleId: [''],
      branchId: [null],
      riskOwnerList:['',[Validators.required]],
    })
    this.scheduleConfigActionOwnerForm = this.fb.group({
      auditScheduleId: [''],
      branchId: [null],
      actionOwnerList: ['']
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
    this.LoadBranch();
  }
  LoadBranch(){
    this.http.paginatedPost('AuditSchedule/paginatedScheduleBranch', 100, 1, {"scheduleId": this.scheduleParamId }).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<ScheduledBranch>;
      this.scheduledBranch = convertedResp.items;
    })
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
  private ReloadAllDataTable() {
    this.dtElements?.forEach((dtElement: DataTableDirective, index: number) => {
      console.log('dt eletemet '+ dtElement)
      console.log('dt index '+ index)
      this.dataTableService.redraw(dtElement);
    });
  }

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
        this.http
          .paginatedPost(
            'AuditSchedule/paginatedOwner',dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1),{"auditScheduleId": this.scheduleParamId,"ownerTypeId":1}
          ).subscribe(resp => that.auditScheduleRiskOwners = this.dataTableService.datatableMap(resp,callback));
      },

    };
  }

  onSubmitRiskOwner(modalId:any){
    const that=this;
    const localmodalId = modalId;
    let scheduleRiskOwnerList: any [] = [];
 
    if (this.scheduleConfigRiskOwnerForm.valid) {  

      let riskOwners: any [] = this.scheduleConfigRiskOwnerForm.value.riskOwnerList as any;
      console.log(riskOwners)
      if (Array.isArray(riskOwners)) {
        riskOwners.forEach(function (value) {
          let riskOwner = { auditScheduleId : that.scheduleParamId, userId:value, branchId: that.scheduleConfigRiskOwnerForm?.value.branchId,commonValueAuditScheduleRiskOwnerTypetId:1}
          scheduleRiskOwnerList.push(riskOwner);
        }); 
        console.log(scheduleRiskOwnerList);
      }
     
      const RequestModelForRiskOwner = {
        data:  scheduleRiskOwnerList
      };

      this.http.post('AuditSchedule/AuditScheudleConfigurationOwner',RequestModelForRiskOwner).subscribe(x=>{
        console.log('x :'+ x);
        let resp = x as BaseResponse;
        console.log('res '+ resp)
          if(resp.success){
            this.formService.onSaveSuccess(localmodalId,this.ReloadAllDataTable());
            this.AlertService.success('Risk Owner Saved Successful');
          }
          else{
            this.AlertService.errorDialog('Unsuccessful', 'Duplicate Value ');
          }
       
      });

      // this.http.post('AuditSchedule/AuditScheudleConfigurationOwner', RequestModelForRiskOwner).subscribe(x => {

      //   this.formService.onSaveSuccess(localmodalId, this.ReloadAllDataTable());

      //   this.AlertService.success('Audit Plan Saved Successfully');

      // });

    }
  }
  
  editRiskOwner(modalId:any, id:any):void {
    const localmodalId = modalId;
    this.http
      .post('AuditSchedule/AuditScheudleConfigurationOwnerGetByScheduleId',{"auditScheduleId":this.scheduleParamId,"typeId":1})
      .subscribe(res => {
          const response = res as AuditScheduleOwnerResponse;
          this.selectedRiskOwner=response.user;
          console.log('risk owner :' +this.selectedRiskOwner)
          this.scheduleConfigRiskOwnerForm.setValue({auditScheduleId : response.auditScheduleId, branchId : response.branchId,  riskOwnerList: response.user});
      });
      localmodalId.visible = true;
  }

  isSelectedRiskOwner(id:any){
    for (let user of this.selectedRiskOwner){
      if(user.id==id){
        return true;
      }
     }
     return false;
  }

//---------------RISK OWNER END---------------

//---------------ACTION OWNER START---------------
  LoadDataActionOwner() {
    const that = this;
    this.dtOptions[1] = {
      pagingType: 'full_numbers',
      pageLength: 10,
      serverSide: true,
      processing: true,
      searching: false,
      ordering: false,
      ajax: (dataTablesParameters: any, callback) => {
        this.http
          .paginatedPost(
            'AuditSchedule/paginatedOwner',dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1),{"auditScheduleId": this.scheduleParamId,"ownerTypeId":2}
          ).subscribe(resp => that.auditScheduleActionOwners = this.dataTableService.datatableMap(resp,callback));
      },

    };
  }

  onSubmitActionOwner(modalId:any){
    const that=this;
    const localmodalId = modalId;
    let scheduleActionOwnerList: any [] = [];
 
    if (this.scheduleConfigActionOwnerForm.valid) {  

      let actionOwners: any [] = this.scheduleConfigActionOwnerForm.value.actionOwnerList as any;
      if (Array.isArray(actionOwners)) {
        actionOwners.forEach(function (value) {
          let actionOwner = { auditScheduleId : that.scheduleParamId, userId:value, branchId: that.scheduleConfigActionOwnerForm?.value.branchId,commonValueAuditScheduleRiskOwnerTypetId:2}
          scheduleActionOwnerList.push(actionOwner);
        }); 
        console.log(scheduleActionOwnerList);
      }
     
      const RequestModelForActionOwner = {
        data:  scheduleActionOwnerList
      };

      this.http.post('AuditSchedule/AuditScheudleConfigurationOwner',RequestModelForActionOwner).subscribe(x=>{
        let resp = x as CommonResponseInterface;
          if(resp.success){
            this.formService.onSaveSuccess(localmodalId,this.ReloadAllDataTable());
            this.AlertService.success('Action Owner Saved Successful');
          }
          else{
            this.AlertService.errorDialog('Unsuccessful', 'Duplicate Value ');
          }
      });
    }
    //this.dataTableService.redraw(this.datatableElement);
  }

  editActionOwner(modalId:any, config:any):void {
    const localmodalId = modalId;
    this.http
      .post('AuditSchedule/AuditScheudleConfigurationOwnerGetByScheduleId',{"auditScheduleId":this.scheduleParamId,"typeId":2})
      .subscribe(res => {
          const response = res as AuditScheduleOwnerResponse;
          this.selectedActionOwner=response.user;
          console.log('action owner :' +this.selectedActionOwner)
          this.scheduleConfigActionOwnerForm.setValue({auditScheduleId : response.auditScheduleId, branchId : response.branchId,  actionOwnerList: response.user});
      });
      localmodalId.visible = true;
  }

  isSelectedActionOwner(id:any){
    for (let user of this.selectedActionOwner){
      if(user.id==id){
        return true;
      }
     }
     return false;
  }

//---------------ACTION OWNER END---------------

//---------------SET DATE START---------------
onSubmit(){
  // const localmodalId = modalId;
  // if(this.scheduleConfigSetDateForm.valid){
  //   if(this.formService.isEdit(this.scheduleConfigSetDateForm.get('id') as FormControl)){
  //     this.http.put('scheduleConfiguration',this.scheduleConfigSetDateForm.value,null).subscribe(x=>{
  //       let resp = x as CommonResponseInterface;
  //         if(resp.success){
  //           this.formService.onSaveSuccess(localmodalId,this.datatableElement);
  //           this.AlertService.success('Set Date Saved Successful');
  //         }
  //         else{
  //           this.AlertService.errorDialog('Unsuccessful', 'Duplicate Value ');
  //         }

  //     });
  //   }
  //   else{
  //     this.http.post('scheduleConfiguration',this.scheduleConfigSetDateForm.value).subscribe(x=>{
  //       let resp = x as CommonResponseInterface;
  //         if(resp.success){
  //           this.formService.onSaveSuccess(localmodalId,this.datatableElement);
  //           this.AlertService.success('Set Date Saved Successful');
  //         }
  //         else{
  //           this.AlertService.errorDialog('Unsuccessful', 'Duplicate Value ');
  //         }
  //     });
  //   }
  // }

}
onCancel(){

}
editSetDate(modalId:any):void {
  // const localmodalId = modalId; 
  // this.http
  //   .getById('scheduleConfiguration',this.scheduleParamId)
  //   .subscribe(res => {
  //       const response = res as ScheduleSetDate;
  //       this.scheduleConfigRiskOwnerForm.setValue({id : response.id, scheduleId : response.scheduleId, auditIniciationDate: response.auditIniciationDate, 
  //         planningAndScopingStartDate: response.planningAndScopingStartDate,
  //         planningAndScopingEndDate: response.planningAndScopingEndDate,
  //         fieldWorkStartDate: response.fieldWorkStartDate,
  //         fieldWorkEndDate: response.fieldWorkEndDate});
  //   });
  //   localmodalId.visible = true;
}

//---------------SET DATE END---------------

}
