import { formatDate } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Audit } from 'src/app/core/interfaces/branch-audit/audit.interface';
import { AuditPlanCode } from 'src/app/core/interfaces/branch-audit/auditPlanCode.interface';
import { commonValueAndType } from 'src/app/core/interfaces/configuration/commonValueAndType.interface';
import { country } from 'src/app/core/interfaces/configuration/country.interface';
import { Branch } from 'src/app/core/interfaces/branch-audit/branch.interface';
import { AuditSchedule } from 'src/app/core/interfaces/branch-audit/auditSchedule.interface';
import { AuditScheduleResponse } from 'src/app/core/interfaces/branch-audit/auditScheduleResponse.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';
import {AlertService} from '../../../../core/services/alert.service';
import { User } from 'src/app/core/interfaces/security/user-registration.interface';
import { AuditScheduleParticipant } from 'src/app/core/interfaces/branch-audit/auditScheduleParticipant.interface';
import { AuditScheduleBranch } from 'src/app/core/interfaces/branch-audit/auditScheduleBranch.interface';

@Component({
  selector: 'app-audit-schedule',
  templateUrl: './audit-schedule.component.html',
  styleUrls: ['./audit-schedule.component.scss']
})
export class AuditScheduleComponent implements OnInit {
  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings = {};
  dataTableService: DatatableService = new DatatableService();
  auditSchedules: AuditSchedule[] = [];
  formService: FormService = new FormService();
  auditScheduleCreateForm: FormGroup;
  auditSearchForm: FormGroup;
  countries: country[] = [];
  branches: Branch[] = [];
  auditTypes: commonValueAndType[] = [];
  auditIds: commonValueAndType | undefined;
  auditPlanCodes: AuditPlanCode [] = [];
  paramId:string ='';
  auditCreationId:string='';
  users: User[]=[];
  auditScheduleParticipants: AuditScheduleParticipant []=[];

  constructor(private http: HttpService, private fb: FormBuilder,  private activateRoute: ActivatedRoute, private AlertService: AlertService,private router: Router) {
    this.auditScheduleCreateForm = this.fb.group({
      id: [''],
      auditTypeId: [''],
      countryId: [''],
      auditId: [''],
      auditPeriodFrom: [''],
      auditPeriodTo: [''],
      scheduleStartDate:[''],
      scheduleEndDate:[''],
      executionStatusId:[''],
      branchList:['',[Validators.required]],
      approverList:['',[Validators.required]],
      teamLeaderList:['',[Validators.required]],
      auditorList:['',[Validators.required]]
      
    })

    this.auditSearchForm = this.fb.group({
      searchText:['']
    })
   }

  ngOnInit(): void {
   this.paramId = this.activateRoute.snapshot.queryParams['id'];
   this.LoadData();
   this.LoadCountry();
   this.LoadAuditType();
   this.LoadUser();
    
  }
  LoadData() {
    const that = this;
    
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      serverSide: true,
      processing: true,
      searching: false,
      ordering:false,
      ajax: (dataTablesParameters: any, callback) => {
        this.http
          .paginatedPost(
            'AuditSchedule/paginated',dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1),{"scheduleId": this.auditSearchForm.value.searchText}
          ).subscribe(resp => that.auditSchedules = this.dataTableService.datatableMap(resp,callback));
      },
    };
   // console.log(this.auditSchedules)
  }
  OnRowClick(id:string){
    console.log(id)
    this.router.navigate(['branch-audit/schedule-view'], {queryParams: {id:id}});
  }

  onSubmit(modalId:any):void{
    // console.log(this.auditScheduleForm.getRawValue())
 
     const localmodalId = modalId;
     let auditParticipantList: AuditScheduleParticipant[] = [];
     let auditBranchList: AuditScheduleBranch[] = [];
 
     if (this.auditScheduleCreateForm.valid) {  
 
       let branches: AuditScheduleBranch[] = this.auditScheduleCreateForm.value.branchList as AuditScheduleBranch[];
       if (Array.isArray(branches)) {
         branches.forEach(function (value) {
           let branch: AuditScheduleBranch = { auditScheduleId : null as any, branchId: value.toString()}
           auditBranchList.push(branch);
         }); 
       }
 
       let approvers: AuditScheduleParticipant[] = this.auditScheduleCreateForm.value.approverList as AuditScheduleParticipant[];
       if (Array.isArray(approvers)) {
         approvers.forEach(function (value) {
           let user: AuditScheduleParticipant = { auditScheduleId :null as any, userId: value.toString(),commonValueParticipantId:1}
           auditParticipantList.push(user);
         }); 
       }
       let teamLeaders: AuditScheduleParticipant[] = this.auditScheduleCreateForm.value.teamLeaderList as AuditScheduleParticipant[];
       if (Array.isArray(teamLeaders)) {
         teamLeaders.forEach(function (value) {
           let user: AuditScheduleParticipant = { auditScheduleId : null as any, userId: value.toString(),commonValueParticipantId:2}
           auditParticipantList.push(user);
         }); 
       }
       let auditors: AuditScheduleParticipant[] = this.auditScheduleCreateForm.value.auditorList as AuditScheduleParticipant[];
       if (Array.isArray(auditors)) {
         auditors.forEach(function (value) {
           let user: AuditScheduleParticipant = { auditScheduleId : null as any, userId: value.toString(),commonValueParticipantId:3}
           auditParticipantList.push(user);
         }); 
       }
       const auditScheudleFormValue = this.auditScheduleCreateForm.getRawValue();
       const RequestModelForSchedule = {
         
         id:  null as any,
         auditCreationId: this.auditCreationId,
         scheduleStartDate: auditScheudleFormValue.scheduleStartDate,   
         scheduleEndDate: auditScheudleFormValue.scheduleEndDate,
         auditScheduleParticipants : auditParticipantList,
         auditScheduleBranch : auditBranchList
         
       };
       console.log(RequestModelForSchedule);
       this.http.post('AuditSchedule',RequestModelForSchedule).subscribe(x=>{
           this.formService.onSaveSuccess(localmodalId,this.datatableElement);
           this.AlertService.success('Audit Schedule Saved Successful');
       });
     }
   }

  edit(modalId:any, id:string):void {
    const localmodalId = modalId;
    console.log(id)
    // this.http
    //   .getById('scheduel',id)
    //   .subscribe(res => {
    //       const auditScheduleResponse = res as AuditScheduleResponse;
    //       this.auditScheduleCreateForm.setValue({id : auditScheduleResponse.id,  auditName: auditScheduleResponse.auditName, year:auditScheduleResponse.year, auditTypeId: auditScheduleResponse.auditTypeId, planId: auditScheduleResponse.planId, auditId: auditScheduleResponse.auditId, 
    //         auditPeriodFrom: formatDate(auditScheduleResponse.scheduleStartDate, 'yyyy-MM-dd', 'en'),
    //         auditPeriodTo: formatDate(auditScheduleResponse.scheduleEndDate, 'yyyy-MM-dd', 'en')});
    //   });
      localmodalId.visible = true;
  }

  getAuditById():void {
    this.http
      .getById('audit',this.paramId)
      .subscribe(res => {
          const auditResponse = res as Audit;
          this.auditScheduleCreateForm.setValue({id:'', countryId : auditResponse.countryId, auditTypeId: auditResponse.auditTypeId, auditId: auditResponse.auditId, 
            auditPeriodFrom: formatDate(auditResponse.auditPeriodFrom, 'yyyy-MM-dd', 'en'),
            auditPeriodTo: formatDate(auditResponse.auditPeriodTo, 'yyyy-MM-dd', 'en'),
            scheduleStartDate: '',
            scheduleEndDate: '',
            branchList:'',
            approverList:'',
            teamLeaderList:'',
            auditorList:''});
            
            this.auditCreationId=auditResponse.id;

            this.http.get('commonValueAndType/getBranch?countryId='+auditResponse.countryId +'&pageNumber=1&pageSize=10000').subscribe(resp => {
              let convertedResp = resp as paginatedResponseInterface<Branch>;
              this.branches = convertedResp.items;
            })

      });
      this.disabledInputField();
  }

  LoadUser() {
    this.http.paginatedPost('userlist/Paginated', 100, 1, {"userName": "","employeeName": "","userRole": ""}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<User>;
      this.users = convertedResp.items;
    })
  }
  LoadCountry() {
    this.http.paginatedPost('country/paginated', 100, 1, {}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<country>;
      this.countries = convertedResp.items;    
    })
  }
  
  LoadAuditType() {
    this.http.get('commonValueAndType/audittype').subscribe(resp => {
      let convertedResp = resp as commonValueAndType[];
      this.auditTypes = convertedResp;
    })
  }
  
  search(){
     this.dataTableService.redraw(this.datatableElement);
   }

 
  disabledInputField(){
    this.auditScheduleCreateForm.controls['auditTypeId'].disable();
    this.auditScheduleCreateForm.controls['auditId'].disable();
    this.auditScheduleCreateForm.controls['countryId'].disable();
    this.auditScheduleCreateForm.controls['auditPeriodFrom'].disable();
    this.auditScheduleCreateForm.controls['auditPeriodTo'].disable();
 }

}
