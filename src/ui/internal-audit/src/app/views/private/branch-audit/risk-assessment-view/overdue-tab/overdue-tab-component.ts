import { Component, OnInit } from '@angular/core';
import { DataTableDirective } from 'angular-datatables';
import { riskAssessment, riskAssessmentOverdue } from 'src/app/core/interfaces/branch-audit/riskAssessment.interface';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { FormService } from 'src/app/core/services/form.service';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { Subject } from 'rxjs';
import { country } from 'src/app/core/interfaces/configuration/country.interface';
import { HttpService } from 'src/app/core/services/http.service';
import {AlertService} from '../../../../../core/services/alert.service';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';

@Component({
  selector: 'app-overdue-tab-component',
  templateUrl: './overdue-tab-component.html',
  styleUrls: ['./overdue-tab-component.scss']
})
export class OverdueTabComponentComponent implements OnInit {
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings = {};
  riskAssesmentOverdue: riskAssessmentOverdue[] = [];
  pullFromAMBSForm: FormGroup;
  formService: FormService = new FormService();
  dataTableService: DatatableService = new DatatableService();
  dtTrigger: Subject<any> = new Subject<any>();
  countries: country[] = [];
  Data: Array<any> = [];

  constructor(private http: HttpService , private fb: FormBuilder, private AlertService: AlertService) { 

    this.LoadDropDownValues();
    this.pullFromAMBSForm = this.fb.group({
      id: [''],
      countryId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      conversionRate: [null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      AsOnDate: [Date,[Validators.required]],
    });
  }

  ngOnInit(): void {   
    this.LoadData();
  };

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
        this.http
          .paginatedPost(
            'riskassessment/paginated',dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1), 1
            )
            .subscribe(resp => that.riskAssesmentOverdue = this.dataTableService.datatableMap(resp,callback));
      },
    };
  }

  onSubmit(modalId:any):void{
    const localmodalId = modalId;
    if (this.pullFromAMBSForm.valid ){
        console.log(JSON.stringify(this.pullFromAMBSForm.value))
        this.http.post('riskassessment',this.pullFromAMBSForm.value).subscribe(x=>{ 
          this.formService.onSaveSuccess(localmodalId,this.datatableElement);
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
      console.log("Country",convertedResp);
      this.countries = convertedResp.items;
    })
  }

  LoadDropDownValues() {
    this.LoadCountry();
  }

}
