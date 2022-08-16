import { formatDate } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Console } from 'console';
import { Audit } from 'src/app/core/interfaces/branch-audit/audit.interface';
import { AuditPlanCode } from 'src/app/core/interfaces/branch-audit/auditPlanCode.interface';
import { Branch } from 'src/app/core/interfaces/branch-audit/branch.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { HttpService } from 'src/app/core/services/http.service';
import { AlertService } from '../../../../core/services/alert.service';

@Component({
  selector: 'app-audit-view',
  templateUrl: './audit-view.component.html',
  styleUrls: ['./audit-view.component.scss']
})
export class AuditViewComponent implements OnInit {
  @ViewChild(DataTableDirective, { static: false })
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings = {};
  dataTableService: DatatableService = new DatatableService();
  paramId: string = '';
  auditViewForm: FormGroup;
  auditPlanCodes: AuditPlanCode[] = [];
  branches: Branch[] = [];
  countryIdGlobal: any = '00000000-0000-0000-0000-000000000000';

  constructor(private http: HttpService, private fb: FormBuilder, private AlertService: AlertService, private router: Router, private activateRoute: ActivatedRoute) {
    this.auditViewForm = this.fb.group({
      id: [''],
      countryId: [''],
      auditTypeId: [''],
      auditId: [''],
      auditName: [''],
      year: [''],
      auditPlanId: [''],
      auditPeriodFrom: [''],
      auditPeriodTo: [''],

    })
  }

  ngOnInit(): void {
    this.LoadData();
    this.paramId = this.activateRoute.snapshot.queryParams['id'];
    this.getAuditById(this.paramId);
    // this.LoadData();

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

  getAuditById(id: string): void {
    const that = this;
    this.http
      .getById('audit', id)
      .subscribe(res => {
        const auditResponse = res as Audit;
        this.auditViewForm.setValue({
          id: auditResponse.id, countryId: auditResponse.countryId, auditTypeId: auditResponse.auditTypeId, auditName: auditResponse.auditName, year: auditResponse.year, auditPlanId: "", auditId: auditResponse.auditId,
          auditPeriodFrom: formatDate(auditResponse.auditPeriodFrom, 'yyyy-MM-dd', 'en'),
          auditPeriodTo: formatDate(auditResponse.auditPeriodTo, 'yyyy-MM-dd', 'en')
        });

        this.LoadAuditPlanCode();
        this.auditViewForm.patchValue({ auditPlanId: auditResponse.auditPlanId });
        this.countryIdGlobal = auditResponse?.countryId;
        this.dataTableService.redraw(this.datatableElement);
      });

    this.disabledInputField();

  }
 
  LoadAuditPlanCode() {
    // this.LoadData();
    this.auditPlanCodes = [];
    var auditFormValue = this.auditViewForm.getRawValue();
    this.http.paginatedPost('audit/paginatedAuditPlanCode', 100, 1, { "countryId": auditFormValue.countryId, "auditTypeId": auditFormValue.auditTypeId }).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<AuditPlanCode>;
      this.auditPlanCodes = convertedResp.items;
    })
  }
  RedirectToAuditList() {
    console.log("sldjflsdf")
    this.router.navigate(['branch-audit/audit']);
  }
  RedirectToScheduleList() {
    var formValue = this.auditViewForm.getRawValue();
    this.router.navigate(['branch-audit/audit-schedule'], { queryParams: { id: formValue.id } });
  }
  disabledInputField() {
    this.auditViewForm.controls['auditName'].disable();
    this.auditViewForm.controls['auditId'].disable();
    this.auditViewForm.controls['year'].disable();
    this.auditViewForm.controls['auditPlanId'].disable();
    this.auditViewForm.controls['auditPeriodFrom'].disable();
    this.auditViewForm.controls['auditPeriodTo'].disable();
  }

}