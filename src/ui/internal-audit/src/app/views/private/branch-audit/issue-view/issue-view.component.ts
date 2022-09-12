import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { issue, IssueActionPlan } from 'src/app/core/interfaces/branch-audit/issue.interface';
import { HttpService } from 'src/app/core/services/http.service';

@Component({
  selector: 'app-issue-view',
  templateUrl: './issue-view.component.html',
  styleUrls: ['./issue-view.component.scss']
})
export class IssueViewComponent implements OnInit {
  paramId:string ='';
  actionPlans: any[] = [];
  issueDetails!: issue;
  issueViewForm: FormGroup;
  dtOptions: DataTables.Settings = {};
  

  constructor(private http: HttpService, private fb: FormBuilder, private router: Router,  private activateRoute: ActivatedRoute) { 
    this.issueViewForm = this.fb.group({
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

      remarks:[''],

      likelihoodType:[''],
      impactType:[''],
      branch:[''],

    })
  }

  ngOnInit(): void {
    this.paramId = this.activateRoute.snapshot.params['id'];
    console.log('paramid',this.paramId);

    this.actionPlans.push(
      {    
        actionPlanCode: 'plan',
        managementPlan: 'mng plan',
        userName: 'isa'+'<br/>'+'ishita',
        targetDate: new Date,
        issueActionPlanOwnerList:[]
      }
    );
    this.actionPlans.push(
      {    
        actionPlanCode: 'plan',
        managementPlan: 'mng plan',
        userName: 'isa'+'<br/>'+'ishita',
        targetDate: new Date,
        issueActionPlanOwnerList:[]
      }
    );
    this.LoadIssueById(this.paramId);
  }
  LoadIssueById(id: any) {
    this.http
      .getById('issue','Id?Id='+id)
      .subscribe(res => {
          this.issueDetails = res as issue;
         // this.issueDetails.issueOwnerList = res.issueOwnerList as IssueOwner[];
          console.log(this.issueDetails);
          
        //   this.selectedAuditScheduleBranchList = issueById.issueBranchList as IssueBranch[];
        //   this.selectedIssueOwnerList = issueById.issueOwnerList as IssueOwner[];
        //   this.onSelectAuditSchedule(issueById.auditScheduleId);

          this.issueViewForm.patchValue({id: this.issueDetails.id, code: this.issueDetails.code, issueTitle: this.issueDetails.issueTitle, auditScheduleId: this.issueDetails.auditScheduleId,
            policy:this.issueDetails.policy, impactTypeId:this.issueDetails.impactTypeId, likelihoodTypeId: this.issueDetails.likelihoodTypeId,
            ratingTypeId: this.issueDetails.ratingTypeId, statusTypeId: this.issueDetails.statusTypeId, targetDate:formatDate(this.issueDetails.targetDate, 'yyyy-MM-dd', 'en'), 
            details: this.issueDetails.details, rootCause: this.issueDetails.rootCause, businessImpact: this.issueDetails.businessImpact, potentialRisk: this.issueDetails.potentialRisk,
            auditorRecommendation: this.issueDetails.auditorRecommendation,
            branchList:this.issueDetails.issueBranchList, issueOwnerList:this.issueDetails.issueOwnerList,
          });
          this.actionPlans = this.issueDetails.actionPlans as IssueActionPlan[];
      });
     
  }
  onSubmit(){}  
}

