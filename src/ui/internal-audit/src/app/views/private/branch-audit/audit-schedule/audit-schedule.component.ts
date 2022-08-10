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
import { AuditSchedule } from 'src/app/core/interfaces/branch-audit/auditSchedule.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';
import {AlertService} from '../../../../core/services/alert.service';
import { User } from 'src/app/core/interfaces/security/user-registration.interface';
import { AuditScheduleParticipant } from 'src/app/core/interfaces/branch-audit/auditScheduleParticipant.interface';

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
  auditSchedules: AuditSchedule[] = [];
  formService: FormService = new FormService();
  auditScheduleCreateForm: FormGroup;
  auditSearchForm: FormGroup;
  countries: country[] = [];
  branches: Branch[] = [];
  auditTypes: commonValueAndType[] = [];
  auditIds: commonValueAndType | undefined;
  auditPlanCodes: AuditPlanCode [] = [];
  paramId:string ='';
  auditCreationId:string='';
  users: User[]=[];
  auditScheduleParticipants: AuditScheduleParticipant []=[];

  constructor(private http: HttpService, private fb: FormBuilder,  private activateRoute: ActivatedRoute, private AlertService: AlertService) {
    this.auditScheduleCreateForm = this.fb.group({
      id: [''],
      auditTypeId: [''],
      countryId: [''],
      auditId: [''],
      auditPeriodFrom: [''],
      auditPeriodTo: [''],
      scheduleStartDate:[''],
      scheduleEndDate:[''],
      branchList:['',[Validators.required]],
      approverList:['',[Validators.required]],
      teamLeaderList:['',[Validators.required]],
      auditorList:['',[Validators.required]]
      
    })

    this.auditSearchForm = this.fb.group({
      searchText:['']
    })
   }

  ngOnInit(): void {
   this.paramId = this.activateRoute.snapshot.queryParams['id'];
   this.LoadData();
   this.LoadCountry();
   this.LoadAuditType();
   this.LoadUser();
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
            'AuditSchedule/paginated',dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1),{"scheduleId": this.auditSearchForm.value.searchText}
          ).subscribe(resp => that.auditSchedules = this.dataTableService.datatableMap(resp,callback));
      },
    };
  }

  LoadBranch(){
    this.branches=[];
    var scheduleFormValue=this.auditScheduleCreateForm.getRawValue();
   
    console.log('country id : '+ this.auditScheduleCreateForm.value.countryId)
    console.log('audit id : '+ this.auditScheduleCreateForm.value.auditId)
    this.http.get('commonValueAndType/getBranch?countryId='+scheduleFormValue.countryId).subscribe(resp => {
      let convertedResp = resp as Branch[];
      this.branches = convertedResp;
    })
  }
  LoadUser() {
    this.http.paginatedPost('userlist/Paginated', 100, 1, {"userName": "","employeeName": "","userRole": ""}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<User>;
      this.users = convertedResp.items;
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
      if(this.auditScheduleCreateForm.valid){
        if(this.formService.isEdit(this.auditScheduleCreateForm.get('id') as FormControl)){
          this.http.put('audit',this.auditScheduleCreateForm.getRawValue(),null).subscribe(x=>{
            this.formService.onSaveSuccess(localmodalId,this.datatableElement);
            this.AlertService.success('Audit Saved Successful');

          });
        }
        else{
          console.log(this.auditScheduleCreateForm.value);
          this.http.post('audit',this.auditScheduleCreateForm.getRawValue()).subscribe(x=>{
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
          this.auditScheduleCreateForm.setValue({id : auditResponse.id, countryId : auditResponse.countryId, auditName: auditResponse.auditName, year:auditResponse.year, auditTypeId: auditResponse.auditTypeId, planId: auditResponse.planId, auditId: auditResponse.auditId, 
            auditPeriodFrom: formatDate(auditResponse.auditPeriodFrom, 'yyyy-MM-dd', 'en'),
            auditPeriodTo: formatDate(auditResponse.auditPeriodTo, 'yyyy-MM-dd', 'en')});
      });
      localmodalId.visible = true;
  }



  getAuditById():void {
    this.http
      .getById('audit',this.paramId)
      .subscribe(res => {
          const auditResponse = res as Audit;
          this.auditScheduleCreateForm.setValue({id:'', countryId : auditResponse.countryId, auditTypeId: auditResponse.auditTypeId, auditId: auditResponse.auditId, 
            auditPeriodFrom: formatDate(auditResponse.auditPeriodFrom, 'yyyy-MM-dd', 'en'),
            auditPeriodTo: formatDate(auditResponse.auditPeriodTo, 'yyyy-MM-dd', 'en'),
            scheduleStartDate: formatDate(auditResponse.auditPeriodFrom, 'yyyy-MM-dd', 'en'),
            scheduleEndDate: formatDate(auditResponse.auditPeriodFrom, 'yyyy-MM-dd', 'en'),
            branchList:'',
            approverList:'',
            teamLeaderList:'',
            auditorList:''});
            
            this.auditCreationId=auditResponse.id;
      });
      this.disabledInputField();
      this.LoadBranch();
  }
  disabledInputField(){
    this.auditScheduleCreateForm.controls['auditTypeId'].disable();
    this.auditScheduleCreateForm.controls['auditId'].disable();
    this.auditScheduleCreateForm.controls['countryId'].disable();
    this.auditScheduleCreateForm.controls['auditPeriodFrom'].disable();
    this.auditScheduleCreateForm.controls['auditPeriodTo'].disable();
 }

}
