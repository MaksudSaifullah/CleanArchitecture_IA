import { Component, OnInit, ViewChild } from '@angular/core';
import { DataTableDirective } from 'angular-datatables';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { HttpService } from 'src/app/core/services/http.service';
import { EmailConfig} from 'src/app/core/interfaces/configuration/emailConfig.interface'
import { FormService } from 'src/app/core/services/form.service';
import { FormBuilder, FormControl, FormGroup, MaxLengthValidator, Validators } from '@angular/forms';
import {AlertService} from '../../../../core/services/alert.service';
import { country } from 'src/app/core/interfaces/configuration/country.interface';
import { Audit } from 'src/app/core/interfaces/branch-audit/audit.interface';
import { AuditScheduleParticipant } from 'src/app/core/interfaces/branch-audit/auditScheduleParticipant.interface';
import { User } from 'src/app/core/interfaces/branch-audit/user.interface';
import { AuditPlanCode } from 'src/app/core/interfaces/branch-audit/auditPlanCode.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { commonValueAndType } from 'src/app/core/interfaces/configuration/commonValueAndType.interface';
import { formatDate } from '@angular/common';
import { Branch } from 'src/app/core/interfaces/branch-audit/branch.interface';

@Component({
  selector: 'app-audit',
  templateUrl: './audit.component.html',
  styleUrls: ['./audit.component.scss']
})
export class AuditComponent implements OnInit {
  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings = {};
  dataTableService: DatatableService = new DatatableService();
  audits: Audit[] = [];
  formService: FormService = new FormService();
  auditForm: FormGroup;
  auditScheduleForm: FormGroup;
  auditSearchForm: FormGroup;
  countries: country[] = [];
  auditTypes: commonValueAndType[] = [];
  auditIds: commonValueAndType | undefined;
  auditPlanCodes: AuditPlanCode [] = [];
  branches: Branch[] = [];
  users: User[]=[];
  auditScheduleParticipants: AuditScheduleParticipant []=[];

  constructor(private http: HttpService, private fb: FormBuilder, private AlertService: AlertService) {
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
    this.auditScheduleForm = this.fb.group({
      id: [''],
      auditTypeId: ["3ee0ab25-baf2-ec11-b3b0-00155d610b11"],
      countryId: [null,[Validators.required]],
      auditId: ['',[Validators.required]],
      auditPeriodFrom: ['',[Validators.required]],
      auditPeriodTo: ['',[Validators.required]],
      scheduleStartDate: ['',[Validators.required]],
      scheduleEndDate: ['',[Validators.required]],
      approverList:['',[Validators.required]],
      teamLeaderList:['',[Validators.required]],
      auditorList:['',[Validators.required]]
      
    })

    this.auditSearchForm = this.fb.group({
      searchText:['']
    })
   }

  ngOnInit() {
    this.LoadData();
    this.LoadCountry();
    this.LoadAuditType();
    this.LoadAuditPlanCode();
    this.LoadUser();
   // this.LoadAuditId();
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
  onSubmitAuditSchedule(modalId:any):void{
    console.log(this.auditScheduleForm.getRawValue())

    const localmodalId = modalId;
    let auditParticipantList: AuditScheduleParticipant[] = [];

    if (this.auditScheduleForm.valid) {  

      let approvers: AuditScheduleParticipant[] = this.auditScheduleForm.value.approverList as AuditScheduleParticipant[];
      if (Array.isArray(approvers)) {
        approvers.forEach(function (value) {
          let user: AuditScheduleParticipant = { auditScheduleId : "", userId: value.userId.toString(),commonValueParticipantId:1}
          auditParticipantList.push(user);
        }); 
      }
      let teamLeaders: AuditScheduleParticipant[] = this.auditScheduleForm.value.teamLeaderList as AuditScheduleParticipant[];
      if (Array.isArray(teamLeaders)) {
        teamLeaders.forEach(function (value) {
          let user: AuditScheduleParticipant = { auditScheduleId : "", userId: value.userId.toString(),commonValueParticipantId:2}
          auditParticipantList.push(user);
        }); 
      }
      let auditors: AuditScheduleParticipant[] = this.auditScheduleForm.value.auditorList as AuditScheduleParticipant[];
      if (Array.isArray(auditors)) {
        auditors.forEach(function (value) {
          let user: AuditScheduleParticipant = { auditScheduleId : "", userId: value.userId.toString(),commonValueParticipantId:2}
          auditParticipantList.push(user);
        }); 
      }

      const RequestModelForSchedule = {
        id:  this.auditScheduleForm.value.id,
        auditId: this.auditScheduleForm.value.auditId,
        scheduleStartDate: this.auditScheduleForm.value.scheduleStartDate,   
        scheduleEndDate: this.auditScheduleForm.value.scheduleEndDate,
        auditScheduleParticipants : auditParticipantList
        
      };
      console.log(auditParticipantList);
      // this.http.put('AuditSchedule',RequestModelForSchedule,null).subscribe(x=>{
      //     this.formService.onSaveSuccess(localmodalId,this.datatableElement);
      //     this.AlertService.success('Audit Schedule Saved Successful');
      // });
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

  delete(id:string){
   // console.log(id)
    const that = this;
    this.AlertService.confirmDialog().then(res =>{
      if(res.isConfirmed){
          this.http.delete('audit/'+ id ,{}).subscribe(response=>{
          this.AlertService.successDialog('Deleted','Audit deleted successfully.');
          this.dataTableService.redraw(that.datatableElement);
        })
      }
    });
  }

  LoadAuditId(){
    this.http.get('commonValueAndType/idcreation?idcreationValue=16&auditType=1&countryId='+this.auditForm.value.countryId).subscribe(resp => {
      let convertedResp = resp as commonValueAndType;
      this.auditIds = convertedResp;
      this.auditForm.patchValue({auditId: this.auditIds.text})
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
  LoadAuditPlanCode(){
    this.http.paginatedPost('audit/paginatedAuditPlanCode', 100 , 1 , {}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<AuditPlanCode>;
      this.auditPlanCodes = convertedResp.items;
    })
  }
  LoadBranch(){
    var scheduleFormValue=this.auditScheduleForm.getRawValue();
   // console.log(scheduleFormValue.countryId)
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
  reset(){
    this.auditForm.reset();
    this.auditForm.patchValue({auditTypeId:"3ee0ab25-baf2-ec11-b3b0-00155d610b11"});
     this.auditForm.controls['auditTypeId'].disable();
     this.auditForm.controls['auditId'].disable();
  }
  resetScheduleForm(audit:any){
    this.auditScheduleForm.reset();
    this.auditScheduleForm.patchValue({countryId : audit.countryId, auditTypeId: audit.auditTypeId, auditId: audit.auditId, 
            auditPeriodFrom: formatDate(audit.auditPeriodFrom, 'yyyy-MM-dd', 'en'),
            auditPeriodTo: formatDate(audit.auditPeriodTo, 'yyyy-MM-dd', 'en')})

     this.LoadBranch();
     this.auditScheduleForm.controls['auditTypeId'].disable();
     this.auditScheduleForm.controls['auditId'].disable();
     this.auditScheduleForm.controls['countryId'].disable();
     this.auditScheduleForm.controls['auditPeriodFrom'].disable();
     this.auditScheduleForm.controls['auditPeriodTo'].disable();
  }
  
}
