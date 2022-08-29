import { formatDate } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { AuditScheduleResponse } from 'src/app/core/interfaces/branch-audit/auditScheduleResponse.interface';
import { Branch } from 'src/app/core/interfaces/branch-audit/branch.interface';
import { commonValueAndType } from 'src/app/core/interfaces/configuration/commonValueAndType.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { User } from 'src/app/core/interfaces/security/user-registration.interface';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { HttpService } from 'src/app/core/services/http.service';
import {AlertService} from '../../../../core/services/alert.service';
import { AuditScheduleBranchResponse } from 'src/app/core/interfaces/branch-audit/auditScheduleResponse.interface';
import { AuditScheduleParticipantResponse } from 'src/app/core/interfaces/branch-audit/auditScheduleResponse.interface';
import { AuditType } from 'src/app/core/interfaces/branch-audit/AuditType.interface';


@Component({
  selector: 'app-schedule-view',
  templateUrl: './schedule-view.component.html',
  styleUrls: ['./schedule-view.component.scss']
})
export class ScheduleViewComponent implements OnInit {
  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings = {};
  dataTableService: DatatableService = new DatatableService();
  auditScheduleViewForm: FormGroup;
  branches: Branch[] = [];
  users: User[]=[];
  auditIdGlobal: any = '00000000-0000-0000-0000-000000000000';
  moveToInprogressDefault=true;
  moveToInprogress=false;
  moveToDone=false;
  scheduleParamId: string = '';
  auditParamId: string = '';
  scheduleParamIdFromConfiguration: string = '';
  auditParamIdFromConfiguration: string = '';
  auditTypes: AuditType[] = [];
  selectedScheduleBranch: AuditScheduleBranchResponse[]=[];
  selectedScheduleParticipant: AuditScheduleParticipantResponse []=[];


  constructor(private http: HttpService, private fb: FormBuilder, private AlertService: AlertService, private router: Router,private activateRoute: ActivatedRoute) {
    this.auditScheduleViewForm = this.fb.group({
      id: [''],
      auditTypeId: [''],
      countryId: [''],
      auditId: [''],
      scheduleId:[''],
      auditPeriodFrom: [''],
      auditPeriodTo: [''],
      scheduleStartDate:[''],
      scheduleEndDate:[''],
    //  branchList:[''],
     // approverList:[''],
      teamLeaderList:[''],
      auditorList:['']
      
    })
   }

  ngOnInit(): void {
    this.scheduleParamId = this.activateRoute.snapshot.params['id'];
    this.auditParamId = this.activateRoute.snapshot.params['auditParamId'];
    this.scheduleParamIdFromConfiguration = this.activateRoute.snapshot.queryParams['sId'];
    this.auditParamIdFromConfiguration = this.activateRoute.snapshot.queryParams['aId'];

    this.LoadData();
   // this.LoadBranch();
    this.LoadUser();
    this.LoadAuditType();

    if(this.scheduleParamId!=undefined){
      this.GetScheduleById(this.scheduleParamId);
    }
    if(this.scheduleParamIdFromConfiguration!=undefined){
      this.GetScheduleById(this.scheduleParamIdFromConfiguration);
    }
    
  }
  LoadData() {
    const that = this;
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      serverSide: true,
      processing: true,
      searching: false,
      ordering: false,
      ajax: (dataTablesParameters: any, callback) => {
        // this.http.get('commonValueAndType/getBranch?countryId=' + this.countryIdGlobal + '&pageNumber=1&pageSize=10000')
        // .subscribe(resp => that.selectedScheduleBranch = this.dataTableService.datatableMap(resp, callback));

        this.http
        .post('AuditSchedule/getScheduleId', {auditSchduleId : this.auditIdGlobal})
        .subscribe((res:any) => {
            const auditScheduleResponse = res[0] as AuditScheduleResponse;
           // this.selectedScheduleBranch = auditScheduleResponse.auditScheduleBranch;   
            this.selectedScheduleBranch=  this.dataTableService.datatableMap(res,callback);
        });
      },
    };
  }
  GetScheduleById(id:string){
    this.http
    .post('AuditSchedule/getScheduleId', {auditSchduleId : id})
    .subscribe((res:any) => {
        const auditScheduleResponse = res[0] as AuditScheduleResponse;
        this.selectedScheduleParticipant =auditScheduleResponse.auditScheduleParticipants

        this.auditScheduleViewForm.patchValue( {id : auditScheduleResponse.id,  
                        auditId:auditScheduleResponse.auditCreation?.auditId, 
                        auditTypeId: auditScheduleResponse.auditCreation?.auditTypeId,
                        scheduleId: id,
                        // countryName: auditScheduleResponse.country,
                       //  executionStatusId: auditScheduleResponse[0].executionStatus,
                        auditPeriodFrom: formatDate(auditScheduleResponse.auditCreation?.auditPeriodFrom, 'yyyy-MM-dd', 'en'),
                        auditPeriodTo: formatDate(auditScheduleResponse.auditCreation?.auditPeriodTo, 'yyyy-MM-dd', 'en'),
                        scheduleStartDate: formatDate(auditScheduleResponse.scheduleStartDate, 'yyyy-MM-dd', 'en'),
                        scheduleEndDate: formatDate(auditScheduleResponse.scheduleEndDate, 'yyyy-MM-dd', 'en'),
                        teamLeaderList: auditScheduleResponse.auditScheduleParticipants,
                        auditorList: auditScheduleResponse.auditScheduleParticipants
        });
        this.LoadScheduleBranch(auditScheduleResponse.id);
      });
    
   // this.dataTableService.redraw(this.datatableElement);
    this.disabledInputField();
  }

  LoadUser() {
    this.http.paginatedPost('userlist/Paginated', 100, 1, {"userName": "","employeeName": "","userRole": ""}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<User>;
      this.users = convertedResp.items;
    })
  }
  LoadScheduleBranch(id:any){
    this.http
    .post('AuditSchedule/getScheduleId', {auditSchduleId : id})
    .subscribe((res:any) => {
        const auditScheduleResponse = res[0] as AuditScheduleResponse;
        this.selectedScheduleBranch = auditScheduleResponse.auditScheduleBranch;
        this.dataTableService.redraw(this.datatableElement);
    });
   }
   LoadAuditType() {
    this.http.paginatedPost('audit/paginatedAuditType', 100, 1, {}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<AuditType>;
      this.auditTypes = convertedResp.items;    
    })
  }
  isSelectedTeamLeader(id:any){
    //debugger;
    for (let user of this.selectedScheduleParticipant){
      if(user.userId==id && user.commonValueParticipantId==2){
        return true;
      }
     }
     return false;
  }
  isSelectedAuditor(id:any){
    //debugger;
    for (let user of this.selectedScheduleParticipant){
      if(user.userId==id && user.commonValueParticipantId==3){
        return true;
      }
     }
     return false;
  }


  RedirectToAuditList(){
    this.router.navigate(['branch-audit/audit']);
  }
  RedirectToAuditView(){   
   // this.router.navigate(['branch-audit/audit-view']);
    this.router.navigate(['branch-audit/audit-view'], { queryParams: { id: this.auditParamId!=undefined? this.auditParamId: this.auditParamIdFromConfiguration } });
  }
  RedirectToScheduelConfiguration(){
    this.router.navigate(['branch-audit/schedule-configuration'],{ queryParams: { sId: this.scheduleParamId,aId: this.auditParamId } });
  }
  MoveToInprogressClick(){
    this.moveToInprogressDefault=false;
    this.moveToInprogress=true;
    this.moveToDone=false;
  }
  MoveToDoneClick(){
    this.moveToInprogress=false;
    this.moveToDone=true;
    this.moveToInprogressDefault=false;
  }
  BackToInprogessClick(){
    
    this.moveToInprogress=true;
    this.moveToDone=false;
  }
  disabledInputField(){
    this.auditScheduleViewForm.controls['auditTypeId'].disable();
    this.auditScheduleViewForm.controls['auditId'].disable();
    this.auditScheduleViewForm.controls['countryId'].disable();
    this.auditScheduleViewForm.controls['auditPeriodFrom'].disable();
    this.auditScheduleViewForm.controls['auditPeriodTo'].disable();
    this.auditScheduleViewForm.controls['scheduleId'].disable();
    this.auditScheduleViewForm.controls['scheduleStartDate'].disable();
    this.auditScheduleViewForm.controls['scheduleEndDate'].disable();
 }

}
