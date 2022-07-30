import { Component, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { commonValueAndType } from 'src/app/core/interfaces/configuration/commonValueAndType.interface';
import { country } from 'src/app/core/interfaces/configuration/country.interface';
import { riskAssessment } from 'src/app/core/interfaces/branch-audit/riskAssessment.interface';
import { auditPlan } from 'src/app/core/interfaces/branch-audit/auditPlan.interface';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';
import {AlertService} from '../../../../core/services/alert.service';
import { formatDate } from '@angular/common';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';

@Component({
  selector: 'app-risk-assessment',
  templateUrl: './risk-assessment.component.html',
  styleUrls: ['./risk-assessment.component.scss']
})
export class RiskAssessmentComponent implements OnInit {
  @ViewChildren(DataTableDirective)
  dtElements: QueryList<DataTableDirective> | undefined;
 // datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings[] = [];
  auditType: commonValueAndType[] = [];
  year: commonValueAndType[] = [];
  planningYear: commonValueAndType[] = [];
  riskAssessments: riskAssessment[] = [];
  auditPlans: auditPlan[] = [];
  riskAssessmentForm: FormGroup;
  auditPlanForm: FormGroup;
  searchForm: FormGroup;
  searchForm1: FormGroup;
  formService: FormService = new FormService();
  dataTableService: DatatableService = new DatatableService();
  dtTrigger: Subject<any> = new Subject<any>();
  effectiveFrom: any;
  countries: country[] = [];
  Data: Array<any> = [];

  constructor(private http: HttpService , private fb: FormBuilder, private AlertService: AlertService) { 

    this.LoadDropDownValues();
    this.riskAssessmentForm = this.fb.group({
      id: [''],
      countryId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      auditTypeId: [null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      assesmentCode: [''],
      effectiveFrom: [Date,[Validators.required]],
      effectiveTo: [Date, [Validators.required]],
      
    });
    this.searchForm = this.fb.group(
      {
        searchTerm: [''],
        year:['']
      }
    );
    this.auditPlanForm = this.fb.group({
      id: [''],
      planCode: [''],
      countryId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      auditTypeId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      planningYearId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      riskAssesmentId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      assesmentFrom: [Date,[Validators.required]],
      assesmentTo: [Date, [Validators.required]],
    });
    this.searchForm1 = this.fb.group(
      {
        searchTerm: ['']
      }
    );
  }

  ngOnDestroy(): void {

  }
  ngOnInit(): void {   
    this.LoadData();
    this.LoadAuditPlanData();
    console.log('hwlllloooo', this.auditPlanForm);
  };

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
            'riskassessment/paginated',dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1),
            {"searchTerm" : this.searchForm.get('searchTerm')?.value, "year" : this.searchForm.get('year')?.value } )
            .subscribe(resp => that.riskAssessments = this.dataTableService.datatableMap(resp,callback));
      },
    };

  }

  onSubmit(modalId:any):void{
    const localmodalId = modalId;
    if (this.riskAssessmentForm.valid ){
      if(this.formService.isEdit(this.riskAssessmentForm.get('id') as FormControl)){
        this.http.put('riskassessment',this.riskAssessmentForm.value,null).subscribe(x=>{
          this.formService.onSaveSuccess(localmodalId,this.ReloadAllDataTable());
            this.AlertService.success('Risk Assessment Updated Successfully');
          });
      }
      else {
        console.log(JSON.stringify(this.riskAssessmentForm.value))
        this.http.post('riskassessment',this.riskAssessmentForm.value).subscribe(x=>{ 
          this.formService.onSaveSuccess(localmodalId, this.ReloadAllDataTable());
          this.AlertService.success('Risk Assessment Saved Successfully');
        });
      }      
    }
    else {     
      this.riskAssessmentForm.markAllAsTouched();
      return;
    }    
  }


  edit(modalId:any, riskAssessment:any):void {
    const localmodalId = modalId;
    this.http
      .getById('riskAssessment', riskAssessment.id)
      .subscribe(res => {
          const riskAssessmentResponse = res as riskAssessment;
          console.log('RiskAssesment', riskAssessment);
          this.riskAssessmentForm.setValue({
            id : riskAssessmentResponse.id, 
            countryId : riskAssessmentResponse.countryId, 
            auditTypeId: riskAssessmentResponse.auditTypeId, 
            assesmentCode: riskAssessmentResponse.assesmentCode, 
            effectiveFrom: formatDate(riskAssessmentResponse.effectiveFrom, 'yyyy-MM-dd', 'en'), 
            effectiveTo: formatDate(riskAssessmentResponse.effectiveTo, 'yyyy-MM-dd', 'en')
          });
      });
      localmodalId.visible = true;
      
  }

  delete(id:string){
    const that = this;
    this.AlertService.confirmDialog().then(res =>{
      if(res.isConfirmed){
          this.http.delete('riskAssessment/'+ id ,{}).subscribe(response=>{
          this.AlertService.successDialog('Deleted','Risk Assessment deleted successfully.');
          this.ReloadAllDataTable();
        })
      }
    });
  }
  reset(){
    this.riskAssessmentForm.reset();
  }

  
  search(){
    this.ReloadAllDataTable();
  }

  LoadAuditType() {
    this.http.get('commonValueAndType/audittype').subscribe(resp => {
      let convertedResp = resp as commonValueAndType[];
      console.log("AuditType",convertedResp)
      this.auditType = convertedResp;
    })
  }

  LoadCountry() {
    this.http.paginatedPost('country/paginated', 100, 1, {}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<country>;
      console.log("Country",convertedResp);
      this.countries = convertedResp.items;
    })
  }

  LoadYear() {
    this.http.get('commonValueAndType/year').subscribe(resp => {
      let convertedResp = resp as commonValueAndType[];
      console.log("YEAR", convertedResp);
      this.year = convertedResp;
    })
  }

  LoadDropDownValues() {
    this.LoadAuditType();
    this.LoadCountry();
    this.LoadYear();
  }

  private ReloadAllDataTable() {
    this.dtElements?.forEach((dtElement: DataTableDirective, index: number) => {
      this.dataTableService.redraw(dtElement);
    });
  }
 // #Region AuditType

    LoadAuditPlanData() {
      const that = this;
      this.dtOptions[1] = {
        pagingType: 'full_numbers',
        pageLength: 10,
        serverSide: true,
        processing: true,
        searching: false,
        ordering: false,
        ajax: (dataTablesParameters: any, callback) => {
          this.http
            .paginatedPost(
              'auditplan/paginated',dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1), this.searchForm1.get('searchTerm')?.value)
              .subscribe(resp => that.auditPlans = this.dataTableService.datatableMap(resp,callback));
        },
      };
  
    }
    
    onAuditPlanSubmit(modalId:any):void{
      console.log('auditPlanForm', this.auditPlanForm);
      const localmodalId = modalId;
      if (this.auditPlanForm.valid ){
        if(this.formService.isEdit(this.auditPlanForm.get('id') as FormControl)){
          this.http.put('auditplan',this.auditPlanForm.value,null).subscribe(x=>{
            this.formService.onSaveSuccess(localmodalId,this.ReloadAllDataTable());
              this.AlertService.success('Audit Plan Updated Successfully');
            });
        }
        else {
          this.http.post('auditplan',this.auditPlanForm.value).subscribe(x=>{ 
            this.formService.onSaveSuccess(localmodalId, this.ReloadAllDataTable());
            this.AlertService.success('Audit Plan Saved Successfully');
          });
        }      
      }
      else {     
        this.auditPlanForm.markAllAsTouched();
        return;
      }    
    }

    // LoadAssessmentCode() {
    //   this.http.paginatedPost('riskassessment/paginated', 100, 1, {}).subscribe(resp => {
    //     debugger;
    //     let convertedResp = resp as paginatedResponseInterface<riskAssessment>;
    //     this.riskAssessments = convertedResp.items;
    //   })
    // }
  
 // #EndRegion AuditType
  
}
