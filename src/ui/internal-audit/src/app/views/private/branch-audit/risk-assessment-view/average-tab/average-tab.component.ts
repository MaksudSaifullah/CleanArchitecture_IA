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
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-average-tab',
  templateUrl: './average-tab.component.html',
  styleUrls: ['./average-tab.component.scss']
})
export class AverageTabComponent implements OnInit {
  @ViewChild(DataTableDirective, { static: false })
  dtElements: QueryList<DataTableDirective> | undefined;
  dtOptions: DataTables.Settings = {};
  riskAssesmentOverdue: any[] = [];
  pullFromAMBSForm: FormGroup;
  formService: FormService = new FormService();
  dataTableService: DatatableService = new DatatableService();
  dtTrigger: Subject<any> = new Subject<any>();
  countries: country[] = [];
  Data: Array<any> = [];
  tableTempData: any;
  @Input() id: any;

  constructor(private http: HttpService, private fb: FormBuilder, private AlertService: AlertService) {

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
    this.http.post('DataSync/getSyncDataRiskAssesmentAvg', {countryId: this.pullFromAMBSForm.value.countryId, riskAssesmentId: this.id, "pageNumber": 0, "pageSize": -1}
     )
      .subscribe(resp => {
        this.riskAssesmentOverdue = resp as any[];
        this.dtTrigger.next(resp);
      })
  }

  onConsolidate(): void {
    this.tableTempData = "abcd";
  }

  onSubmit(): void {
    this.http.post('DataSync/getSyncDataRiskAssesmentAvgPost', {datas: }
     )
      .subscribe(resp => {
        this.AlertService.success('Saved Successfully');
      })
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
