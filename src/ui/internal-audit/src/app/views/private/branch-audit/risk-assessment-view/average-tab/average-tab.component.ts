import { Component, OnInit, QueryList, ViewChild } from '@angular/core';
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

@Component({
  selector: 'app-average-tab',
  templateUrl: './average-tab.component.html',
  styleUrls: ['./average-tab.component.scss']
})
export class AverageTabComponent implements OnInit {
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
  tableTempData: any;

  constructor(private http: HttpService, private fb: FormBuilder, private AlertService: AlertService) {

    this.LoadDropDownValues();
    this.pullFromAMBSForm = this.fb.group({
      id: [''],
      countryId: [null, [Validators.required, Validators.pattern("^(?!null$).*$")]],
      conversionRate: [null, [Validators.required, Validators.pattern("^(?!null$).*$")]],
      AsOnDate: [Date, [Validators.required]],
    });
  }
  ngOnInit(): void {
    this.LoadData();
  };


  ReloadAllDataTable() {
    this.dtElements?.forEach((dtElement: DataTableDirective, index: number) => {
      this.dataTableService.redraw(dtElement);
    });
  }


  LoadData() {
  //   this.dtOptions = {
  //     pagingType: 'full_numbers',
  //       pageLength: 10
  //   };
    
  //   this.http.post('DataSync/getSyncData', Object.assign({}, {
  //     "startDate": "2022-07-20T04:26:34.237Z",
  //    "endDate": "2022-07-25T04:26:34.237Z",
  //    "countryId": "8EB2932F-0DF6-EC11-B3B0-00155D610B18",
  //    "typeId": 1},
  //    {"conversionRate": 88
  //  }))
  //     .subscribe(resp => {
  //       console.log(resp, this.pullFromAMBSForm.value);
  //       this.riskAssesmentOverdue = resp as riskAssessmentOverdue[];
  //       this.dtTrigger.next(resp);
  //     })
  }

  onConsolidate(): void {
    this.tableTempData = "abcd";
  }

  onSubmit(modalId: any): void {
    const localmodalId = modalId;
    if (this.pullFromAMBSForm.valid) {
      console.log(JSON.stringify(this.pullFromAMBSForm.value))
      this.http.post('riskassessment', this.pullFromAMBSForm.value).subscribe(x => {
        this.formService.onSaveSuccess(localmodalId, this.dtElements);
        this.AlertService.success('Risk Assessment Saved Successfully');
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
