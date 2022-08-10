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
  dtElement?: DataTableDirective;
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

  // ReloadAllDataTable() {
  //   this.dtElements?.forEach((dtElement: DataTableDirective, index: number) => {
  //     this.dataTableService.redraw(dtElement);
  //   });
  // }


  LoadData() {
    console.log("LOGGGGGGGGGGG", Object.assign({}, this.pullFromAMBSForm.value, 
      {
        "typeId": 1,
        "conversionRate": 88,
        "pageNumber": 1,
        "pageSize": -1
      } 
    ));
    this.dtOptions = {
      pagingType: 'full_numbers',
        pageLength: 10,
        serverSide: true,
        processing: true,
        searching: false,
        ordering: false,
    };
    this.http.post('DataSync/getSyncData', Object.assign({}, {
      "startDate": "2022-07-20T04:26:34.237Z",
     "endDate": "2022-07-25T04:26:34.237Z",
     "countryId": "8EB2932F-0DF6-EC11-B3B0-00155D610B18",
     "typeId": 1},
     {"conversionRate": 88,
     "pageNumber": 1,
     "pageSize": -1
   })
     )
      .subscribe(resp => {
        console.log(resp, this.pullFromAMBSForm.value);
        this.riskAssesmentOverdue = resp as riskAssessmentOverdue[];
        this.dtTrigger.next(resp);
      })
  }

  onSubmit(): void {
    const tableData: Array<any> = [];
    const temp = this.riskAssesmentOverdue;
    console.log(this.riskAssesmentOverdue);
    debugger;
    this.dtElement?.dtInstance.then((dtInstance: DataTables.Api) => console.log(dtInstance.row));
    for(const item of this.riskAssesmentOverdue){
      const tableDataRow = [{
        score: item.riskCriteria.commonValueRatingType.value,
        rating: item.riskCriteria.commonValueRatingType.text,
        value: item.amountConverted,
        branchId: item.branchId,
        isDraft: false
      }];
      tableData.push(tableDataRow);
    }
    console.log(Object.assign({}, this.pullFromAMBSForm.value, {riskAssesmentDataManagement: tableData}));
      //     this.dataTableService.redraw(dtElement);
    // if (this.pullFromAMBSForm.valid) {
    //   this.http.post('riskassessment', Object.assign({}, this.pullFromAMBSForm.value, this.riskAssesmentOverdue[0].dataRequestQueueService)).subscribe(x => {
    //     this.AlertService.success('Saved Successfully');
    //   });
    // }
    // else {
    //   this.pullFromAMBSForm.markAllAsTouched();
    //   return;
    // }
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
