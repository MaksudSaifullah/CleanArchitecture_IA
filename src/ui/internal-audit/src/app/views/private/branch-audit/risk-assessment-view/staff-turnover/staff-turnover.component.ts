import { Component, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { riskAssessmentOverdue } from 'src/app/core/interfaces/branch-audit/riskAssessment.interface';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { FormService } from 'src/app/core/services/form.service';
import { country } from 'src/app/core/interfaces/configuration/country.interface';
import { HttpService } from 'src/app/core/services/http.service';
import {AlertService} from '../../../../../core/services/alert.service';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';

@Component({
  selector: 'app-staff-turnover',
  templateUrl: './staff-turnover.component.html',
  styleUrls: ['./staff-turnover.component.scss']
})
export class StaffTurnoverComponent implements OnInit {
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
  selectedValue : any[] = [];

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


  LoadData() {
    this.dtOptions = {
      pagingType: 'full_numbers',
        pageLength: 10,
    };
    this.http.post('DataSync/getSyncData', Object.assign({}, {
      "effectiveFrom": "2022-07-20",
     "effectiveTo": "2022-07-25",
     "countryId": "8EB2932F-0DF6-EC11-B3B0-00155D610B18",
     "typeId": 1},
     {"conversionRate": 88,
     "pageSize": -1,
     "pageNumber": 0
   }))
      .subscribe(resp => {
        console.log(resp, this.pullFromAMBSForm.value);
        this.riskAssesmentOverdue = resp as riskAssessmentOverdue[];
        this.dtTrigger.next(resp);
      })
  }

  onSubmit(): void {
    this.dtElement?.dtInstance.then((dtInstance: DataTables.Api) => console.log(dtInstance));
    console.log(Object.assign({}, this.riskAssesmentOverdue, this.pullFromAMBSForm));
    const tableData = [];

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
  GetRating(event: any, i : any): void{
    debugger;
    if(event.target.value != "null"){
      this.selectedValue[i] = event.target.value;
    }
  }

}
