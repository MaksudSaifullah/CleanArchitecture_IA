import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Audit } from 'src/app/core/interfaces/branch-audit/audit.interface';
import { AuditScheduleParticipantResponse, AuditScheduleResponse, User } from 'src/app/core/interfaces/branch-audit/auditScheduleResponse.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { HttpService } from 'src/app/core/services/http.service';
import { AlertService } from '../../../../core/services/alert.service';


@Component({
  selector: 'app-schedule-execution',
  templateUrl: './schedule-execution.component.html',
  styleUrls: ['./schedule-execution.component.scss']
})
export class ScheduleExecutionComponent implements OnInit {
  scheduleId:any;
  auditId:string='';
  auditName:string='';
  auditCreationId:string='';
  auditType:string='';
  auditFromDate:any;
  auditToDate:any;
  scheduleParamId:string='';
  auditParamId:string='';
  auditScheduleExecutionView:FormGroup;
  selectedScheduleParticipant: AuditScheduleParticipantResponse []=[];
  users: User[]=[];
  notificationToAuditee:boolean=false
  noOfBranchChecklist:number=0
  noOfSampleTestTemplate:number=0
  auditScheduleExecutionViewSelected:boolean=true;
  
  constructor(private http: HttpService, private fb: FormBuilder, private AlertService: AlertService, private router: Router, private activateRoute: ActivatedRoute) { 
    this.auditScheduleExecutionView = this.fb.group({
      id: [''],
      auditTypeId: [''],
      countryId: [''],
      auditId: [''],
      scheduleId:[''],
      auditPeriodFrom: [''],
      auditPeriodTo: [''],      
      teamLeaderList:[''],
      auditorList:[''], 
    })
  }

  ngOnInit(): void {
    this.scheduleParamId=this.activateRoute.snapshot.params['scheduleParamId']; 
    this.auditParamId=this.activateRoute.snapshot.params['auditParamId']; 
    this.GetScheduleById(this.scheduleParamId);
    this.GetAuditById(this.auditParamId);
    this.LoadUser();
    
  }

  LoadUser() {
    this.http.paginatedPost('userlist/Paginated', 100, 1, {"userName": "","employeeName": "","userRole": ""}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<User>;
      this.users = convertedResp.items;
    })
  }
  GetScheduleById(id:string){
    this.http
    .post('AuditSchedule/getScheduleId', {auditSchduleId : id})
    .subscribe((res:any) => {
        const auditScheduleResponse = res[0] as AuditScheduleResponse;
        this.selectedScheduleParticipant =auditScheduleResponse.auditScheduleParticipants;
        this.scheduleId=auditScheduleResponse.scheduleId;
        this.auditId=auditScheduleResponse.auditCreation.auditId;
        this.auditFromDate=formatDate(auditScheduleResponse.auditCreation?.auditPeriodFrom, 'yyyy-MM-dd', 'en'),
        this.auditToDate=formatDate(auditScheduleResponse.auditCreation?.auditPeriodTo, 'yyyy-MM-dd', 'en'),
        
        this.auditScheduleExecutionView.patchValue( 
          {
            auditId:auditScheduleResponse.auditCreation?.auditId, 
            auditTypeId: auditScheduleResponse.auditCreation?.auditTypeId,
            scheduleId: id,
            auditPeriodFrom: formatDate(auditScheduleResponse.auditCreation?.auditPeriodFrom, 'yyyy-MM-dd', 'en'),
            auditPeriodTo: formatDate(auditScheduleResponse.auditCreation?.auditPeriodTo, 'yyyy-MM-dd', 'en'),
         });
        
      });
  }
  GetAuditById(id:string){
    this.http
    .getById('audit',id)
    .subscribe(res => {
        const auditResponse = res as Audit;
        this.auditName=auditResponse.auditName;
    });
  }
  changeForm(){
    
  }
  isSelectedTeamLeader(id:any){
    for (let user of this.selectedScheduleParticipant){
      if(user.userId==id && user.commonValueParticipantId==2){
        return true;
      }
     }
     return false;
  }
  isSelectedAuditor(id:any){
    for (let user of this.selectedScheduleParticipant){
      if(user.userId==id && user.commonValueParticipantId==3){
        return true;
      }
     }
     return false;
  }

}
