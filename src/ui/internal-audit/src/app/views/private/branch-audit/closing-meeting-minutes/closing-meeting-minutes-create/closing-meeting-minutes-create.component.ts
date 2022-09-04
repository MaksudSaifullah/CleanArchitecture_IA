import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuditSchedule } from 'src/app/core/interfaces/branch-audit/auditSchedule.interface';
import { WPAuditScheduleBranch } from 'src/app/core/interfaces/branch-audit/auditScheduleBranch.interface';
import {
  addMeetingApology,
  addMeetingPresent,
  addMeetingSubject,
  ClosingMeetingMinutes,
} from 'src/app/core/interfaces/branch-audit/closingMeetingMinutes.interface';
import { BaseResponse } from 'src/app/core/interfaces/common/base-response.interface';
import { commonValueAndType } from 'src/app/core/interfaces/configuration/commonValueAndType.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { User } from 'src/app/core/interfaces/security/user-registration.interface';
import { HelperService } from 'src/app/core/services/helper.service';
import { HttpService } from 'src/app/core/services/http.service';
import { AlertService } from '../../../../../core/services/alert.service';

@Component({
  selector: 'app-closing-meeting-minutes-create',
  templateUrl: './closing-meeting-minutes-create.component.html',
  styleUrls: ['./closing-meeting-minutes-create.component.scss'],
})
export class ClosingMeetingMinutesCreateComponent implements OnInit {
  cMMForm: FormGroup;
  paramId: string = '';
  auditSchedules: AuditSchedule[] = [];
  closingMeetingMinutes: ClosingMeetingMinutes[] = [];
  wpAuditScheduleBranches: WPAuditScheduleBranch[] = [];
  users: User[] = [];
  closingMeetingSubjects: addMeetingSubject[] = [];

  constructor(
    private http: HttpService,
    private router: Router,
    private fb: FormBuilder,
    private activateRoute: ActivatedRoute,
    private AlertService: AlertService,
    private helper: HelperService
  ) {
    this.loadDropDownValues();
    this.cMMForm = this.fb.group({
      id: [''],
      meetingMinutesCode: [''],
      scheduleCode: [''],
      auditScheduleBranchId: [
        null,
        [Validators.required, Validators.pattern('^(?!null$).*$')],
      ],
      meetingMinutesDate: [Date, [Validators.required]],
      meetingMinutesName: [
        null,
        [Validators.required, Validators.pattern('^(?!null$).*$')],
      ],
      auditOn: [
        null,
        [Validators.required, Validators.pattern('^(?!null$).*$')],
      ],
      meetingHeld: [
        null,
        [Validators.required, Validators.pattern('^(?!null$).*$')],
      ],
      preparedByUserId: [
        null,
        [Validators.required, Validators.pattern('^(?!null$).*$')],
      ],
      agreedByUserId: [
        null,
        [Validators.required, Validators.pattern('^(?!null$).*$')],
      ],
      // subjectMatter : [''],
      // userId: [''],
      closingMeetingPresent: ['', [Validators.required]],
      closingMeetingApology: ['', [Validators.required]],
      closingMeetingSubject: [''],
    });
  }

  loadDropDownValues() {
    this.LoadUser();
  }

  ngOnInit(): void {
    this.paramId = 'C09240DA-02DE-4B96-9A61-C9CA8F741C89';
    this.LoadScheduleData(this.paramId);
    this.LoadSubjectMatters();
  }

  onSubmit(): void {
    const that = this;
    let presentuserList: addMeetingPresent[] = [];
    let appologiesuserList: addMeetingApology[] = [];
    let subjectList: addMeetingSubject[] = [];

    
    const CMMFormValue = this.cMMForm.getRawValue();
   // console.log(CMMFormValue.closingMeetingSubject[this.closingMeetingSubjects.length - 1].subjectMatter);

  
    console.log('CMMFormValue', CMMFormValue);
    let cmmId = CMMFormValue.id == '' ? (null as any) : CMMFormValue.id;

    if (this.cMMForm.valid) {
      let present: addMeetingPresent[] = this.cMMForm.value
        .closingMeetingPresent as addMeetingPresent[];
      if (Array.isArray(present)) {
        present.forEach(function (value) {
          let user: addMeetingPresent = { userId: value.toString() };
          presentuserList.push(user);
        });
      }
      let appologies: addMeetingApology[] = this.cMMForm.value
        .closingMeetingApology as addMeetingApology[];
      if (Array.isArray(appologies)) {
        appologies.forEach(function (value) {
          let user: addMeetingApology = { userId: value.toString() };
          appologiesuserList.push(user);
        });
      }
      let subjects: addMeetingSubject[] = this
        .closingMeetingSubjects as addMeetingSubject[];

      if (Array.isArray(subjects)) {
        subjects.forEach(function (value) {
          let subject: addMeetingSubject = {
            userId: value.userId?.toString(),
            subjectMatter: value.subjectMatter?.toString(),
          };
          subjectList.push(subject);
        });
      }
      console.log(CMMFormValue.closingMeetingSubject);
  //  if(CMMFormValue.closingMeetingSubject == ""){
  //   this.AlertService.errorDialog(
  //     'Unsuccessful',
  //     'Please fill the last row of Subject Matter Table'
  //   );
  //   return;
  //  }

      // if (
      //   subjectList[subjectList.length - 1].subjectMatter == "" &&
      //   subjectList[subjectList.length - 1].userId == ""
      // ) {
      //   console.log("+++++",subjectList[subjectList.length - 1].subjectMatter);
      //   this.AlertService.errorDialog(
      //     'Unsuccessful',
      //     'Please fill the last row of Subject Matter Table'
      //   );
        
      // }

      const cmmRequestCreateModel: ClosingMeetingMinutes = {
        // id:  null as any,
        meetingMinutesCode: CMMFormValue.meetingMinutesCode,
        auditScheduleId: this.paramId,
        auditScheduleBranchId: CMMFormValue.auditScheduleBranchId,
        meetingMinutesDate: CMMFormValue.meetingMinutesDate,
        meetingMinutesName: CMMFormValue.meetingMinutesName,
        auditOn: CMMFormValue.auditOn,
        meetingHeld: CMMFormValue.meetingHeld,
        preparedByUserId: CMMFormValue.preparedByUserId,
        agreedByUserId: CMMFormValue.agreedByUserId,
        createdOn: CMMFormValue.createdOn,

        closingMeetingPresent: presentuserList,
        closingMeetingApology: appologiesuserList,
        closingMeetingSubject: subjectList,
      };

      

      console.log('THis is Really awesome', cmmRequestCreateModel);

      this.http
        .post('closingmeetingminute', cmmRequestCreateModel)
        .subscribe((x) => {
          let resp = x as BaseResponse;
          if (resp.success) {
            this.AlertService.success(
              'Closing Meeting Minutes Saved Successful'
            );
          } else {
            this.AlertService.errorDialog('Unsuccessful', 'Duplicate Value ');
          }
        });
    } else {
      this.AlertService.errorDialog('Unsuccessful', 'ddd');
    }
  }

  LoadScheduleData(Id: any): void {
    this.http.getById('AuditSchedule', Id).subscribe((res) => {
      const scheduleData = res as AuditSchedule;
      let scheduleId = scheduleData.id;
      let countryId = scheduleData.countryId;
      this.GetMeetingMinutesCode(countryId);
      this.LoadBranches(scheduleId);
      this.cMMForm.patchValue({
        scheduleCode: scheduleData.scheduleId,
      });
    });
  }

  GetMeetingMinutesCode(countryId: any): void {
    if (countryId != 'null') {
      this.http
        .get(
          'commonValueAndType/idcreation?idcreationValue=11&auditType=1&countryId=' +
            countryId +
            ''
        )
        .subscribe((resp) => {
          const convertedResp = resp as commonValueAndType;
          this.cMMForm.patchValue({
            meetingMinutesCode: convertedResp.text,
          });
        });
    }
  }
  LoadBranches(scheduleId: any) {
    this.http
      .get(
        'commonValueAndType/getAuditScheduleBranch?ScheduleId=' +
          scheduleId +
          ''
      )
      .subscribe((resp) => {
        let convertedResp = resp as WPAuditScheduleBranch[];
        this.wpAuditScheduleBranches = convertedResp;
      });
  }

  LoadUser() {
    this.http
      .paginatedPost('userlist/Paginated', 100, 1, {
        userName: '',
        employeeName: '',
        userRole: '',
      })
      .subscribe((resp) => {
        let convertedResp = resp as paginatedResponseInterface<User>;
        this.users = convertedResp.items;
      });
  }

  LoadSubjectMatters() {
    var currentElement: addMeetingSubject = {
      subjectMatter: '',
      userId: '',
    };
    this.closingMeetingSubjects.push(currentElement);
    console.log('adddddd', this.closingMeetingSubjects);
  }

  addItem() {
    var currentElement: addMeetingSubject = {
      subjectMatter: '',
      userId: '',
    };
    console.log(currentElement);
    this.closingMeetingSubjects.push(currentElement);
  }

  removeItem(index: any) {
    console.log(index);
    if(index== 0){
      this.AlertService.errorDialog('Unsuccessful', 'You can not delete the last row');
      return;
    }
    var currentElement = this.closingMeetingSubjects[index];
    console.log(currentElement);
    this.closingMeetingSubjects.splice(index, 1);
    console.log(this.closingMeetingSubjects);
  }
}
