import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuditSchedule } from 'src/app/core/interfaces/branch-audit/auditSchedule.interface';
import { WPAuditScheduleBranch } from 'src/app/core/interfaces/branch-audit/auditScheduleBranch.interface';
import { ClosingMeetingMinutes } from 'src/app/core/interfaces/branch-audit/closingMeetingMinutes.interface';
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

  
  constructor(private http: HttpService ,private router : Router, private fb: FormBuilder, private activateRoute: ActivatedRoute, private AlertService: AlertService, private helper: HelperService) {
   // this.loadDropDownValues();
    this.cMMForm = this.fb.group({
      id : [''],
      meetingMinutesCode: [''],
      scheduleCode:[''],
      auditScheduleBranchId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      meetingMinutesDate: [Date,[Validators.required]],
      sampleName: [null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      sampleMonthId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      sampleSelectionMethodId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      controlActivityNatureId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      controlFrequencyId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      sampleSizeId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
     
      testingConclusionId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      documentId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      
    });
  }

  ngOnInit(): void {
    this.paramId = 'C09240DA-02DE-4B96-9A61-C9CA8F741C89';
    this.LoadScheduleData(this.paramId);
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
          //this.GetWorkPaperCode(countryId);
           this.LoadBranches(scheduleId);
          //  this.workpaperForm.patchValue({
          //   scheduleCode: scheduleData.scheduleId,
          //   scheduleStartDate: formatDate(scheduleData.scheduleStartDate, 'yyyy-MM-dd', 'en') ,
          //   scheduleEndDate:  formatDate(scheduleData.scheduleEndDate, 'yyyy-MM-dd', 'en') });
      });
  
  }

  LoadBranches(scheduleId:any) {
    this.http.get('commonValueAndType/getAuditScheduleBranch?ScheduleId='+ scheduleId +'').subscribe(resp => {
      let convertedResp = resp as WPAuditScheduleBranch[];
      this.wpAuditScheduleBranches = convertedResp;  
      console.log("ssssssssssssssssssssssssssss",this.wpAuditScheduleBranches);   
      
    })

  }



}
