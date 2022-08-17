import { Component, OnInit, ViewChild } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Branch } from 'src/app/core/interfaces/branch-audit/branch.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { User } from 'src/app/core/interfaces/security/user-registration.interface';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';
import { AlertService } from '../../../../core/services/alert.service';

@Component({
  selector: 'app-schedule-configuration',
  templateUrl: './schedule-configuration.component.html',
  styleUrls: ['./schedule-configuration.component.scss']
})
export class ScheduleConfigurationComponent implements OnInit {
  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings = {};
  dataTableService: DatatableService = new DatatableService();
  countryIdGlobal: any = '00000000-0000-0000-0000-000000000000';
  branches: Branch[] = [];
  scheduleConfigForm: FormGroup;
  users: User[]=[];
  formService: FormService = new FormService();

  constructor(private http: HttpService, private fb: FormBuilder, private AlertService: AlertService, private router: Router, private activateRoute: ActivatedRoute) {
    this.scheduleConfigForm = this.fb.group({
      id: [''],
      branchId: [''],
      branchName: [''],
      
      riskOwnerList:['']
    })
    //this.scheduleConfigForm =this.fb.group({});
  }
  ngOnInit(): void {
    this.LoadData();
    this.LoadUser();
    this.LoadBranch();
    // this.branches.map((x, i) => {
    //   this.scheduleConfigForm.addControl('branchId'+i, this.fb.control(x.branchId))
    //   this.scheduleConfigForm.addControl('branchName'+i, this.fb.control(x.branchName))
    //   this.scheduleConfigForm.addControl('riskOwnerList'+i, this.fb.control(x.branchName))
    // })
    
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
  console.log(';lsdjfl')
  this.http.get('commonValueAndType/getBranch?countryId='+'414d221c-0df6-ec11-b3b0-00155d610b18' +'&pageNumber=1&pageSize=10000').subscribe(resp => {
    let convertedResp = resp as paginatedResponseInterface<Branch>;
    this.branches = convertedResp.items;
    this.countryIdGlobal = '414d221c-0df6-ec11-b3b0-00155d610b18'
    this.dataTableService.redraw(this.datatableElement);
  })
}
LoadRiskOwner(){
 
}
setBranchId(){
  this.scheduleConfigForm.patchValue({branchId: this.scheduleConfigForm.value.branchId});
}

onSubmit(modalId:any){

}

}
