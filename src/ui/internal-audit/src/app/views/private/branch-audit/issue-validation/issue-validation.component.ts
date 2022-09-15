import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/core/interfaces/security/user-registration.interface';
import { FormService } from 'src/app/core/services/form.service';
import { HelperService } from 'src/app/core/services/helper.service';
import { HttpService } from 'src/app/core/services/http.service';
import {AlertService} from '../../../../core/services/alert.service';

@Component({
  selector: 'app-issue-validation',
  templateUrl: './issue-validation.component.html',
  styleUrls: ['./issue-validation.component.scss']
})
export class IssueValidationComponent implements OnInit {

  issueId:string = '';
  issueValidationForm: FormGroup;
  formService: FormService = new FormService();
  users: User[]=[];
  
  constructor(private http: HttpService, private fb: FormBuilder, private router: Router, private activateRoute: ActivatedRoute, private AlertService: AlertService, private helper: HelperService) {
    this.issueValidationForm = this.fb.group({
      auditId:[''],
      id: [''],
      code: [''],
      issueTitle:['', [Validators.required, Validators.minLength(3), Validators.maxLength(500)]],
      
      ratingType:[''],
      actionOwners:[''],
      targetDate:[Date, [Validators.required]],
      statusType:[''],

      auditScheduleId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      branchList:['',[Validators.required]],
      issueOwnerList:['', [Validators.required]],
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
      evidenceDocumentId:[],

      remarks:[''],

      likelihoodType:[''],
      impactType:[''],
      branch:[''],

    })
  
  }
  ngOnInit(): void {
    this.issueId = this.activateRoute.snapshot.params['id'];
  }

  
  onContinueIssueValidation(){

  }
  onCancelIssueValidation(){

  }
  onSubmitValidationActionPlan(){

  }
  onCancelValidationActionPlan(){

  }
  onUploadReviewEvidence(event:any){

  }
  onUploadApprovalEvidence(event:any){

  }
}
