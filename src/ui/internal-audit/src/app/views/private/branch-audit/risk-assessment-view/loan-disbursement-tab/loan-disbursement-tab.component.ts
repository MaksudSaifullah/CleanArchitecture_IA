import { Component, Input, OnInit, QueryList, ViewChild } from '@angular/core';
import { DataTableDirective } from 'angular-datatables';
import { riskAssessment, riskAssessmentOverdue } from 'src/app/core/interfaces/branch-audit/riskAssessment.interface';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { FormService } from 'src/app/core/services/form.service';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { Subject } from 'rxjs';
import { country } from 'src/app/core/interfaces/configuration/country.interface';
import { HttpService } from 'src/app/core/services/http.service';
import { AlertService } from '../../../../../core/services/alert.service';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { ActivatedRoute } from '@angular/router';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-loan-disbursement-tab',
  templateUrl: './loan-disbursement-tab.component.html',
  styleUrls: ['./loan-disbursement-tab.component.scss']
})
export class LoanDisbursementTabComponent implements OnInit {

  @ViewChild(DataTableDirective, { static: false })
  dtElement?: DataTableDirective;
  dtOptions: DataTables.Settings = {};
  riskAssesmentOverdue: riskAssessmentOverdue[] = [];
  pullFromAMBSForm: FormGroup;
  formService: FormService = new FormService();
  dataTableService: DatatableService = new DatatableService();
  dtTrigger: Subject<any> = new Subject<any>();
  countries: country[] = [];
  @Input() id: any;

  constructor(private http: HttpService, private fb: FormBuilder, private AlertService: AlertService, private activateRoute: ActivatedRoute) {

    this.LoadDropDownValues();
    this.pullFromAMBSForm = this.fb.group({
      countryId: [null, [Validators.required, Validators.pattern("^(?!null$).*$")]],
      conversionRate: [null, [Validators.required, Validators.pattern("^(?!null$).*$")]],
      effectiveTo: [Date, [Validators.required]],
      effectiveFrom: [Date, [Validators.required]],
    });
  }

  ngOnInit(): void {
    this.LoadRiskAssessment(this.id);
  };

  LoadRiskAssessment(id : any)
  {
    this.http
    .getById('riskAssessment', id)
    .subscribe(res => {
        const riskAssessmentResponse = res as riskAssessment;
        this.pullFromAMBSForm.setValue({
          countryId: riskAssessmentResponse.countryId,
          conversionRate: 88,
          effectiveTo: formatDate(riskAssessmentResponse.effectiveTo, 'yyyy-MM-dd', 'en'),
          effectiveFrom: formatDate(riskAssessmentResponse.effectiveFrom, 'yyyy-MM-dd', 'en')
        });
        this.LoadData();
    });
  }


  LoadData() {
    this.dtOptions = {
      pagingType: 'full_numbers',
        pageLength: 10,
        serverSide: true,
        processing: true,
        searching: false,
        ordering: false,
    };
    this.http.post('DataSync/getSyncDataRiskAssesment', Object.assign({}, this.pullFromAMBSForm.value,
     {
      riskAssesmentId: this.id,
      typeId : 3,
      pageSize: -1,
      pageNumber: 0
   })
     )
      .subscribe(resp => {
        this.riskAssesmentOverdue = resp as riskAssessmentOverdue[];
        this.dtTrigger.next(resp);
      })
  }

  onSubmit(): void {
    const tableData: Array<any> = [];
    for(const item of this.riskAssesmentOverdue){
      const tableDataRow = {
        riskAssessmentId: this.id,
        score: item.score,
        rating: item.text,
        value: item.amountConverted,
        branchId: item.branchId,
        isDraft: false
      };
      tableData.push(tableDataRow);
    }
    if (this.pullFromAMBSForm.valid) {
      this.http.post('riskassesmentdatamanagement', 
      {
        riskAssessmentId: this.id,
        conversionRate: 88,
        typeId: 3,
        dataRequestQueueServiceId: this.riskAssesmentOverdue[0].dataRequestQueueSErviceId,
        riskAssesmentDataManagement: tableData
      }).subscribe(x => {
        this.AlertService.success('Saved Successfully');
      });
    }
    else {
      this.pullFromAMBSForm.markAllAsTouched();
      return;
    }
  }

  LoadCountry() {
    this.http.paginatedPost('country/paginated', 100, 1, {}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<country>;
      this.countries = convertedResp.items;
    })
  }

  LoadDropDownValues() {
    this.LoadCountry();
  }
}
