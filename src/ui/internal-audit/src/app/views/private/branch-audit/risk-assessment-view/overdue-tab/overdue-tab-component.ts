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
  selector: 'app-overdue-tab-component',
  templateUrl: './overdue-tab-component.html',
  styleUrls: ['./overdue-tab-component.scss']
})
export class OverdueTabComponentComponent implements OnInit {
  @ViewChild(DataTableDirective, { static: false })
  dtElements: QueryList<DataTableDirective> | undefined;
  dtOptions: DataTables.Settings = {};
  riskAssesmentOverdue: riskAssessmentOverdue[] = [];
  pullFromAMBSForm: FormGroup;
  formService: FormService = new FormService();
  dataTableService: DatatableService = new DatatableService();
  dtTrigger: Subject<any> = new Subject<any>();
  countries: country[] = [];
  Data: Array<any> = [];
  paramId : any;
  @Input() id: any;

  constructor(private http: HttpService, private fb: FormBuilder, private AlertService: AlertService, private activateRoute: ActivatedRoute) {

    this.LoadDropDownValues();
    this.pullFromAMBSForm = this.fb.group({
      id: [''],
      countryId: [null, [Validators.required, Validators.pattern("^(?!null$).*$")]],
      conversionRate: [null, [Validators.required, Validators.pattern("^(?!null$).*$")]],
      effectiveTo: [Date, [Validators.required]],
      effectiveFrom: [Date, [Validators.required]],
    });
  }

  ngOnInit(): void {
    this.LoadData();
    this.LoadRiskAssessment(this.id);
  };

  LoadRiskAssessment(id : any)
  {
    this.http
    .getById('riskAssessment', id)
    .subscribe(res => {
        const riskAssessmentResponse = res as riskAssessment;
        console.log(riskAssessmentResponse);
        this.pullFromAMBSForm.patchValue({
          id: riskAssessmentResponse.id,
          coversionRate: 0,
          countryId: riskAssessmentResponse.countryId,
          effectiveTo: formatDate(riskAssessmentResponse.effectiveTo, 'yyyy-MM-dd', 'en'),
          effectiveFrom: formatDate(riskAssessmentResponse.effectiveFrom, 'yyyy-MM-dd', 'en')
        });
    });
  }

  ReloadAllDataTable() {
    this.dtElements?.forEach((dtElement: DataTableDirective, index: number) => {
      this.dataTableService.redraw(dtElement);
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
    this.http.post('DataSync/getSyncData', {
      "startDate": "2022-07-20T04:26:34.237Z",
     "endDate": "2022-07-25T04:26:34.237Z",
     "countryId": "8EB2932F-0DF6-EC11-B3B0-00155D610B18",
     "typeId": 1,
     "conversionRate": 88,
      "pageNumber": 1,
      "pageSize": 10 
   })
      .subscribe(resp => {
        console.log(resp, this.pullFromAMBSForm.value);
        this.riskAssesmentOverdue = resp as riskAssessmentOverdue[];
        this.dtTrigger.next(resp);
      })
  }

  onSubmit(): void {
    console.log(Object.assign({}, this.pullFromAMBSForm.value, this.riskAssesmentOverdue[0].dataRequestQueueService))
    if (this.pullFromAMBSForm.valid) {
      this.http.post('riskassessment', Object.assign({}, this.pullFromAMBSForm.value, this.riskAssesmentOverdue[0].dataRequestQueueService)).subscribe(x => {
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
