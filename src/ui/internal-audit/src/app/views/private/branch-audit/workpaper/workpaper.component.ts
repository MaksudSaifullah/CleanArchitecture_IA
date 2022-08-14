import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { DataTableDirective } from 'angular-datatables';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';
import { workpaper } from '../../../../core/interfaces/branch-audit/workpaper.interface';
import {AlertService} from '../../../../core/services/alert.service';
import { Subject } from 'rxjs';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { topicHead } from 'src/app/core/interfaces/branch-audit/topicHead.interface';
import { commonValueAndType } from 'src/app/core/interfaces/configuration/commonValueAndType.interface';
import { questionnaire } from 'src/app/core/interfaces/branch-audit/questionnaire.interface';
import { Branch } from 'src/app/core/interfaces/branch-audit/branch.interface';

@Component({
  selector: 'app-workpaper',
  templateUrl: './workpaper.component.html',
  styleUrls: ['./workpaper.component.scss']
})
export class WorkpaperComponent implements OnInit {

  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings = {};
  workpapers: workpaper[] = [];
  topics: topicHead[] =[];
  questions: questionnaire[] =[];
  branches: Branch[] =[];
  sampledmonths: commonValueAndType[] = [];
  sampleSelectionMethods: commonValueAndType[] = [];
  controlActivityNatures: commonValueAndType[] = [];
  controlFrequencies: commonValueAndType[] = [];
  sampleSizes: commonValueAndType[] = [];
  testingConclusions: commonValueAndType[] = [];
  searchForm: FormGroup;
  workpaperForm: FormGroup;
  formService: FormService = new FormService();
  dataTableService: DatatableService = new DatatableService();
  dtTrigger: Subject<any> = new Subject<any>();
 

  constructor(private http: HttpService , private fb: FormBuilder, private AlertService: AlertService) {
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
      documentId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]]
    });
    this.searchForm = this.fb.group(
      {
        topicHeadId:[''],
      }
    )
  }
  ngOnInit(): void {
    this.LoadData();
  }
  LoadData() {
    const that = this;

    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      serverSide: true,
      processing: true,
      searching: false,
      ordering: false,
      ajax: (dataTablesParameters: any, callback) => {
        this.http
          .paginatedPost(
            'workpaper/paginated',dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1), this.searchForm.get('topicHeadId')?.value)
            .subscribe(resp => that.workpapers = this.dataTableService.datatableMap(resp,callback));
      },
    };

  }

  onSubmit(modalId:any):void{
    const localmodalId = modalId;
      if(this.workpaperForm.valid){
        if(this.formService.isEdit(this.workpaperForm.get('id') as FormControl)){
          this.http.put('workpaper',this.workpaperForm.value,null).subscribe(x=>{
            this.formService.onSaveSuccess(localmodalId,this.datatableElement);
            this.AlertService.success('Workpaper Updated Successfully');
            });
        }
        else{
          this.http.post('workpaper',this.workpaperForm.value).subscribe(x=>{ 
            this.formService.onSaveSuccess(localmodalId, this.datatableElement);
            this.AlertService.success('Workpaper Saved Successfully');
          }); 
          
        }
      }
  }

  edit(modalId:any, workpaper:any):void {
    const localmodalId = modalId;
    console.log(workpaper.id)
    this.http
      .getById('workpaper',workpaper.id)
      .subscribe(res => {
          const workpaperResponse = res as workpaper;
         // this.workpaperForm.setValue({id : workpaperResponse.id, name : workpaperResponse.name, remarks: countryResponse.remarks, code: countryResponse.code});
      });
      localmodalId.visible = true;
  }
  delete(id:string){
    const that = this;
    this.AlertService.confirmDialog().then(res =>{
      if(res.isConfirmed){
          this.http.delete('workpaper/'+ id ,{}).subscribe(response=>{
          this.AlertService.successDialog('Deleted','workpaper deleted successfully.');
          this.dataTableService.redraw(that.datatableElement);
        })
      }
    });
  }
  reset(){
    this.workpaperForm.reset();
  }
  search(){
    this.dataTableService.redraw(this.datatableElement);
  }

  // LoadTopicHeads() {
  //   this.http.paginatedPost('topicHead/paginated', 100, 1, {}).subscribe(resp => {
  //     let convertedResp = resp as paginatedResponseInterface<topicHead>;
  //     this.topicheads = convertedResp.items;     
  //   })
  // }
  // LoadYear() {
  //   this.http.get('topicHead/paginated').subscribe(resp => {
  //     let convertedResp = resp as commonValueAndType[];
  //     this.year = convertedResp; 
  //   })
  // }
  
  // LoadTopics() {
  //   this.http.paginatedPost('topicHead/paginated', 100, 1, {}).subscribe(resp => {
  //     let convertedResp = resp as paginatedResponseInterface<topicHead>;
  //     this.topics = convertedResp.items;
  //     console.log(this.topics);
  //   })
  // }

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
