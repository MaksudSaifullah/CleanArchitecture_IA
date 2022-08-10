import { formatDate } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Audit } from 'src/app/core/interfaces/branch-audit/audit.interface';
import { AuditPlanCode } from 'src/app/core/interfaces/branch-audit/auditPlanCode.interface';
import { Branch } from 'src/app/core/interfaces/branch-audit/branch.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { HttpService } from 'src/app/core/services/http.service';
import {AlertService} from '../../../../core/services/alert.service';

@Component({
  selector: 'app-audit-view',
  templateUrl: './audit-view.component.html',
  styleUrls: ['./audit-view.component.scss']
})
export class AuditViewComponent implements OnInit {
  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings = {};
  dataTableService: DatatableService = new DatatableService();
  paramId:string ='';
  auditViewForm: FormGroup;
  auditPlanCodes: AuditPlanCode [] = [];
  branches: Branch[] = [];

  constructor(private http: HttpService, private fb: FormBuilder, private AlertService: AlertService, private router: Router,private activateRoute: ActivatedRoute) {
    this.auditViewForm = this.fb.group({
      id:[''],
      countryId: [null],
      auditTypeId:[null],
      auditId: [''],
      auditName:[''],
      year: [''],
      auditPlanId: [''],
      auditPeriodFrom: [''],
      auditPeriodTo: [''],
      
    })
   }

  ngOnInit(): void {
    this.paramId = this.activateRoute.snapshot.queryParams['id'];
    this.getAuditById(this.paramId);
   // console.log(this.paramId)
  }
  getAuditById(id:string):void {
    // console.log(id);
     this.http
       .getById('audit',id)
       .subscribe(res => {
           const auditResponse = res as Audit;
           this.auditViewForm.setValue({id : auditResponse.id,countryId:auditResponse.countryId,auditTypeId:auditResponse.auditTypeId, auditName: auditResponse.auditName, year:auditResponse.year, auditPlanId: "", auditId: auditResponse.auditId,  
             auditPeriodFrom: formatDate(auditResponse.auditPeriodFrom, 'yyyy-MM-dd', 'en'),
             auditPeriodTo: formatDate(auditResponse.auditPeriodTo, 'yyyy-MM-dd', 'en')});
 
             this.LoadAuditPlanCode();
             this.auditViewForm.patchValue({auditPlanId: auditResponse.auditPlanId })
 
       });
       
       this.disabledInputField();
       //this.LoadData();
   }
  // LoadData() {
  //   const that = this;
  //   var formValue=this.auditViewForm.getRawValue();
  //  // console.log(formValue.auditId)
  //   const countryId=this.auditViewForm.value.countryId;
  //   this.dtOptions = {
  //     pagingType: 'full_numbers',
  //     pageLength: 10,
  //     serverSide: true,
  //     processing: true,
  //     searching: false,
  //     ordering:false,
  //     ajax: (dataTablesParameters: any, callback) => {
  //       this.http.get('commonValueAndType/getBranch?countryId='+'3ee0ab25-baf2-ec11-b3b0-00155d610b18').subscribe(resp => that.branches = this.dataTableService.datatableMap(resp,callback));
  //     },
  //   };
  // }


  // LoadBranch(){
  //   const formValue=this.auditViewForm.getRawValue();
  //   this.http.get('commonValueAndType/getBranch?countryId='+formValue.countryId).subscribe(resp => {
  //     let convertedResp = resp as Branch[];
  //     this.branches = convertedResp;
  //   })
  // }
  LoadAuditPlanCode(){
    this.auditPlanCodes=[];
    var auditFormValue=this.auditViewForm.getRawValue();
    this.http.paginatedPost('audit/paginatedAuditPlanCode', 100 , 1 , {"countryId": auditFormValue.countryId ,"auditTypeId":auditFormValue.auditTypeId}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<AuditPlanCode>;
      this.auditPlanCodes = convertedResp.items;
    })
    //console.log(this.auditPlanCodes)
  }
  RedirectToAuditList(){
    console.log("sldjflsdf")
    this.router.navigate(['branch-audit/audit']);
  }
  RedirectToScheduleList(){
    var formValue=this.auditViewForm.getRawValue();
    //console.log(formValue.auditId)
    this.router.navigate(['branch-audit/audit-schedule'], {queryParams: {id:formValue.id}});
  }
  disabledInputField(){
    this.auditViewForm.controls['auditName'].disable();
    this.auditViewForm.controls['auditId'].disable();
    this.auditViewForm.controls['year'].disable();
    this.auditViewForm.controls['auditPlanId'].disable();
    this.auditViewForm.controls['auditPeriodFrom'].disable();
    this.auditViewForm.controls['auditPeriodTo'].disable();
 }

}
