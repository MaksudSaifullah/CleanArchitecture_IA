import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { issue, IssueActionPlan } from 'src/app/core/interfaces/branch-audit/issue.interface';
import { BaseResponse } from 'src/app/core/interfaces/common/base-response.interface';
import { commonValueAndType } from 'src/app/core/interfaces/configuration/commonValueAndType.interface';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';
import {AlertService} from '../../../../core/services/alert.service';

@Component({
  selector: 'app-issue-view',
  templateUrl: './issue-view.component.html',
  styleUrls: ['./issue-view.component.scss']
})
export class IssueViewComponent implements OnInit {
  formService: FormService = new FormService();
  paramId: string = '';
  actionPlans: any[] = [];
  issueDetails!: issue;
  issueViewForm: FormGroup;
  changeStatusForm: FormGroup;
  actionTakenForm: FormGroup;
  statuses:any[] = [];
  statusType:any;
  dtOptions: DataTables.Settings = {};


  constructor(private http: HttpService, private fb: FormBuilder, private router: Router, private activateRoute: ActivatedRoute, private AlertService: AlertService) {
    this.issueViewForm = this.fb.group({
      auditId: [''],
      id: [''],
      code: [''],
      issueTitle: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(500)]],

      ratingType: [''],
      actionOwners: [''],
      targetDate: [Date, [Validators.required]],
      statusType: [''],

      auditScheduleId: [null, [Validators.required, Validators.pattern("^(?!null$).*$")]],
      branchList: ['', [Validators.required]],
      issueOwnerList: ['', [Validators.required]],
      impactTypeId: [null, [Validators.required, Validators.pattern("^(?!null$).*$")]],
      likelihoodTypeId: [null, [Validators.required, Validators.pattern("^(?!null$).*$")]],
      ratingTypeId: [''],
      statusTypeId: [''],
      policy: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(500)]],
      details: ['', [Validators.required, Validators.minLength(3)]],
      rootCause: ['', [Validators.required, Validators.minLength(3)]],
      businessImpact: ['', [Validators.required, Validators.minLength(3)]],
      potentialRisk: ['', [Validators.required, Validators.minLength(3)]],
      auditorRecommendation: ['', [Validators.required, Validators.minLength(3)]],

      remarks: [''],

      likelihoodType: [''],
      impactType: [''],
      branch: [''],
    }),
    this.changeStatusForm = this.fb.group({
      remarks: ['', [Validators.required, Validators.minLength(3)]],
      statusTypeId: [null, [Validators.required, Validators.pattern("^(?!null$).*$")]],
    }),
    this.actionTakenForm = this.fb.group({
        actionTakenDate:[Date, [Validators.required]],
        evidenceDocumentId:['',[Validators.required]],

        actionTakenRemarks: ['', [Validators.required, Validators.minLength(3)]]
      }
    )
  }

  ngOnInit(): void {
    this.paramId = this.activateRoute.snapshot.params['id'];
    console.log('paramid', this.paramId);
    this.loadStatuses();
    this.actionPlans.push(
      {
        actionPlanCode: 'plan',
        managementPlan: 'mng plan',
        userName: 'isa' + '<br/>' + 'ishita',
        targetDate: new Date,
        issueActionPlanOwnerList: []
      }
    );
    this.actionPlans.push(
      {
        actionPlanCode: 'plan',
        managementPlan: 'mng plan',
        userName: 'isa' + '<br/>' + 'ishita',
        targetDate: new Date,
        issueActionPlanOwnerList: []
      }
    );
    this.LoadIssueById(this.paramId);
  }
  LoadIssueById(id: any) {
    this.http
      .getById('issue', 'Id?Id=' + id)
      .subscribe(res => {
        this.issueDetails = res as issue;
        this.statusType = this.issueDetails.statusType;
        // this.issueDetails.issueOwnerList = res.issueOwnerList as IssueOwner[];
        console.log(this.issueDetails);


        //   this.selectedAuditScheduleBranchList = issueById.issueBranchList as IssueBranch[];
        //   this.selectedIssueOwnerList = issueById.issueOwnerList as IssueOwner[];
        //   this.onSelectAuditSchedule(issueById.auditScheduleId);

        this.issueViewForm.patchValue({
          id: this.issueDetails.id, code: this.issueDetails.code, issueTitle: this.issueDetails.issueTitle, auditScheduleId: this.issueDetails.auditScheduleId,
          policy: this.issueDetails.policy, impactTypeId: this.issueDetails.impactTypeId, likelihoodTypeId: this.issueDetails.likelihoodTypeId,
          ratingTypeId: this.issueDetails.ratingTypeId, statusTypeId: this.issueDetails.statusTypeId, targetDate: formatDate(this.issueDetails.targetDate, 'yyyy-MM-dd', 'en'),
          details: this.issueDetails.details, rootCause: this.issueDetails.rootCause, businessImpact: this.issueDetails.businessImpact, potentialRisk: this.issueDetails.potentialRisk,
          auditorRecommendation: this.issueDetails.auditorRecommendation, createdBy: this.issueDetails.createdBy, createdOn: this.issueDetails.createdOn,
          branchList: this.issueDetails.issueBranchList, issueOwnerList: this.issueDetails.issueOwnerList,
        });
        this.actionPlans = this.issueDetails.actionPlans as IssueActionPlan[];
      });

  }
  changeStatus(){
    

  }
  loadStatuses(){
    this.http.get('commonValueAndType/issuestatus').subscribe(resp => {
      let convertedResp = resp as commonValueAndType[];
      this.statuses = convertedResp;
    })
  }
  onSubmitStatusChange(modalId:any):void { 
    this.statusType = this.changeStatusForm.get('statusTypeId')?.value;
    this.issueDetails.statusTypeId = this.changeStatusForm.get('statusTypeId')?.value;
    this.issueDetails.remarks = this.changeStatusForm.get('remarks')?.value;
    console.log(this.issueDetails);
    let jsn = JSON.stringify(this.issueDetails);
    console.log(jsn, 'hi');
    this.http.put('issue', this.issueDetails, null).subscribe(x=>{
      let resp = x as BaseResponse;
        if(resp.success){
          modalId.visible = false;
          //this.formService.onSaveSuccess(modalId, this.ReloadAllDataTable());          
          this.AlertService.successDialog('Updated',resp.message);
          this.router.navigate(['branch-audit/issue-list']);
        }
        else{
          this.AlertService.errorDialog('Unsuccessful', resp.message);
        }
    });
  }
  onUploadDocument(event:any){

  }
}

