import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuditSchedule } from 'src/app/core/interfaces/branch-audit/auditSchedule.interface';
import { issue } from 'src/app/core/interfaces/branch-audit/issue.interface';
import { commonValueAndType } from 'src/app/core/interfaces/configuration/commonValueAndType.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';
import {AlertService} from '../../../../core/services/alert.service';
import { User } from '../../../../core/interfaces/branch-audit/user.interface';
import { issueActionPlan } from '../../../../core/interfaces/branch-audit/issueActionPlan.interface';
import { Router } from '@angular/router';

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


  actionPlanCode: any;
  userList: User[] = [];
  actionPlans : issueActionPlan[] = [];
//   actionPlans: [
//     {
//       "actionPlanCode": "AC-1001",
//       "managementPlan": "red pencil",
//       "owner": "someone",
//       "targetDate": "red pencil",
//     } ,
//     {
//       "actionPlanCode": "AC-1002",
//       "managementPlan": " pencil",
//       "owner": "someone",
//       "targetDate": "red pencil",
//     } ,
//     {
//       "actionPlanCode": "AC-1003",
//       "managementPlan": "red ",
//       "owner": "someone",
//       "targetDate": "red pencil",
//     }        
    
//  ];

  constructor(private http: HttpService , private fb: FormBuilder, private AlertService: AlertService, private router: Router) { 
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
    this.countryId = "2162B8E8-BBF2-EC11-B3B0-00155D610B18"; //need to implement LoadCountryId()
    this.LoadAuditId();
    this.LoadIssueCode();
    this.LoadAuditSchedules();
    this.LoadLikelihoodLevel();
    this.LoadImpactLevel();
    this.LoadUserList();
    this.LoadActionPlans();
  }
  onSubmitNewIssue(){
    //redirect to action plan modal
  }
  onCancelNewIssue(){
    this.router.navigate(['branch-audit/issue-list']);
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
      //console.log( this.auditSchedules)
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
//action plan

LoadActionPlans(){
  // let tempActionPlan: issueActionPlan = {
  //   id: "0",
  //   actionPlanCode: "AC-1001",
  //   managementPlan: "red pencil",
  //   owner: "someone",
  //   targetDate: "red pencil"
  // };
  // this.actionPlans.push(tempActionPlan);
  this.LoadActionPlanCode().then((acPlnCode:any)=>{
    
    var currentElement: issueActionPlan = {
      id: "",
      actionPlanCode: acPlnCode,
      managementPlan: '',
      owner: "",
      targetDate: ''
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
    this.userList = convertedResp.items;
  })
}
async addItem(index:any, managementPlan:any, targetDate:any) {
  this.LoadActionPlanCode().then((acPlnCode:any)=>{
    console.log(index, managementPlan, acPlnCode,targetDate);
    var currentElement: issueActionPlan = {
      id: "",
      actionPlanCode: acPlnCode,
      managementPlan: '',
      owner: "",
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

 }
 onCancelActionPlan(){
  this.router.navigate(['branch-audit/issue-list']);
 }

}