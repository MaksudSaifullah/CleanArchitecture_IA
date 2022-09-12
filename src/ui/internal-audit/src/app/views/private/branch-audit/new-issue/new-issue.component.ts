import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AuditSchedule } from 'src/app/core/interfaces/branch-audit/auditSchedule.interface';
import { issue, IssueBranch, IssueOwner, IssueActionPlan, IssueResponse, IssueActionPlanOwner } from 'src/app/core/interfaces/branch-audit/issue.interface';
import { commonValueAndType } from 'src/app/core/interfaces/configuration/commonValueAndType.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';
import {AlertService} from '../../../../core/services/alert.service';
import { User } from '../../../../core/interfaces/branch-audit/user.interface';
import { ActivatedRoute, Router } from '@angular/router';
import { AuditScheduleBranch, AuditScheduleBranchDetails } from 'src/app/core/interfaces/branch-audit/auditScheduleBranch.interface';
import { formatDate } from '@angular/common';
import { BaseResponse } from 'src/app/core/interfaces/common/base-response.interface';

@Component({
  selector: 'app-new-issue',
  templateUrl: './new-issue.component.html',
  styleUrls: ['./new-issue.component.scss']
})
export class NewIssueComponent implements OnInit {
  paramId:string ='';
  pageName:string = '';

  issue: issue[] = [];
  issueForm: FormGroup;
  formService: FormService = new FormService();
  countryId:any;
  code : commonValueAndType | undefined;
  auditId: any;
  auditSchedules: AuditSchedule[] = [];
  auditScheduleBranches: AuditScheduleBranchDetails[] = [];
  issueOwnerList: User[]=[];
  likelihoodType: commonValueAndType[] = [];
  impactType: commonValueAndType[] = [];
  selectedAuditScheduleBranchList: IssueBranch[]=[];
  selectedIssueOwnerList : IssueOwner[]=[];
  selectedActionPlanOwnerList : IssueActionPlanOwner[]=[];


  actionPlanCode: any;
  actionOwnerList: User[] = [];
  actionPlans : IssueActionPlan[] = [];

  constructor(private http: HttpService , private fb: FormBuilder, private AlertService: AlertService, private router: Router,  private activateRoute: ActivatedRoute) { 
    this.issueForm = this.fb.group({
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
    console.log(this.paramId);

    this.LoadDropdownValues();
    if(this.paramId === undefined){
      this.pageName='NewIssue';
      this.LoadIssueCode();
      this.LoadActionPlans();
    }
    else{
      this.pageName='EditIssue';
      this.LoadIssueById(this.paramId);
    }
    console.log(this.pageName);    
  }
  LoadDropdownValues(){
    this.reset();
    this.countryId = "2162B8E8-BBF2-EC11-B3B0-00155D610B18"; //need to implement LoadCountryId()
    this.LoadAuditId();
    this.LoadAuditSchedules();
    this.LoadLikelihoodLevel();
    this.LoadImpactLevel();
    this.LoadUserList();
  }
  LoadIssueById(id: any) {
    this.http
      .getById('issue','Id?Id='+id)
      .subscribe(res => {
          const issueById = res as issue;
          // console.log("***************");
          // console.log(issueById);
          // console.log("***************");
          this.selectedAuditScheduleBranchList = issueById.issueBranchList as IssueBranch[];
          this.selectedIssueOwnerList = issueById.issueOwnerList as IssueOwner[];
          this.onSelectAuditSchedule(issueById.auditScheduleId);

          this.issueForm.patchValue({id: issueById.id, code: issueById.code, issueTitle: issueById.issueTitle, auditScheduleId: issueById.auditScheduleId,
            policy:issueById.policy, impactTypeId:issueById.impactTypeId, likelihoodTypeId: issueById.likelihoodTypeId,
            ratingTypeId: issueById.ratingTypeId, statusTypeId: issueById.statusTypeId, targetDate:formatDate(issueById.targetDate, 'yyyy-MM-dd', 'en'), 
            details: issueById.details, rootCause: issueById.rootCause, businessImpact: issueById.businessImpact, potentialRisk: issueById.potentialRisk,
            auditorRecommendation: issueById.auditorRecommendation,
            branchList:issueById.issueBranchList, issueOwnerList:issueById.issueOwnerList,
          });
         this.actionPlans = issueById.actionPlans as IssueActionPlan[];

         for (var i in  this.actionPlans) {
         
            this.actionPlans[i].issueActionPlanOwnerList[i].ownerId = '398fc93b-51c6-4de0-88ff-bc62c2d88bdf';
             break; //Stop this loop, we found it!
          
        }
          console.log('----------------------------------');
          console.log(this.actionPlans);
          console.log('----------------------------------');


        //  this.actionPlans.forEach((ctrl: any) => {   
        //   ctrl.issueActionPlanOwnerList.push('398fc93b-51c6-4de0-88ff-bc62c2d88bdf')
        //   });
        //  

      });
     
  }
  onContinueNewIssue(){
  //todo: on click continue, move to next page
  }
  onCancelNewIssue(){
    this.router.navigate(['branch-audit/issue-list']);
  }

  LoadIssueCode(){
    this.http.get('commonValueAndType/idcreation?idcreationValue=12&auditType=1&countryId='+this.countryId).subscribe(resp => {
     // let convertedResp = resp as commonValueAndType;
      this.code = resp as commonValueAndType;
      this.issueForm.patchValue({code: this.code.text});
      //console.log(this.code);
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
      creationId: "25865382-7E27-ED11-B3B2-00155D610B18"
    }
    // console.log(request)
    this.http.post('AuditSchedule/getByAuditCreationId', request).subscribe(resp => {
      let convertedResp = resp as AuditSchedule[];
      this.auditSchedules = convertedResp;     
      //console.log( this.auditSchedules)
    })
  }
  onSelectAuditSchedule(scheduleId:any){
    this.LoadBranches(scheduleId);
    this.LoadIssueOwners();
  }

  LoadBranches(scheduleId:any){
    this.auditScheduleBranches = [];
   // console.log("hello from load branches",scheduleId);
    this.http.get('commonValueAndType/getAuditScheduleBranch?ScheduleId='+ scheduleId).subscribe(resp => {
      let convertedResp = resp as AuditScheduleBranchDetails[];
      this.auditScheduleBranches = convertedResp;  
      console.log("load branches");   
      console.log( this.auditScheduleBranches)
    })
  }
  LoadIssueOwners(){
    console.log("hello from load issue owner");
    this.http.paginatedPost('userlist/Paginated', 100, 1, {userName: '', employeeName: '', userRole: '',})
      .subscribe((resp) => {
        let convertedResp = resp as paginatedResponseInterface<User>;
        this.issueOwnerList = convertedResp.items;
      });
  }

  isBranchSelected(branchId:any){
    for (let branch of this.selectedAuditScheduleBranchList){
      if(branch.branchId == branchId){
        //console.log('selected branch list', this.selectedAuditScheduleBranchList)
        return true;
      }
     }
     return false;
  }
  
  isIssueOwnerSelected(issueOwnerId:any){    
    for (let owner of this.selectedIssueOwnerList){
      console.log()
      if(owner.ownerId == issueOwnerId){
        return true;
      }
     }
     return false;
  }
  isActionPlanOwnerSelected(indx:any, actionPlanOwnerId:any){
   // return true;
    // console.log(actionPlanOwnerId);
    // return;
    for (let actionOwner of this.actionPlans[indx].issueActionPlanOwnerList){
      if(actionOwner.ownerId == actionPlanOwnerId){

        console.log('iftekharrrrrrrrrrrrrrrrrrrrrrrrrrrrr',indx);
         console.log(actionOwner.ownerId,actionPlanOwnerId);
        // console.log(indx, actionPlanOwnerId);
        return true;
      }
     }

    // let actionOwner = this.actionPlans[indx].issueActionPlanOwnerList as IssueActionPlanOwner;
    //   if(actionOwner.ownerId == actionPlanOwnerId){

    //     console.log('iftekharrrrrrrrrrrrrrrrrrrrrrrrrrrrr',indx);
    //      console.log(actionOwner.ownerId,actionPlanOwnerId);
    //     // console.log(indx, actionPlanOwnerId);
    //     return true;
    //   }else{}
     
     return false;
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
    //this.issueForm.controls['code'].disable();
 }
//action plan

LoadActionPlans(){
  this.LoadActionPlanCode().then((acPlnCode:any)=>{
    
    var currentElement: IssueActionPlan = {    
      actionPlanCode: acPlnCode,
      managementPlan: '',
      targetDate  : new Date(),
      issueActionPlanOwnerList:[]
    };
    this.actionPlans.push(currentElement);  
  }); 
}

 LoadActionPlanCode(): any {
  return new Promise((resolve, reject) => {
    console.log('hello');
    this.http.get('commonValueAndType/idcreation?idcreationValue=13&auditType=1&countryId='+this.countryId).subscribe(resp => {
    const temp = resp as commonValueAndType;
    //this.actionPlans[index].actionPlanCode = temp.text;   
    console.log(temp.text); 
    resolve(temp.text);  

  })});

  // let temp:any;
  // temp = await (this.http.get('commonValueAndType/idcreation?idcreationValue=13&auditType=1&countryId='+this.countryId).subscribe(resp => {
  //   temp = resp as commonValueAndType;
  //   //this.actionPlans[index].actionPlanCode = temp.text;   
  //   console.log(temp.text); 
  //   return temp.text;   
  // }));
  
}
LoadUserList() {
  this.http.paginatedPost('userlist/paginated', 100, 1, {"userName": "",
  "employeeName": "",
  "userRole": ""}).subscribe(resp => {
    let convertedResp = resp as paginatedResponseInterface<User>;
    this.actionOwnerList = convertedResp.items;
  })
}
async addItem(index:any, managementPlan:any, targetDate:any, issueActionPlanOwnerList:any) {
  this.LoadActionPlanCode().then((acPlnCode:any)=>{
    console.log(index, managementPlan,targetDate, issueActionPlanOwnerList);
    var currentElement: IssueActionPlan = {
      actionPlanCode: acPlnCode,
      managementPlan: managementPlan.text,
      issueActionPlanOwnerList: issueActionPlanOwnerList,
      targetDate: targetDate
    };
    this.actionPlans.push(currentElement);
  }); 
  console.log(this.actionPlans);
 }

 removeItem(index:any) {
  console.log(index);
  var currentElement = this.actionPlans[index];  
  this.actionPlans.splice(index, 1);
  console.log(this.actionPlans);
 }
 onSubmitActionPlan(){

  console.log(this.actionPlans);
  if (this.issueForm.valid ){
      let branchList: IssueBranch[] = [];
      let issueBranch: IssueBranch[] = this.issueForm.value.branchList as IssueBranch[];
      if (Array.isArray(issueBranch)) {
        issueBranch.forEach(function (value) {
          let br: IssueBranch = { branchId: value.toString() }
          branchList.push(br);
        });
      }
      let issueOwnerList: IssueOwner[] = [];
      let issueOwner: IssueOwner[] = this.issueForm.value.issueOwnerList as IssueOwner[];
      if (Array.isArray(issueOwner)) {
        issueOwner.forEach(function (value) {
          let owner: IssueOwner = { ownerId: value.toString() }
          issueOwnerList.push(owner);
        });
      }
      let final : IssueActionPlan[]=[] ;
      if(Array.isArray(this.actionPlans)){
        this.actionPlans.forEach(function (value:any) {
          let pp :IssueActionPlanOwner[]=[];
          value.issueActionPlanOwnerList.forEach(function (guids:any) {
            let s :IssueActionPlanOwner={
              ownerId:guids
            }
            pp.push(s);
          });
          let initial : IssueActionPlan={
            actionPlanCode:value.actionPlanCode,
            targetDate:value.targetDate,
            managementPlan:value.managementPlan,
            issueActionPlanOwnerList:pp
          };
          final.push(initial);
        });
      }
      if(this.formService.isEdit(this.issueForm.get('id') as FormControl)){

        const PutRequestModel = {
           id: this.issueForm.value.id,
           code: this.issueForm.value.code,
           auditScheduleId: this.issueForm.value.auditScheduleId,
           issueTitle:this.issueForm.value.issueTitle,
           policy: this.issueForm.value.policy,        
           impactTypeId: this.issueForm.value.impactTypeId,
           likelihoodTypeId: this.issueForm.value.likelihoodTypeId,
           ratingTypeId: "19838C61-2F0E-ED11-B3B2-00155D610B18",//this.issueForm.value.ratingTypeId,
           targetDate: this.issueForm.value.targetDate,
           details: this.issueForm.value.details,
           rootCause: this.issueForm.value.rootCause,
           businessImpact: this.issueForm.value.businessImpact,
           potentialRisk: this.issueForm.value.potentialRisk,
           auditorRecommendation: this.issueForm.value.auditorRecommendation,
           issueOwnerList: issueOwnerList,
           issueBranchList: branchList,
           actionPlans: final,
           statusTypeId: '0B838C61-2F0E-ED11-B3B2-00155D610B18', //default value set on issue table
           remarks: '',
        };
        this.http.put('issue', PutRequestModel, null).subscribe(x=>{
          let resp = x as BaseResponse;
            if(resp.success){
              this.AlertService.successDialog('Updated',resp.message);
              this.router.navigate(['branch-audit/issue-list']);
            }
            else{
              this.AlertService.errorDialog('Unsuccessful', resp.message);
            }
        });
      }
      else { 
        const PostRequestModel = {
          // id: this.issueForm.value.id,
           code: this.issueForm.value.code,
           auditScheduleId: this.issueForm.value.auditScheduleId,
           issueTitle:this.issueForm.value.issueTitle,
           policy: this.issueForm.value.policy,        
           impactTypeId: this.issueForm.value.impactTypeId,
           likelihoodTypeId: this.issueForm.value.likelihoodTypeId,
           ratingTypeId: "19838C61-2F0E-ED11-B3B2-00155D610B18",//this.issueForm.value.ratingTypeId,
           targetDate: this.issueForm.value.targetDate,        
           details: this.issueForm.value.details,
           rootCause: this.issueForm.value.rootCause,
           businessImpact: this.issueForm.value.businessImpact,
           potentialRisk: this.issueForm.value.potentialRisk,
           auditorRecommendation: this.issueForm.value.auditorRecommendation,
           issueOwnerList: issueOwnerList,
           issueBranchList: branchList,
           actionPlans: final,
           //statusTypeId: '', default value set on issue table
           remarks: '',
       };       
          this.http.post('issue',PostRequestModel).subscribe(x=>{
            //this.formService.onSaveSuccess(this.router.navigate(['branch-audit/issue-list']));
            let resp = x as BaseResponse;
            if(resp.success){
              this.AlertService.success('Issue Saved successfully');
              this.router.navigate(['branch-audit/issue-list']);
            }
            else{
              this.AlertService.errorDialog('Unsuccessful', resp.message);
            }            
          });
      }      
    }
    else {     
      this.issueForm.markAllAsTouched();
      this.AlertService.error('Provide valid data');
      return;
    }
 }
 onCancelActionPlan(){
  this.router.navigate(['branch-audit/issue-list']);
 }

}