import { formatDate } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Audit } from 'src/app/core/interfaces/branch-audit/audit.interface';
import { AuditPlanCode } from 'src/app/core/interfaces/branch-audit/auditPlanCode.interface';
import { commonValueAndType } from 'src/app/core/interfaces/configuration/commonValueAndType.interface';
import { country } from 'src/app/core/interfaces/configuration/country.interface';
import { Branch } from 'src/app/core/interfaces/branch-audit/branch.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';
import {AlertService} from '../../../../core/services/alert.service';

@Component({
  selector: 'app-audit-schedule',
  templateUrl: './audit-schedule.component.html',
  styleUrls: ['./audit-schedule.component.scss']
})
export class AuditScheduleComponent implements OnInit {
  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings = {};
  dataTableService: DatatableService = new DatatableService();
  audits: Audit[] = [];
  formService: FormService = new FormService();
  auditForm: FormGroup;
  auditSearchForm: FormGroup;
  countries: country[] = [];
  branches: Branch[] = [];
  auditTypes: commonValueAndType[] = [];
  auditIds: commonValueAndType | undefined;
  auditPlanCodes: AuditPlanCode [] = [];
  paramId:string ='';

  constructor(private http: HttpService, private fb: FormBuilder,  private activateRoute: ActivatedRoute, private AlertService: AlertService) {
    this.auditForm = this.fb.group({
      id: [''],
      auditTypeId: ["3ee0ab25-baf2-ec11-b3b0-00155d610b11"],
      countryId: [null,[Validators.required]],
      year: ['',[Validators.required,Validators.maxLength(4),Validators.minLength(4)]],
      planId: ['',[Validators.required]],
      auditId: ['',[Validators.required]],
      auditName:['',[Validators.required]],
      auditPeriodFrom: ['',[Validators.required]],
      auditPeriodTo: ['',[Validators.required]],
      
    })

    this.auditSearchForm = this.fb.group({
      searchText:['']
    })
   }

  ngOnInit(): void {
    this.paramId = this.activateRoute.snapshot.params['id'];
   this.LoadData();
   this.LoadCountry();
   this.LoadAuditType();
   //this.LoadAuditId();

  }
  LoadData() {
    const that = this;
    
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      serverSide: true,
      processing: true,
      searching: false,
      ordering:false,
      ajax: (dataTablesParameters: any, callback) => {
        this.http
          .paginatedPost(
            'audit/paginated',dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1),{"auditId": this.auditSearchForm.value.searchText}
          ).subscribe(resp => that.audits = this.dataTableService.datatableMap(resp,callback));
      },
    };
  }
  LoadAuditId(){
    this.http.get('commonValueAndType/idcreation?idcreationValue=16&auditType=1&countryId='+this.auditForm.value.countryId).subscribe(resp => {
      let convertedResp = resp as commonValueAndType;
      this.auditIds = convertedResp;
      this.auditForm.patchValue({auditId: this.auditIds.text})
      this.LoadBranch();
    })
  }
  LoadBranch(){
    const countryId=this.auditForm.value.countryId;
    this.http.get('commonValueAndType/getBranch?countryId='+countryId).subscribe(resp => {
      let convertedResp = resp as Branch[];
      this.branches = convertedResp;
    })
  }
  LoadCountry() {
    this.http.paginatedPost('country/paginated', 100, 1, {}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<country>;
      this.countries = convertedResp.items;    
    })
  }
  LoadAuditType() {
    this.http.get('commonValueAndType/audittype').subscribe(resp => {
      let convertedResp = resp as commonValueAndType[];
      this.auditTypes = convertedResp;
    })
  }
  
  search(){
     this.dataTableService.redraw(this.datatableElement);
   }
  onSubmit(modalId:any):void{
    const localmodalId = modalId;
      if(this.auditForm.valid){
        if(this.formService.isEdit(this.auditForm.get('id') as FormControl)){
          this.http.put('audit',this.auditForm.getRawValue(),null).subscribe(x=>{
            this.formService.onSaveSuccess(localmodalId,this.datatableElement);
            this.AlertService.success('Audit Saved Successful');

          });
        }
        else{
          console.log(this.auditForm.value);
          this.http.post('audit',this.auditForm.getRawValue()).subscribe(x=>{
            this.formService.onSaveSuccess(localmodalId,this.datatableElement);
            this.AlertService.success('Audit Saved Successful');
          });
        }
      }
  }
  edit(modalId:any, audit:any):void {
    const localmodalId = modalId;
    console.log(audit)
    this.http
      .getById('audit',audit.id)
      .subscribe(res => {
          const auditResponse = res as Audit;
          this.auditForm.setValue({id : auditResponse.id, countryId : auditResponse.countryId, auditName: auditResponse.auditName, year:auditResponse.year, auditTypeId: auditResponse.auditTypeId, planId: auditResponse.planId, auditId: auditResponse.auditId, 
            auditPeriodFrom: formatDate(auditResponse.auditPeriodFrom, 'yyyy-MM-dd', 'en'),
            auditPeriodTo: formatDate(auditResponse.auditPeriodTo, 'yyyy-MM-dd', 'en')});
      });
      localmodalId.visible = true;
  }

  reset(){
    this.auditForm.reset();
    this.auditForm.patchValue({auditTypeId:"3ee0ab25-baf2-ec11-b3b0-00155d610b11"});
     this.auditForm.controls['auditTypeId'].disable();
     this.auditForm.controls['auditId'].disable();
  }

}
