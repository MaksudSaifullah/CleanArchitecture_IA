import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { firstValueFrom } from 'rxjs';
import { issue, IssueActionPlan } from 'src/app/core/interfaces/branch-audit/issue.interface';
import { BaseResponse } from 'src/app/core/interfaces/common/base-response.interface';
import { FileResponseInterface } from 'src/app/core/interfaces/file-response.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { User } from 'src/app/core/interfaces/security/user-registration.interface';
import { DocumentSource } from 'src/app/core/interfaces/uploaded-document.interface';
import { FormService } from 'src/app/core/services/form.service';
import { HelperService } from 'src/app/core/services/helper.service';
import { HttpService } from 'src/app/core/services/http.service';
import { AlertService} from '../../../../core/services/alert.service';
import { EvidenceDocument, IssueValidation } from 'src/app/core/interfaces/branch-audit/issueValidation.interface';

@Component({
  selector: 'app-issue-validation',
  templateUrl: './issue-validation.component.html',
  styleUrls: ['./issue-validation.component.scss']
})
export class IssueValidationComponent implements OnInit {

  issueId:string = '';
  issueValidationId: string= '';
  pageName:string = '';
  issueValidationForm: FormGroup;
  formService: FormService = new FormService();
  users: User[]=[];
  issueDetails: any ={};
  actionPlans: any[] = [];
  reviewDocumentFile: File | any = null;
  approvalDocumentFile: File | any = null;
  reviewDocumentRawSourceInfo: DocumentSource = {};
  approvalDocumentRawSourceInfo: DocumentSource = {};
  approvalEvidenceDocumentId : any;
  reviewEvidenceDocumentId : any;

  reviewDocName: string= '';
  approvalDocName: string= '';
  //doc: EvidenceDocument = {};
  
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
    this.issueValidationId = this.activateRoute.snapshot.params['id2'];
    // console.log('id 2 **************************');
    // console.log(this.issueValidationId);
    // console.log('id 2 **************************');
    this.LoadIssueById(this.issueId).then((resolve:any)=>{
      this.issueValidationForm.patchValue({
        code: resolve.code, issueTitle: resolve.issueTitle, targetDate:formatDate( resolve.targetDate, 'yyyy-MM-dd', 'en'), issueOwners: resolve.issueOwners
      }); 
      this.issueDetails = resolve;      
      //console.log(this.issueDetails)    
    });
    this.LoadUsers();
    if(this.issueValidationId === undefined){
      this.pageName='NewIssueValidation';     
    }
    else{
      this.pageName='EditIssueValidation';
      this.LoadIssueValidationById(this.issueId);
    }
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
  LoadIssueValidationById(id: any){
    this.http
      .getById('issuevalidation','GetByIssueId?Id='+id)
      .subscribe(res => {
          const issueValidation = res as IssueValidation[]; 
          // const doc = issueValidation[0].approvalEvidenceDocument as EvidenceDocument;
          // const doc2 = issueValidation[0].reviewEvidenceDocument as EvidenceDocument;
           console.log(issueValidation[0]);
          // 
          // 
        //  this.fileDownLoad(issueValidation[0].reviewEvidenceDocumentId);
          this.reviewEvidenceDocumentId = issueValidation[0].reviewEvidenceDocumentId;
          this.reviewDocName = issueValidation[0].reviewEvidenceDocument.name!+issueValidation[0].reviewEvidenceDocument.format!;

          this.approvalEvidenceDocumentId = issueValidation[0].approvalEvidenceDocumentId;
          this.approvalDocName = issueValidation[0].approvalEvidenceDocument.name!+issueValidation[0].approvalEvidenceDocument.format!;

          console.log('shala', this.reviewEvidenceDocumentId, this.approvalDocName);
          this.issueValidationForm.patchValue({
            // auditReportDate: issueValidation.auditReportDate,
            closureSummary: issueValidation[0].closureSummary,
            validatedByUserId: issueValidation[0].validatedByUserId,
            reviewedByUserID: issueValidation[0].reviewedByUserID,
            approvedByUserId: issueValidation[0].approvedByUserId,
            validationDate: formatDate(issueValidation[0].validationDate, 'yyyy-MM-dd', 'en'),
            reviewDate: formatDate(issueValidation[0].reviewDate, 'yyyy-MM-dd', 'en'),
            approvalDate: formatDate(issueValidation[0].approvalDate, 'yyyy-MM-dd', 'en'),
            issueClosureDate: formatDate(issueValidation[0].issueClosureDate, 'yyyy-MM-dd', 'en'),
            reviewEvidenceDocumentId: this.reviewDocName
          });
      });
  }
  onContinueIssueValidation(){
  }
  onCancelIssueValidation(){
    if(this.issueId != undefined){
      this.router.navigate(['/branch-audit/issue-view', this.issueId]);
    }
  }
  async onSubmit(){
    let reviewDocId;
    let approvalDocId;
    if(this.reviewDocumentFile!= null){
      this.reviewDocumentRawSourceInfo = await this.helper.getDocumentSource('Review_Evidence') as DocumentSource;
      const reviewFile = this.reviewDocumentFile as File;
      reviewDocId = await this.PostDocument(this.reviewDocumentRawSourceInfo, reviewFile, null);
    }
    if(this.approvalDocumentFile!=null){
      this.approvalDocumentRawSourceInfo = await this.helper.getDocumentSource('Approval_Evidence') as DocumentSource;
      const approveFile = this.approvalDocumentFile as File;
      approvalDocId = await this.PostDocument(this.approvalDocumentRawSourceInfo, approveFile, null);
    }
    console.log('review document file', this.reviewDocumentFile);
    if(this.formService.isEdit(this.issueValidationForm.get('id') as FormControl)){
      const PutRequestModel = {
        issueId: this.issueId,
        validatedByUserId: this.issueValidationForm.value.validatedByUserId,
        reviewedByUserID: this.issueValidationForm.value.reviewedByUserID,
        approvedByUserId: this.issueValidationForm.value.approvedByUserId,
        reviewEvidenceDocumentId: reviewDocId,
        approvalEvidenceDocumentId: approvalDocId,
        closureSummary: this.issueValidationForm.value.closureSummary,
        auditReportDate: this.issueValidationForm.value.auditReportDate,
        validationDate: this.issueValidationForm.value.validationDate,
        reviewDate: this.issueValidationForm.value.reviewDate,
        approvalDate: this.issueValidationForm.value.approvalDate,
        issueClosureDate: this.issueValidationForm.value.issueClosureDate,      
      };
      this.http.put('issuevalidation', PutRequestModel, null).subscribe(x=>{
        let resp = x as BaseResponse;
          if(resp.success){
            this.AlertService.successDialog('Updated',resp.message);
            this.router.navigate(['/branch-audit/issue-view', this.issueId]);
          }
          else{
            this.AlertService.errorDialog('Unsuccessful', resp.message);
          }
      });
    }
    else{
      const PostRequestModel = {
        issueId: this.issueId,
        validatedByUserId: this.issueValidationForm.value.validatedByUserId,
        reviewedByUserID: this.issueValidationForm.value.reviewedByUserID,
        approvedByUserId: this.issueValidationForm.value.approvedByUserId,
        reviewEvidenceDocumentId: reviewDocId,
        approvalEvidenceDocumentId: approvalDocId,
        closureSummary: this.issueValidationForm.value.closureSummary,
        auditReportDate: this.issueValidationForm.value.auditReportDate,
        validationDate: this.issueValidationForm.value.validationDate,
        reviewDate: this.issueValidationForm.value.reviewDate,
        approvalDate: this.issueValidationForm.value.approvalDate,
        issueClosureDate: this.issueValidationForm.value.issueClosureDate,      
      };
      this.http.post('issuevalidation',PostRequestModel).subscribe(x=>{
        let resp = x as BaseResponse;
        if(resp.success){
          this.AlertService.success('Issue Validation Saved successfully');
          this.router.navigate(['/branch-audit/issue-view', this.issueId]);
        }
        else{
          this.AlertService.errorDialog('Unsuccessful', resp.message);
        }            
      });
    }
  }
  onCancelValidationActionPlan(){
    if(this.issueId != undefined){
      this.router.navigate(['/branch-audit/issue-view', this.issueId]);
    }    
  }
  onUploadReviewEvidence(event:any){
    if (event.target.files.length > 0) {   
      this.reviewDocumentFile = event.target.files[0] as File;    
    }
  }
 
  onUploadApprovalEvidence(event:any){
    if (event.target.files.length > 0) {   
      this.approvalDocumentFile = event.target.files[0] as File;    
    }
  }

  async PostDocument(doc: DocumentSource, file: File, docId: any): Promise<any> {
    let v = await firstValueFrom(this.http.postFile(doc.id == null ? '' : doc.id, doc.name == null ? '' : doc.name, '', file, 'Document')) as FileResponseInterface;    
       let response = v as FileResponseInterface;
       docId = response.id;
     return docId;
  }
  fileDownLoad(d: any) {
    console.log(d);
    this.http.getFilesAsBlob('Document/get-file-stream?Id=' + d)
      .subscribe((resp: any) => {
        let fileName = resp.headers.get('content-disposition');
        console.log(fileName);
        this.helper.downloadFile(resp);
      }), (error: any) => console.log('Error downloading the file'),
      () => console.info('File downloaded successfully');
  }
}
