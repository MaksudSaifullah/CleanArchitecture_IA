import { Component, Input, OnInit, QueryList, ViewChildren } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { DataTableDirective } from 'angular-datatables';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';
import { AlertService } from '../../../../core/services/alert.service';
import { topicHead } from 'src/app/core/interfaces/branch-audit/topicHead.interface';
import { questionnaire } from 'src/app/core/interfaces/branch-audit/questionnaire.interface';
import { country } from 'src/app/core/interfaces/configuration/country.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';

@Component({
  selector: 'app-topic-head',
  templateUrl: './topic-head.component.html',
  styleUrls: ['./topic-head.component.scss']
})
export class TopicHeadComponent implements OnInit  {
  @Input('tabPaneIdx')
  tabIndex!: string;

  @ViewChildren(DataTableDirective)
  dtElements: QueryList<DataTableDirective> | undefined;
  //datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings[] = [];
  topicHeadForm: FormGroup;
  formService: FormService = new FormService();
  dataTableService: DatatableService = new DatatableService();
  topicheads: topicHead[] = [];
  countries: country[] = [];
  searchForm: FormGroup;

  
  questionnaireForm: FormGroup;
  searchForm2: FormGroup;
  questionnaires: questionnaire[] = [];
  topicheadDropdownList: topicHead[] = [];

  constructor(private http: HttpService, private fb: FormBuilder, private AlertService: AlertService) 
  {
    this.loadDropDownValues();
    this.LoadTopicHeadDropdownList();
    this.topicHeadForm = this.fb.group({
      id: [''],
      countryId: [null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      name: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      effectiveFrom: [Date, [Validators.required]],
      effectiveTo: [Date, [Validators.required]],
      description: ['', [Validators.maxLength(300)]],
      // isActive: [''],
    });
    this.searchForm = this.fb.group({
        searchTerm: ['']
    });
    this.questionnaireForm = this.fb.group({
      id: [''],
      countryId: [null],
      topicHeadId: [null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      effectiveFrom: [, [Validators.required]],
      effectiveTo: [, [Validators.required]],
      question: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(500)]],      
    });
    this.searchForm2 = this.fb.group({
        searchTerm2: ['']
    });

  }

  ngOnInit(): void {
    this.LoadData();
    this.LoadQuestionnaireData();
  }

  LoadData() {
    const that = this;

    this.dtOptions[0] = {
      pagingType: 'full_numbers',
      pageLength: 10,
      serverSide: true,
      processing: true,
      searching: false,
      ordering: false,
      ajax: (dataTablesParameters: any, callback) => {
        this.http
          .paginatedPost(
            'topicHead/paginated', dataTablesParameters.length, ((dataTablesParameters.start / dataTablesParameters.length) + 1), this.searchForm.get('searchTerm')?.value
          ).subscribe(resp => that.topicheads = this.dataTableService.datatableMap(resp, callback));
      },
    };
  }

  loadDropDownValues() 
  {
    this.LoadCountries();
  }

  LoadCountries() 
  {
    this.http.paginatedPost('country/paginated', 100, 1, {}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<country>;
      this.countries = convertedResp.items;     
    })
  }

  onSubmit(modalId:any):void 
  {
    const localmodalId = modalId;
    if (this.topicHeadForm.valid ){
      if(this.formService.isEdit(this.topicHeadForm.get('id') as FormControl)){
        this.http.put('topicHead',this.topicHeadForm.value,null).subscribe(x=>{
          this.formService.onSaveSuccess(localmodalId, this.ReloadAllDataTable());          
          this.AlertService.success('Topic Head Updated Successful');
        });
      }
      else {
       // console.log(this.riskProfileForm.value);
        this.http.post('topicHead',this.topicHeadForm.value).subscribe(x=>{
          this.formService.onSaveSuccess(localmodalId,this.ReloadAllDataTable());
          this.AlertService.success('Topic Head Saved successfully');
        });
      }      
    }
    else {     
      this.topicHeadForm.markAllAsTouched();
      return;
    }    
  }
  edit(modalId: any, topicHead: any): void {
    const localmodalId = modalId;
    console.log(topicHead);
    this.http
      .getById('topichead', 'id?Id='+ topicHead.id)
      .subscribe(res => {
        const response = res as topicHead;      
        this.topicHeadForm.setValue({ id: response.id,
          countryId: response.countryId,
          name: response.name, 
          effectiveFrom: response.effectiveFrom, effectiveTo: response.effectiveTo, 
          description: response.description });
      });
    localmodalId.visible = true;
  }

  private ReloadAllDataTable() {
    this.dtElements?.forEach((dtElement: DataTableDirective, index: number) => {
      this.dataTableService.redraw(dtElement);
    });
  }
  reset(){
    this.topicHeadForm.reset();
    this.questionnaireForm.reset();
  }
  search(){
    this.ReloadAllDataTable();
  }
  
  delete(id: string) {
    const that = this;
    this.AlertService.confirmDialog().then(res => {
      if (res.isConfirmed) {
        this.http.delete('topicHead/id?Id=' + id, {}).subscribe(response => {
          this.AlertService.successDialog('Deleted', 'Topic Head deleted successfully.');
          this.ReloadAllDataTable();
        })
      }
    });
  }

//questionnaire
  LoadTopicHeadDropdownList() 
  {
    this.http.paginatedPost('topicHead/paginated', 1000, 1, '').subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<topicHead>;
      this.topicheadDropdownList = convertedResp.items;     
    })
  }

  LoadQuestionnaireData(){
   // this.LoadTopicHeadDropdownList();
    const that = this;

    this.dtOptions[2] = {
      pagingType: 'full_numbers',
      pageLength: 10,
      serverSide: true,
      processing: true,
      searching: false,
      ordering: false,
      ajax: (dataTablesParameters: any, callback) => {
        this.http
          .paginatedPost(
            'questionnaire/paginated', dataTablesParameters.length, ((dataTablesParameters.start / dataTablesParameters.length) + 1), this.searchForm2.get('searchTerm2')?.value
          ).subscribe(resp => that.questionnaires = this.dataTableService.datatableMap(resp, callback));
          // console.log('---------------')
          // console.log(this.questionnaires);
          // console.log('---------------')
      },
    };
  }
  onSubmitQuestionnaire(modalId:any):void 
  {
    console.log('-------------------------------------------');
    console.log(this.questionnaireForm.get('effectiveFrom'));
    console.log(this.questionnaireForm.get('effectiveFrom')?.value);
    console.log('-------------------------------------------');
    const localmodalId = modalId;
    if (this.questionnaireForm.valid ){
      if(this.formService.isEdit(this.questionnaireForm.get('id') as FormControl)){
        this.http.put('questionnaire',this.questionnaireForm.value,null).subscribe(x=>{
          this.formService.onSaveSuccess(localmodalId, this.ReloadAllDataTable());          
          this.AlertService.success('Questionnaire Updated Successful');
        });
      }
      else {
       // console.log(this.questionnaireForm.value);
        this.http.post('questionnaire',this.questionnaireForm.value).subscribe(x=>{
          this.formService.onSaveSuccess(localmodalId,this.ReloadAllDataTable());
          this.AlertService.success('Questionnaire Saved successfully');
        });
      }      
    }
    else {     
      this.questionnaireForm.markAllAsTouched();
      return;
    }    
  }
  onChangeTopic(e: any){
    const topic = this.questionnaireForm.get('topicHeadId')?.value;
    console.log(topic);
    this.http
      .getById('topichead', 'id?Id='+ topic)
      .subscribe(res => {
        const response = res as topicHead;      

        this.questionnaireForm.patchValue({
          countryId : response.countryId,
        });    
        // this.topicHeadForm.setValue({ id: response.id,
        //   countryId: response.countryId,
        //   name: response.name, 
        //   effectiveFrom: response.effectiveFrom, effectiveTo: response.effectiveTo, 
        //   description: response.description });
      });
      console.log(this.questionnaireForm.get('countryId')?.value);
  }
  deleteQuestionnaire(id: string) {
    const that = this;
    this.AlertService.confirmDialog().then(res => {
      if (res.isConfirmed) {
        this.http.delete('questionnaire/id?Id=' + id, {}).subscribe(response => {
          this.AlertService.successDialog('Deleted', 'Questionnaire deleted successfully.');
          this.ReloadAllDataTable();
        })
      }
    });
  }
  editQuestionnaire(modalId: any, questionnaire: any):void
  {
    const localmodalId = modalId;
    //console.log(questionnaire);
    this.http
      .getById('questionnaire', 'id?Id='+ questionnaire.id)
      .subscribe(res => {
        const response = res as questionnaire;  
        console.log(response);    
        this.questionnaireForm.setValue({ id: response.id,
          countryId: response.countryId,
          topicHeadId: response.topicHeadId,
          question: response.question, 
          effectiveFrom: response.effectiveFrom, 
          effectiveTo: response.effectiveTo });
      });
    localmodalId.visible = true;

  }
}
