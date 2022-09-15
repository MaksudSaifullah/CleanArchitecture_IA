import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { issue, IssueActionPlan } from 'src/app/core/interfaces/branch-audit/issue.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
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
  issueDetails: any ={};
  actionPlans: any[] = [];
  
  constructor(private http: HttpService, private fb: FormBuilder, private router: Router, private activateRoute: ActivatedRoute, private AlertService: AlertService, private helper: HelperService) {
    this.issueValidationForm = this.fb.group({      
      id: [''],
      issueId:[''],
      code: [''],
      issueTitle:['', [Validators.required]],
      targetDate:[Date, [Validators.required]],
      issueOwners:['', [Validators.required]],

      auditReportDate:[Date, [Validators.required]],
      validatedByUserId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      reviewedByUserID:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      approvedByUserId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      reviewEvidenceDocumentId:[''],
      approvalEvidenceDocumentId:[''],
      closureSummary:['', [Validators.required, Validators.minLength(3)]],
      validationDate:[Date, [Validators.required]],
      reviewDate:[Date, [Validators.required]],
      approvalDate:[Date, [Validators.required]],
      issueClosureDate:[Date, [Validators.required]]
    })
  }
  ngOnInit(): void {
    this.issueId = this.activateRoute.snapshot.params['id'];
    this.LoadIssueById(this.issueId).then((resolve:any)=>{
      this.issueValidationForm.patchValue({
        code: resolve.code, issueTitle: resolve.issueTitle, targetDate:formatDate( resolve.targetDate, 'yyyy-MM-dd', 'en'), issueOwners: resolve.issueOwners
      }); 
      this.issueDetails = resolve;
      console.log('hello**************************');
      console.log(this.issueDetails)    
    });
    this.LoadUsers();
  }
  LoadIssueById(id: any) {
    return new Promise((resolve, reject) => {
      this.http
      .getById('issue', 'Id?Id=' + id)
      .subscribe(issueById => {            
        const iss = issueById as issue;            
        resolve(iss);
        //this.actionPlans = this.issueDetails.actionPlans as IssueActionPlan[];
      });        
    });
  }
  LoadUsers(){
    console.log("hello from load issue owner");
    this.http.paginatedPost('userlist/Paginated', 100, 1, {userName: '', employeeName: '', userRole: '',})
      .subscribe((resp) => {
        let convertedResp = resp as paginatedResponseInterface<User>;
        this.users = convertedResp.items;
      });
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
