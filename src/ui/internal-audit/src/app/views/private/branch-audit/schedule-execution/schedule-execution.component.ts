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
  auditScheduleExecutionViewForm:FormGroup;
  auditScheduleExecutionMenuForm:FormGroup;
  notificationToAuditeeForm:FormGroup;
  planningAndScopingForm:FormGroup;
  selectedScheduleParticipant: AuditScheduleParticipantResponse []=[];
  users: User[]=[];
  notificationToAuditee:boolean=false
  noOfBranchChecklist:number=0
  noOfSampleTestTemplate:number=0
  auditScheduleExecutionViewSelected:boolean=true;
  notificationToAuditeeSelected:boolean=false;
  planningAndScopingSelected:boolean=false;
  
  constructor(private http: HttpService, private fb: FormBuilder, private AlertService: AlertService, private router: Router, private activateRoute: ActivatedRoute) { 
    this.auditScheduleExecutionViewForm = this.fb.group({
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
    this.notificationToAuditeeForm = this.fb.group({
      auditId: [''],
      riskOwnerList:[''],
      ccList: [''],
      bccList: [''],      
      othersList:['']
    })
    this.planningAndScopingForm = this.fb.group({
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
    this.auditScheduleExecutionMenuForm=this.fb.group({
      btn_Info:[],
      ddl_1:['1'],
      ddl_2:['1']
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
        
        this.auditScheduleExecutionViewForm.patchValue( 
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
    this.http.getById('audit',id).subscribe(res => {
        const auditResponse = res as Audit;
        this.auditName=auditResponse.auditName;
    });
  }
  gotoView(){
    this.auditScheduleExecutionViewSelected=true;
    this.notificationToAuditeeSelected=false;
    this.planningAndScopingSelected=false;
  }
  changeDDL_1Form(){
    var selectedValue= this.auditScheduleExecutionMenuForm.value.ddl_1;
    if(selectedValue==1){
      this.planningAndScopingSelected=true;
      this.notificationToAuditeeSelected=false;
      this.auditScheduleExecutionViewSelected=false;
    }
    if(selectedValue==2){
      this.planningAndScopingSelected=false;
      this.notificationToAuditeeSelected=true;
      this.auditScheduleExecutionViewSelected=false;
    }
  }
  changeDDL_2Form(){
    
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
