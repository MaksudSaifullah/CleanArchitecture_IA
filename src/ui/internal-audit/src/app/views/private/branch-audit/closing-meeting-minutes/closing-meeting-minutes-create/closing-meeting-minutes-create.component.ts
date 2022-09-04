import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuditSchedule } from 'src/app/core/interfaces/branch-audit/auditSchedule.interface';
import { WPAuditScheduleBranch } from 'src/app/core/interfaces/branch-audit/auditScheduleBranch.interface';
import { ClosingMeetingMinutes, ClosingMeetingSubjects } from 'src/app/core/interfaces/branch-audit/closingMeetingMinutes.interface';
import { commonValueAndType } from 'src/app/core/interfaces/configuration/commonValueAndType.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { User } from 'src/app/core/interfaces/security/user-registration.interface';
import { HelperService } from 'src/app/core/services/helper.service';
import { HttpService } from 'src/app/core/services/http.service';
import {AlertService} from '../../../../../core/services/alert.service';

@Component({
  selector: 'app-closing-meeting-minutes-create',
  templateUrl: './closing-meeting-minutes-create.component.html',
  styleUrls: ['./closing-meeting-minutes-create.component.scss']
})
export class ClosingMeetingMinutesCreateComponent implements OnInit {

  cMMForm: FormGroup;
  paramId:string ='';
  auditSchedules: AuditSchedule[] =[];
  closingMeetingMinutes: ClosingMeetingMinutes[] = [];
  wpAuditScheduleBranches : WPAuditScheduleBranch[] = [];
  users: User[]=[];
  closingMeetingSubjects: ClosingMeetingSubjects[] =[];
  
  constructor(private http: HttpService ,private router : Router, private fb: FormBuilder, private activateRoute: ActivatedRoute, private AlertService: AlertService, private helper: HelperService) {
    this.loadDropDownValues();
    this.cMMForm = this.fb.group({
      id : [''],
      meetingMinutesCode: [''],
      scheduleCode:[''],
      auditScheduleBranchId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      meetingMinutesDate: [Date,[Validators.required]],
      meetingMinutesName:  [null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      auditOn: [null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      meetingHeld: [null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      agreedByUserId :  [null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      presentUserId: [null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      appologiesUserId: [null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      
    });
  }


  loadDropDownValues(){
    this.LoadUser();
  }

  ngOnInit(): void {
    this.paramId = 'C09240DA-02DE-4B96-9A61-C9CA8F741C89';
    this.LoadScheduleData(this.paramId);
    this.LoadSubjectMatters();
  }


  async onSubmit(){
 
   
  }


  LoadScheduleData(Id:any):void {
    this.http
      .getById('AuditSchedule',Id)
      .subscribe(res => {
           const scheduleData = res as AuditSchedule;
          let scheduleId = scheduleData.id;
          let countryId = scheduleData.countryId;
          this.GetMeetingMinutesCode(countryId);
           this.LoadBranches(scheduleId);
           this.cMMForm.patchValue({
            scheduleCode: scheduleData.scheduleId
          });
      });
  
  }

  GetMeetingMinutesCode(countryId:any) :void {
    if( countryId !="null"){
      this.http.get('commonValueAndType/idcreation?idcreationValue=11&auditType=1&countryId='+ countryId +'')
    .subscribe(resp => {
      const convertedResp = resp as commonValueAndType;
      this.cMMForm.patchValue({
        meetingMinutesCode : convertedResp.text,
      });
    })
    }
    
  }
  LoadBranches(scheduleId:any) {
    this.http.get('commonValueAndType/getAuditScheduleBranch?ScheduleId='+ scheduleId +'').subscribe(resp => {
      let convertedResp = resp as WPAuditScheduleBranch[];
      this.wpAuditScheduleBranches = convertedResp;  
    })

  }

  LoadUser() {
    this.http.paginatedPost('userlist/Paginated', 100, 1, {"userName": "","employeeName": "","userRole": ""}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<User>;
      this.users = convertedResp.items;
    })
  }

  LoadSubjectMatters(){
    var currentElement: ClosingMeetingSubjects = {
      subjectMatter: "",
      userId: ""
    };
    this.closingMeetingSubjects.push(currentElement);  
    console.log("adddddd", this.closingMeetingSubjects);
  }
  


  addItem() {
    var currentElement: ClosingMeetingSubjects = {
      subjectMatter: "",
      userId: ""
    };
    console.log(currentElement);
      this.closingMeetingSubjects.push(currentElement);
   }
  
   removeItem(index:any) {
    console.log(index);
    var currentElement = this.closingMeetingSubjects[index];  
    this.closingMeetingSubjects.splice(index, 1);
    console.log(this.closingMeetingSubjects);
   }


}
