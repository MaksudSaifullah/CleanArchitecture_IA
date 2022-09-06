import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { HelperService } from 'src/app/core/services/helper.service';
import { HttpService } from 'src/app/core/services/http.service';
import {AlertService} from '../../../../core/services/alert.service';
import { ClosingMeetingMinutes } from '../../../../core/interfaces/branch-audit/closingMeetingMinutes.interface';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { WPAuditScheduleBranch } from 'src/app/core/interfaces/branch-audit/auditScheduleBranch.interface';
import { AuditSchedule } from 'src/app/core/interfaces/branch-audit/auditSchedule.interface';

@Component({
  selector: 'app-closing-meeting-minutes',
  templateUrl: './closing-meeting-minutes.component.html',
  styleUrls: ['./closing-meeting-minutes.component.scss']
})
export class ClosingMeetingMinutesComponent implements OnInit {
  
  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings = {};
  dataTableService: DatatableService = new DatatableService();
  searchForm: FormGroup;

  closingMeetingMinutes: ClosingMeetingMinutes[] = [];
  wpAuditScheduleBranches : WPAuditScheduleBranch[] = [];
  auditSchedules: AuditSchedule[] =[];
  paramId:string ='';
 

  constructor(private http: HttpService,private router: Router, private helper: HelperService , private fb: FormBuilder, private AlertService: AlertService) {
    //this.loadDropDownValues();
 
     this.searchForm = this.fb.group(
       {
        auditScheduleBranchId:[''],
       }
     )
   }

  ngOnInit(): void {
    this.LoadData();
    this.paramId = 'C09240DA-02DE-4B96-9A61-C9CA8F741C89';
    this.LoadScheduleData(this.paramId);
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
            'closingmeetingminute/paginated',dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1), this.searchForm.get('auditScheduleBranchId')?.value)
            .subscribe(resp => that.closingMeetingMinutes = this.dataTableService.datatableMap(resp,callback));
      },
    };

  }

  LoadScheduleData(Id:any):void {
    this.http
      .getById('AuditSchedule',Id)
      .subscribe(res => {
           const scheduleData = res as AuditSchedule;
          let scheduleId = scheduleData.id;
          let countryId = scheduleData.countryId;
          //this.GetWorkPaperCode(countryId);
           this.LoadBranches(scheduleId);
          //  this.workpaperForm.patchValue({
          //   scheduleCode: scheduleData.scheduleId,
          //   scheduleStartDate: formatDate(scheduleData.scheduleStartDate, 'yyyy-MM-dd', 'en') ,
          //   scheduleEndDate:  formatDate(scheduleData.scheduleEndDate, 'yyyy-MM-dd', 'en') });
      });
  
  }


  edit(id:string){
    this.router.navigate(['/branch-audit/closing-meeting-minutes-create/'+ id] );
  }


  LoadBranches(scheduleId:any) {
    this.http.get('commonValueAndType/getAuditScheduleBranch?ScheduleId='+ scheduleId +'').subscribe(resp => {
      let convertedResp = resp as WPAuditScheduleBranch[];
      this.wpAuditScheduleBranches = convertedResp;  
      console.log("ssssssssssssssssssssssssssss",this.wpAuditScheduleBranches);   
      
    })

  }

  search(){
    this.dataTableService.redraw(this.datatableElement);
  }

  delete(id:string){
    const that = this;
    this.AlertService.confirmDialog().then(res =>{
      if(res.isConfirmed){
          this.http.delete('closingmeetingminute/'+ id ,{}).subscribe(response=>{
          this.AlertService.successDialog('Deleted','Closing Meeting Minute deleted successfully.');
          this.dataTableService.redraw(that.datatableElement);
        })
      }
    });
  }
}
