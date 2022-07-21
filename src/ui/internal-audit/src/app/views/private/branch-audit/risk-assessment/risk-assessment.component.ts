import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { commonValueAndType } from 'src/app/core/interfaces/configuration/commonValueAndType.interface';
import { country } from 'src/app/core/interfaces/configuration/country.interface';
import { riskAssessment } from 'src/app/core/interfaces/branch-audit/riskAssessment.interface';
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
  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings = {};
  auditType: commonValueAndType[] = [];
  riskAssessments: riskAssessment[] = [];
  riskAssessmentForm: FormGroup;
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
      
    })

  }

  ngOnDestroy(): void {

  }
  ngOnInit(): void {   
    this.LoadData();
  };

  LoadData() {
    const that = this;
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      serverSide: true,
      processing: true,
      searching: false,
      ajax: (dataTablesParameters: any, callback) => {
        this.http
          .paginatedPost(
            'riskassessment/paginated',dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1),{}
          ).subscribe(resp => that.riskAssessments = this.dataTableService.datatableMap(resp,callback));
      },
    };

  }

  onSubmit(modalId:any):void{
    const localmodalId = modalId;
    if (this.riskAssessmentForm.valid ){
      if(this.formService.isEdit(this.riskAssessmentForm.get('id') as FormControl)){
        this.http.put('riskassessment',this.riskAssessmentForm.value,null).subscribe(x=>{
            localmodalId.visible = false;
            this.dataTableService.redraw(this.datatableElement);
            this.AlertService.success('Risk Assessment Saved Successful');
          });
      }
      else {
        console.log(JSON.stringify(this.riskAssessmentForm.value))
        this.http.post('riskassessment',this.riskAssessmentForm.value).subscribe(x=>{ 
          this.formService.onSaveSuccess(localmodalId,this.datatableElement);
          this.AlertService.success('Risk Assessment Saved successfully');
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
          this.effectiveFrom = riskAssessmentResponse.effectiveFrom;
          this.riskAssessmentForm.setValue({id : riskAssessmentResponse.id, countryId : riskAssessmentResponse.countryId, 
            auditTypeId: riskAssessmentResponse.auditTypeId,
            effectiveFrom: formatDate(riskAssessmentResponse.effectiveFrom, 'yyyy-MM-dd', 'en'), effectiveTo: formatDate(riskAssessmentResponse.effectiveTo, 'yyyy-MM-dd', 'en')
          });
      });
      localmodalId.visible = true;
      
  }

  delete(id:string){
    const that = this;
    this.AlertService.confirmDialog().then(res =>{
      if(res.isConfirmed){
          this.http.delete('riskAssessment/'+ id ,{}).subscribe(response=>{
          this.AlertService.successDialog('Deleted','Risk Profile deleted successfully.');
          this.dataTableService.redraw(that.datatableElement);
        })
      }
    });
  }
  reset(){
    this.riskAssessmentForm.reset();
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
      //this.Data=convertedResp.items;
     
    })
  }

  LoadDropDownValues() {
    this.LoadAuditType();
    this.LoadCountry();
  }
}
