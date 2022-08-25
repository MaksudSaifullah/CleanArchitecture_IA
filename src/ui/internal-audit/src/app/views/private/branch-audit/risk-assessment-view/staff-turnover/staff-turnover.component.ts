import { Component, Input, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { riskAssessment, riskAssessmentOverdue } from 'src/app/core/interfaces/branch-audit/riskAssessment.interface';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { FormService } from 'src/app/core/services/form.service';
import { country } from 'src/app/core/interfaces/configuration/country.interface';
import { HttpService } from 'src/app/core/services/http.service';
import {AlertService} from '../../../../../core/services/alert.service';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { formatDate } from '@angular/common';

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
  scores: any[] = [];
  selectedRating : any[] = [];
  selectedScore : any[] = [];
  LoProductivity: any[] = [];
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
        ordering: false
    };
    this.http.post('DataSync/getSyncDataRiskAssesment', Object.assign({}, this.pullFromAMBSForm.value,
      {
       riskAssesmentId: this.id,
       typeId : 5,
       pageSize: -1,
       pageNumber: 0
    }))
      .subscribe(resp => {
        this.riskAssesmentOverdue = resp as riskAssessmentOverdue[];
        this.dtTrigger.next(resp);
      })
  }

  onSubmitDraft(): void {
    const tableData: Array<any> = [];
    var i = 0;
    for(const item of this.riskAssesmentOverdue){
      const tableDataRow = {
        score: this.riskAssesmentOverdue[i].score,
        rating: this.riskAssesmentOverdue[i].text,
        value: this.riskAssesmentOverdue[i].amountConverted,
        branchId: item.branchId,
        isDraft: true
      };
      i++;
      if (tableDataRow.score != -1 && tableDataRow.rating != "SELECT" && tableDataRow.value != "-1" && tableDataRow.branchId != undefined && tableDataRow.value != "")
      {
        tableData.push(tableDataRow);
      }
    }
      this.http.post('RiskAssesmentDataManagement', 
      {
        riskAssessmentId: this.id,
        conversionRate: 88,
        typeId: 5,
        dataRequestQueueServiceId: this.riskAssesmentOverdue[0].dataRequestQueueSErviceId,
        riskAssesmentDataManagement: tableData
      }).subscribe(x => {
        
        this.AlertService.success('Saved Successfully');
      });
  }

  onSubmit(): void {
    const tableData: Array<any> = [];
    var i = 0;
    for(const item of this.riskAssesmentOverdue){
      const tableDataRow = {
        score: this.riskAssesmentOverdue[i].score,
        rating: this.riskAssesmentOverdue[i].text,
        value: this.riskAssesmentOverdue[i].amountConverted,
        branchId: item.branchId,
        isDraft: false
      };
      i++;
      if (tableDataRow.score == -1 || tableDataRow.rating == "SELECT" || tableDataRow.value == "-1" || tableDataRow.branchId == undefined || tableDataRow.value == "")
      {
        this.AlertService.error('Please fill all the required fields.');
        return;
      }
      else{
        tableData.push(tableDataRow);
      }
    }
      this.http.post('RiskAssesmentDataManagement', 
      {
        riskAssessmentId: this.id,
        conversionRate: 88,
        typeId: 5,
        dataRequestQueueServiceId: this.riskAssesmentOverdue[0].dataRequestQueueSErviceId,
        riskAssesmentDataManagement: tableData
      }).subscribe(x => {
        
        this.AlertService.success('Saved Successfully');
      });
  }

  LoadCountry() {
    this.http.paginatedPost('country/paginated', 100, 1, {}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<country>;
      this.countries = convertedResp.items;
    })
  }

  LoadScores() {
    this.http.get('commonValueAndType/generictype?type=RISKASSESMENT').subscribe(resp => {
      let convertedResp = resp as any[];
      this.scores = convertedResp;
    })
  }


  LoadDropDownValues() {
    this.LoadCountry();
    this.LoadScores();
  }
  GetRating(event: any, i : any): void{
    if(event.target.value != "SELECT"){
      this.riskAssesmentOverdue[i].text = event.target.value;
      this.riskAssesmentOverdue[i].score = event.target.options[event.target.options.selectedIndex].text;
    }
    else{
      this.riskAssesmentOverdue[i].text = "SELECT";
      this.riskAssesmentOverdue[i].score = -1;
    }
  }

  GetScore(event: any, i : any): void{
    if(event.target.value != "SELECT"){
      this.riskAssesmentOverdue[i].score = event.target.value;
    }
  }

  GetProductivity(event: any, i : any): void{
    if(event.target.value != "-1"){
      this.riskAssesmentOverdue[i].amountConverted = event.target.value;
    }
  }

}
