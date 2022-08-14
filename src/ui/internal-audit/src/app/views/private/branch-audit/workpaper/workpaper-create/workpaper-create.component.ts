import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AuditSchedule } from 'src/app/core/interfaces/branch-audit/auditSchedule.interface';
import { Branch } from 'src/app/core/interfaces/branch-audit/branch.interface';
import { questionnaire } from 'src/app/core/interfaces/branch-audit/questionnaire.interface';
import { topicHead } from 'src/app/core/interfaces/branch-audit/topicHead.interface';
import { workpaper } from 'src/app/core/interfaces/branch-audit/workpaper.interface';
import { commonValueAndType } from 'src/app/core/interfaces/configuration/commonValueAndType.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { FormService } from 'src/app/core/services/form.service';
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

  constructor(private http: HttpService , private fb: FormBuilder, private activateRoute: ActivatedRoute, private AlertService: AlertService) {
    this.loadDropDownValues();
    this.workpaperForm = this.fb.group({
      id: [''],
      workPaperCode: [''],
      auditScheduleId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      topicHeadId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      questionId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      branchId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      sampleName: [''],
      sampleMonthId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      sampleSelectionMethodId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      controlActivityNatureId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      controlFrequencyId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      sampleSizeId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      testingDetails: [''],
      testingResults: [''],
      testingConclusionId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      documentId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      testingDate: [Date,[Validators.required]],
    });
  }

  ngOnInit(): void {
    //this.paramId = this.activateRoute.snapshot.params['A1812E6F-098A-46EB-90F1-6508C8A8A6D2'];
    this.paramId = '1C67DC41-9E18-ED11-B3B2-00155D610B18';
    this.LoadScheduleData(this.paramId);
  }

  LoadScheduleData(Id:any):void {
    this.http
      .getById('workpaper',Id)
      .subscribe(res => {
           const scheduleData = res as workpaper;
          //  this.workpaperForm.auditScheduleId =scheduleData.employee.id;

          //  this.selectedUserCountry = userData.userCountries;
          //  this.selectedUserRole = userData.userRoles;
          
          //  console.log(this.selectedUserRole)
           this.workpaperForm.patchValue({auditScheduleId: scheduleData.sampleName,  });
      });
  
  }




  onSubmit():void{
      if(this.workpaperForm.valid){
       
          this.http.post('workpaper',this.workpaperForm.value).subscribe(x=>{ 
            this.AlertService.success('Workpaper Saved Successfully');
          }); 
          
        
      }
  }
  LoadTopicHeadDropdownList() 
  {
    this.http.paginatedPost('topicHead/paginated', 1000, 1, '').subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<topicHead>;
      this.topics = convertedResp.items;     
    })
  }
    LoadQuestions() {
    this.http.paginatedPost('questionnaire/paginated', 100, 1, {}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<questionnaire>;
      this.questions = convertedResp.items;
    })
  }
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
  LoadControlActivityNatures() {
    this.http.get('commonValueAndType/natureofcontrolactivity').subscribe(resp => {
      let convertedResp = resp as commonValueAndType[];
      this.controlActivityNatures = convertedResp;
    })
  }

  LoadControlFrequencies() {
    this.http.get('commonValueAndType/controlfrequency').subscribe(resp => {
      let convertedResp = resp as commonValueAndType[];
      this.controlFrequencies = convertedResp;
    })
  }
  LoadSampleSizes() {
    this.http.get('commonValueAndType/samplesize').subscribe(resp => {
      let convertedResp = resp as commonValueAndType[];
      this.sampleSizes = convertedResp;
    })
  }

  LoadBranches() {
    this.http.get('commonValueAndType/getBranch').subscribe(resp => {
      let convertedResp = resp as Branch[];
      this.branches = convertedResp;
      console.log(this.branches);
      
    })
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
    this.LoadControlFrequencies();
    this.LoadSampleSizes();
    this.LoadTestingConclusions();
    this.LoadTopicHeadDropdownList();
    this.LoadQuestions();
    //this.LoadBranches();
  }

}
