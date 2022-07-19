import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { commonValueAndType } from 'src/app/core/interfaces/configuration/commonValueAndType.interface';
import { country } from 'src/app/core/interfaces/configuration/country.interface';
import { riskAssessment } from 'src/app/core/interfaces/branch-audit/riskAssessment.interface';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';
import {AlertService} from '../../../../core/services/alert.service';

@Component({
  selector: 'app-risk-assessment',
  templateUrl: './risk-assessment.component.html',
  styleUrls: ['./risk-assessment.component.scss']
})
export class RiskAssessmentComponent implements OnInit {
  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings = {};
  auditType: commonValueAndType[] = [];
  country : country[] = [];
  riskAssessments: riskAssessment[] = [];
  riskAssessmentForm: FormGroup;
  formService: FormService = new FormService();
  dataTableService: DatatableService = new DatatableService();
  dtTrigger: Subject<any> = new Subject<any>();
  effectiveFrom: any;

  constructor(private http: HttpService , private fb: FormBuilder, private AlertService: AlertService) { 

    this.LoadDropDownValues();
    this.riskAssessmentForm = this.fb.group({
      id: [''],
      countryId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      auditTypeId: [null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      assesmentCode: [''],
      effectiveFrom: [Date,[Validators.required]],
      effectiveTo: [Date, [Validators.required]],
      
    })

  }

  ngOnDestroy(): void {

  }
  ngOnInit(): void {   
    this.LoadData();
  };

}
