import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuditSchedule } from 'src/app/core/interfaces/branch-audit/auditSchedule.interface';
import { issue } from 'src/app/core/interfaces/branch-audit/issue.interface';
import { commonValueAndType } from 'src/app/core/interfaces/configuration/commonValueAndType.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';
import {AlertService} from '../../../../core/services/alert.service';

@Component({
  selector: 'app-new-issue',
  templateUrl: './new-issue.component.html',
  styleUrls: ['./new-issue.component.scss']
})
export class NewIssueComponent implements OnInit {
  issue: issue[] = [];
  issueForm: FormGroup;
  formService: FormService = new FormService();
  countryId:any;
  code : commonValueAndType | undefined;
  auditId: any;
  auditSchedules: AuditSchedule[] = [];
  likelihoodType: commonValueAndType[] = [];
  impactType: commonValueAndType[] = [];

  constructor(private http: HttpService , private fb: FormBuilder, private AlertService: AlertService) { 
    this.issueForm = this.fb.group({
      auditId:[''],
      id: [''],
      code: [''],
      issueTitle:['', [Validators.required, Validators.minLength(3), Validators.maxLength(500)]],
      issueOwners:[''],
      ratingType:[''],
      actionOwners:[''],
      targetDate:[Date, [Validators.required]],
      statusType:[''],

      auditScheduleId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      branchId:[''],
      impactTypeId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      likelihoodTypeId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      ratingTypeId:[''],
      statusTypeId:[''],
      policy:['', [Validators.required, Validators.minLength(3), Validators.maxLength(500)]],
      details:['', [Validators.required, Validators.minLength(3)]],
      rootCause:['', [Validators.required, Validators.minLength(3)]],
      businessImpact:['', [Validators.required, Validators.minLength(3)]],
      potentialRisk:['', [Validators.required, Validators.minLength(3)]],
      auditorRecommendation:['', [Validators.required, Validators.minLength(3)]],

      remarks:[''],

      likelihoodType:[''],
      impactType:[''],
      branch:[''],

    })
  }

  ngOnInit(): void {
    this.reset();
    this.countryId = "3EE0AB25-BAF2-EC11-B3B0-00155D610B18"; //need to implement LoadCountryId()
    this.LoadAuditId();
    this.LoadIssueCode();
    this.LoadAuditSchedules();
    this.LoadLikelihoodLevel();
    this.LoadImpactLevel();
  }
  onSubmit(){
    
  }
  LoadIssueCode(){
    this.http.get('commonValueAndType/idcreation?idcreationValue=12&auditType=1&countryId='+this.countryId).subscribe(resp => {
     // let convertedResp = resp as commonValueAndType;
      this.code = resp as commonValueAndType;
      this.issueForm.patchValue({code: this.code.text});
      console.log(this.code);
    })    
  }
  LoadCountryId(){
    //TODO: need to implement
  }
  LoadAuditId(){
    this.auditId = "BAudit10020220814130201"; //TODO: need to be received from audit view page
    this.issueForm.patchValue({auditId: this.auditId});
  }
  LoadAuditSchedules() 
  {
    const request={
      creationId: "2C830294-8E18-ED11-B3B2-00155D610B18"
    }
    console.log(request)
    this.http.post('AuditSchedule/getByAuditCreationId', request).subscribe(resp => {
      let convertedResp = resp as AuditSchedule[];
      
      this.auditSchedules = convertedResp;     
      console.log( this.auditSchedules)
    })
  }
  LoadLikelihoodLevel() {
    this.http.get('commonValueAndType/leveloflikelihood').subscribe(resp => {
      let convertedResp = resp as commonValueAndType[];
      this.likelihoodType = convertedResp;
    })
  }

  LoadImpactLevel() {
    this.http.get('commonValueAndType/levelofimpact').subscribe(resp => {
      let convertedResp = resp as commonValueAndType[];
      this.impactType = convertedResp;
    })
  }
  reset(){
    this.issueForm.reset();
    //this.auditForm.patchValue({auditTypeId:"3ee0ab25-baf2-ec11-b3b0-00155d610b11"});
    this.disabledInputField();
  }
  disabledInputField(){    
    this.issueForm.controls['auditId'].disable();
    this.issueForm.controls['code'].disable();
 }

}