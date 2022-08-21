import { formatDate } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Branch } from 'src/app/core/interfaces/branch-audit/branch.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { User } from 'src/app/core/interfaces/security/user-registration.interface';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { HttpService } from 'src/app/core/services/http.service';
import {AlertService} from '../../../../core/services/alert.service';

@Component({
  selector: 'app-schedule-view',
  templateUrl: './schedule-view.component.html',
  styleUrls: ['./schedule-view.component.scss']
})
export class ScheduleViewComponent implements OnInit {
  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings = {};
  dataTableService: DatatableService = new DatatableService();
  auditScheduleViewForm: FormGroup;
  branches: Branch[] = [];
  users: User[]=[];
  countryIdGlobal: any = '00000000-0000-0000-0000-000000000000';
  moveToInprogressDefault=true;
  moveToInprogress=false;
  moveToDone=false;
  paramId: string = '';


  constructor(private http: HttpService, private fb: FormBuilder, private AlertService: AlertService, private router: Router,private activateRoute: ActivatedRoute) {
    this.auditScheduleViewForm = this.fb.group({
      id: [''],
      auditTypeId: [''],
      countryId: [''],
      auditId: [''],
      auditPeriodFrom: [''],
      auditPeriodTo: [''],
      scheduleStartDate:[''],
      scheduleEndDate:[''],
      branchList:[''],
      approverList:[''],
      teamLeaderList:[''],
      auditorList:['']
      
    })
   }

  ngOnInit(): void {
    this.paramId = this.activateRoute.snapshot.params['id'];
    this.LoadData();
    this.LoadBranch();
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
        this.http.get('commonValueAndType/getBranch?countryId=' + this.countryIdGlobal + '&pageNumber=1&pageSize=10000').subscribe(resp => that.branches = this.dataTableService.datatableMap(resp, callback));
      },
    };
  }
  LoadUser() {
    this.http.paginatedPost('userlist/Paginated', 100, 1, {"userName": "","employeeName": "","userRole": ""}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<User>;
      this.users = convertedResp.items;
    })
  }
  LoadBranch(){
    // console.log(';lsdjfl')
     this.http.get('commonValueAndType/getBranch?countryId='+'414d221c-0df6-ec11-b3b0-00155d610b18' +'&pageNumber=1&pageSize=10000').subscribe(resp => {
       let convertedResp = resp as paginatedResponseInterface<Branch>;
       this.branches = convertedResp.items;
       this.countryIdGlobal = '414d221c-0df6-ec11-b3b0-00155d610b18'
       this.dataTableService.redraw(this.datatableElement);
     })
   }
  RedirectToAuditList(){
    this.router.navigate(['branch-audit/audit']);
  }
  RedirectToAuditView(){   
    this.router.navigate(['branch-audit/audit-view']);
  }
  RedirectToScheduelConfiguration(){
    this.router.navigate(['branch-audit/schedule-configuration']);
  }
  MoveToInprogressClick(){
    this.moveToInprogressDefault=false;
    this.moveToInprogress=true;
    this.moveToDone=false;
  }
  MoveToDoneClick(){
    this.moveToInprogress=false;
    this.moveToDone=true;
    this.moveToInprogressDefault=false;
  }
  BackToInprogessClick(){
    
    this.moveToInprogress=true;
    this.moveToDone=false;
  }
}
