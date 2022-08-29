import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { firstValueFrom } from 'rxjs';
import { AuditSchedule } from 'src/app/core/interfaces/branch-audit/auditSchedule.interface';
import { AuditScheduleBranch, WPAuditScheduleBranch } from 'src/app/core/interfaces/branch-audit/auditScheduleBranch.interface';
import { Branch } from 'src/app/core/interfaces/branch-audit/branch.interface';
import { questionnaire } from 'src/app/core/interfaces/branch-audit/questionnaire.interface';
import { topicHead } from 'src/app/core/interfaces/branch-audit/topicHead.interface';
import { workpaper } from 'src/app/core/interfaces/branch-audit/workpaper.interface';
import { BaseResponse } from 'src/app/core/interfaces/common/base-response.interface';
import { commonValueAndType } from 'src/app/core/interfaces/configuration/commonValueAndType.interface';
import { FileResponseInterface } from 'src/app/core/interfaces/file-response.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { DocumentSource } from 'src/app/core/interfaces/uploaded-document.interface';
import { FormService } from 'src/app/core/services/form.service';
import { HelperService } from 'src/app/core/services/helper.service';
import { HttpService } from 'src/app/core/services/http.service';
import {AlertService} from '../../../../../core/services/alert.service';

@Component({
  selector: 'app-workpaper-create',
  templateUrl: './workpaper-create.component.html',
  styleUrls: ['./workpaper-create.component.scss']
})
export class WorkpaperCreateComponent implements OnInit {
  
  workpapers: workpaper[] = [];
  topics: topicHead[] =[];
  auditSchedules: AuditSchedule[] =[];
  questions: questionnaire[] =[];
  branches: Branch[] =[];
  sampledmonths: commonValueAndType[] = [];
  sampleSelectionMethods: commonValueAndType[] = [];
  controlActivityNatures: commonValueAndType[] = [];
  controlFrequencies: commonValueAndType[] = [];
  sampleSizes: commonValueAndType[] = [];
  testingConclusions: commonValueAndType[] = [];
  workpaperForm: FormGroup;
  formService: FormService = new FormService();
  paramId:string ='';
  workpaperId:string ='';
  wpAuditScheduleBranches : WPAuditScheduleBranch[] = [];
  globalFile: File | any = null;
  documentRawSourceInfo: DocumentSource = {};
  uploadDocumentForm: FormGroup | undefined;
  pageName:string = '';
  isRequired: boolean = false;
  editDocId:string|undefined='';

  constructor(private http: HttpService ,private router : Router, private fb: FormBuilder, private activateRoute: ActivatedRoute, private AlertService: AlertService, private helper: HelperService) {
    this.loadDropDownValues();
    this.workpaperForm = this.fb.group({
      id : [''],
      workPaperCode: [''],
      scheduleCode:[''],
      topicHeadId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      questionId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      auditScheduleBranchId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      testingDate: [Date,[Validators.required]],
      scheduleStartDate:[Date],
      scheduleEndDate:[Date],
      sampleName: [null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      sampleMonthId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      sampleSelectionMethodId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      controlActivityNatureId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      controlFrequencyId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      sampleSizeId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      testingDetails: [null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      testingResults: [null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      testingConclusionId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      documentId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      
    });
  }

  async ngOnInit() {
    this.workpaperId = this.activateRoute.snapshot.params['id'];
    this.documentRawSourceInfo = await this.helper.getDocumentSource('Work_Paper') as DocumentSource;
    if(this.workpaperId === undefined){
      this.pageName='Create';
   
      this.paramId = 'A1812E6F-098A-46EB-90F1-6508C8A8A6D2';
      this.LoadScheduleData(this.paramId);
    }
    else{
      this.pageName='Edit';
      this.workpaperForm.get('documentId')?.clearValidators();//clearValidators
      this.workpaperForm.get('documentId')?.updateValueAndValidity();//updateValueAndValidity
      this.LoadWorkpaperById(this.workpaperId);
    }
  }

 LoadWorkpaperById(Id:any){
  
    this.http
      .getById('workpaper',Id)
      .subscribe( res => {
           const workpaperData = res as workpaper;
           this.LoadControlFrequency(workpaperData.controlActivityNatureId == null? null : workpaperData.controlActivityNatureId);
           this.LoadSampleSize(workpaperData.controlFrequencyId == null?  null : workpaperData.controlFrequencyId);
            this.LoadBranches(workpaperData.auditScheduleId);
            this.editDocId=workpaperData.documentId;
           this.workpaperForm.patchValue({

            id: workpaperData.id,
            workPaperCode:  workpaperData.workPaperCode,
            scheduleCode:workpaperData.scheduleCode,
            topicHeadId: workpaperData.topicHeadId,
            questionId: workpaperData.questionId,
            auditScheduleBranchId: workpaperData.auditScheduleBranchId,
            testingDate: formatDate(workpaperData.testingDate, 'yyyy-MM-dd', 'en') ,
            scheduleStartDate: formatDate(workpaperData.scheduleStartDate, 'yyyy-MM-dd', 'en') ,
            scheduleEndDate: formatDate(workpaperData.scheduleEndDate, 'yyyy-MM-dd', 'en') ,
            sampleName : workpaperData.sampleName,
            sampleMonthId: workpaperData.sampleMonthId,
            sampleSelectionMethodId: workpaperData.sampleSelectionMethodId,
            controlActivityNatureId: workpaperData.controlActivityNatureId,
            controlFrequencyId: workpaperData.controlFrequencyId,
            sampleSizeId: workpaperData.sampleSizeId,
            testingDetails: workpaperData.testingDetails,
            testingResults: workpaperData.testingResults,
            testingConclusionId: workpaperData.testingConclusionId,
          });
          });
  }


  LoadScheduleData(Id:any):void {
    this.http
      .getById('AuditSchedule',Id)
      .subscribe(res => {
           const scheduleData = res as AuditSchedule;
          let scheduleId = scheduleData.id;
          let countryId = scheduleData.countryId;
          this.GetWorkPaperCode(countryId);
          this.LoadBranches(scheduleId);
           this.workpaperForm.patchValue({
            scheduleCode: scheduleData.scheduleId,
            scheduleStartDate: formatDate(scheduleData.scheduleStartDate, 'yyyy-MM-dd', 'en') ,
            scheduleEndDate:  formatDate(scheduleData.scheduleEndDate, 'yyyy-MM-dd', 'en') });
      });
  
  }

  GetWorkPaperCode(countryId:any) :void {
    if( countryId !="null"){
      this.http.get('commonValueAndType/idcreation?idcreationValue=17&auditType=1&countryId='+ countryId +'')
    .subscribe(resp => {
      const convertedResp = resp as commonValueAndType;
      this.workpaperForm.patchValue({
        workPaperCode : convertedResp.text,
      });
    })
    }
    
  }

 async onSubmit(){
 
    if(this.workpaperForm.valid){
      console.log(this.pageName);
      let doc = this.documentRawSourceInfo;
      const file = this.globalFile as File;
      let docId = null;
      if(this.isRequired){
        docId =await this.PostDocument(doc, file, docId);
       this.editDocId=docId;
      }
      if(this.pageName== 'Create'){
        const requestModel = {
          workPaperCode: this.workpaperForm.value?.workPaperCode,
          auditScheduleId: this.paramId,
          topicHeadId: this.workpaperForm.value.topicHeadId,
          questionId: this.workpaperForm.value.questionId,
          auditScheduleBranchId: this.workpaperForm.value.auditScheduleBranchId,
          sampleName: this.workpaperForm.value.sampleName,
          sampleMonthId: this.workpaperForm.value.sampleMonthId,
          sampleSelectionMethodId: this.workpaperForm.value.sampleSelectionMethodId,
          controlActivityNatureId: this.workpaperForm.value.controlActivityNatureId,
          controlFrequencyId: this.workpaperForm.value.controlFrequencyId,
          sampleSizeId: this.workpaperForm.value.sampleSizeId,
          testingDetails: this.workpaperForm.value.testingDetails,
          testingResults: this.workpaperForm.value.testingResults,
          testingConclusionId: this.workpaperForm.value.testingConclusionId,
          documentId: docId,
          testingDate: this.workpaperForm.value.testingDate,
        }
        this.http.post('workpaper',requestModel).subscribe(x=>{ 
          let resp = x as BaseResponse;
            if(resp.success){
              this.AlertService.success('Work Paper Saved Successful');
              this.router.navigate(['branch-audit/workpaper'], {
                // queryParams: {
                //   myParam: 'inserted', 
                // },
              });
            }else{
              this.AlertService.errorDialog('Work Paper Save Failed',resp.message);
            }
        }); 
      }
      else{
        const requestModel = {
          id:  this.workpaperForm.value?.id,
          workPaperCode: this.workpaperForm.value?.workPaperCode,
          auditScheduleId: this.paramId,
          topicHeadId: this.workpaperForm.value.topicHeadId,
          questionId: this.workpaperForm.value.questionId,
          auditScheduleBranchId: this.workpaperForm.value.auditScheduleBranchId,
          sampleName: this.workpaperForm.value.sampleName,
          sampleMonthId: this.workpaperForm.value.sampleMonthId,
          sampleSelectionMethodId: this.workpaperForm.value.sampleSelectionMethodId,
          controlActivityNatureId: this.workpaperForm.value.controlActivityNatureId,
          controlFrequencyId: this.workpaperForm.value.controlFrequencyId,
          sampleSizeId: this.workpaperForm.value.sampleSizeId,
          testingDetails: this.workpaperForm.value.testingDetails,
          testingResults: this.workpaperForm.value.testingResults,
          testingConclusionId: this.workpaperForm.value.testingConclusionId,
          documentId:this.editDocId,
          testingDate: this.workpaperForm.value.testingDate,
        }
        console.log(requestModel)
       // return;
        this.http.put('workpaper',requestModel,null).subscribe(x=>{ 
          let resp = x as BaseResponse;
            if(resp.success){
              this.AlertService.success('Work Paper Updated Successful');
              this.router.navigate(['branch-audit/workpaper'], {
                // queryParams: {
                //   myParam: 'inserted', 
                // },
              });
            }else{
              this.AlertService.errorDialog('Work Paper Updated Failed',resp.message);
            }
        }); 
      }

    }
    else{
      this.AlertService.error('Please fill all the data');
      this.workpaperForm.markAllAsTouched();
    }
  }

  async PostDocument(doc: DocumentSource, file: File, docId: any): Promise<any> {
   let v = await firstValueFrom(this.http.postFile(doc.id == null ? '' : doc.id, doc.name == null ? '' : doc.name, '', file, 'Document')) as FileResponseInterface;   
 

      let response = v as FileResponseInterface;
      docId = response.id;

   
    return docId;
  }

  edit():void{

  }

  LoadTopicHeadDropdownList() 
  {
    this.http.paginatedPost('topicHead/paginated', 1000, 1, '').subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<topicHead>;
      this.topics = convertedResp.items;     
    })
  }

  onChangeTopicHeadDropdownList(filter:string){
    if(filter=="null"){
      this.questions = [];
      this.workpaperForm.patchValue({questionId:"null"});
    }
    else{
      this.http.post('questionnaire/filter', {FilterName: 'TopicHeadId', FilterValue: filter}).subscribe(resp => {
        this.questions = resp as questionnaire[];
      })
    }
   
  }

  //   LoadQuestions() {
  //   this.http.paginatedPost('questionnaire/paginated', 100, 1, {}).subscribe(resp => {
  //     let convertedResp = resp as paginatedResponseInterface<questionnaire>;
  //     this.questions = convertedResp.items;
  //   })
  // }
  LoadSampledMonths() {
    this.http.get('commonValueAndType/sampledmonth').subscribe(resp => {
      let convertedResp = resp as commonValueAndType[];
      this.sampledmonths = convertedResp;
    })
  }
  LoadSampledSelectionMethods() {
    this.http.get('commonValueAndType/sampleselectionmethod').subscribe(resp => {
      let convertedResp = resp as commonValueAndType[];
      this.sampleSelectionMethods = convertedResp;
    })
  }


  

   LoadBranches(scheduleId:any) {
    this.http.get('commonValueAndType/getAuditScheduleBranch?ScheduleId='+ scheduleId +'').subscribe(resp => {
      let convertedResp = resp as WPAuditScheduleBranch[];
      this.wpAuditScheduleBranches = convertedResp;     
      
    })
    // let resp = await firstValueFrom(this.http.get('commonValueAndType/getAuditScheduleBranch?ScheduleId='+ scheduleId +'')) as WPAuditScheduleBranch[];
    //     let convertedResp = resp as WPAuditScheduleBranch[];
    //   this.wpAuditScheduleBranches = convertedResp;
    //   console.log("RASTRO",this.wpAuditScheduleBranches);
  }
  LoadTestingConclusions() {
    this.http.get('commonValueAndType/detestconclusion').subscribe(resp => {
      let convertedResp = resp as commonValueAndType[];
      this.testingConclusions = convertedResp;
    })
  }
  loadDropDownValues() 
  {
    this.LoadSampledMonths();
    this.LoadSampledSelectionMethods();
    this.LoadControlActivityNatures();
    this.LoadTestingConclusions();
    this.LoadTopicHeadDropdownList();
    //this.LoadQuestions();   
  }


  LoadControlActivityNatures() {
    this.http.get('commonValueAndType/natureofcontrolactivity').subscribe(resp => {
      let convertedResp = resp as commonValueAndType[];
      this.controlActivityNatures = convertedResp;
    })
  }

  onChangeControlActivityNatures(isNull: string,event: any) {
    if(isNull == "null"){
      this.controlFrequencies = [];
      this.sampleSizes = [];
      this.workpaperForm.patchValue({controlFrequencyId:"null"});
      this.workpaperForm.patchValue({sampleSizeId:"null"});     
    }
    else{
      this.LoadControlFrequency(event);
    }
  }

  onChnageLoadControlFrequency(isNull: string,event: any): void {
    if(isNull == "null"){
      this.sampleSizes = [];
      this.workpaperForm.patchValue({sampleSizeId:"null"});
    }
    else{
      this.http.get('commonValueAndType/ControlFrequencyId?ControlFrequencyId='+ event +'').subscribe(resp => {
        let convertedResp = resp as commonValueAndType[];
        this.sampleSizes = convertedResp;
      })
    }
   
  }

  LoadControlFrequency(event: any): void {
    this.http.get('commonValueAndType/ControlActivityId?ControlActivityId='+ event +'').subscribe(resp => {
      let convertedResp = resp as commonValueAndType[];
      this.controlFrequencies = convertedResp;
    })
  }

  LoadSampleSize(event: any): void {
    this.http.get('commonValueAndType/ControlFrequencyId?ControlFrequencyId='+ event +'').subscribe(resp => {
      let convertedResp = resp as commonValueAndType[];
      this.sampleSizes = convertedResp;
    })
  }
  onFileChange(event: any) {
    if (event.target.files.length > 0) {
      this.isRequired=true;
      let doc = this.documentRawSourceInfo;    
      this.globalFile = event.target.files[0] as File;    
    }

  }
  onCancel(){
    this.router.navigate(['branch-audit/workpaper']);
  }

}
