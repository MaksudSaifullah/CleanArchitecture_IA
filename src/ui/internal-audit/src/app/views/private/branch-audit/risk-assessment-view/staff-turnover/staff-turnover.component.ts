import { Component, OnInit, QueryList, ViewChildren } from '@angular/core';
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
  @ViewChildren(DataTableDirective)
  dtElements: QueryList<DataTableDirective> | undefined;
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


  ReloadAllDataTable() {
    this.dtElements?.forEach((dtElement: DataTableDirective, index: number) => {
      this.dataTableService.redraw(dtElement);
    });
  }


  LoadData() {
    this.dtOptions = {
      pagingType: 'full_numbers',
        pageLength: 10,
    };
    this.http.post('DataSync/getSyncData', Object.assign({}, {
      "startDate": "2022-07-20T04:26:34.237Z",
     "endDate": "2022-07-25T04:26:34.237Z",
     "countryId": "8EB2932F-0DF6-EC11-B3B0-00155D610B18",
     "typeId": 1},
     {"conversionRate": 88
   }))
      .subscribe(resp => {
        console.log(resp, this.pullFromAMBSForm.value);
        this.riskAssesmentOverdue = resp as riskAssessmentOverdue[];
        this.dtTrigger.next(resp);
      })
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
  GetRating(event: any, i : any): void{
    debugger;
    if(event.target.value != "null"){
      this.selectedValue[i] = event.target.value;
    }
  }

}
