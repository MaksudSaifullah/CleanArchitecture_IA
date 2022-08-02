import { Location } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { commonValueAndType } from 'src/app/core/interfaces/configuration/commonValueAndType.interface';
import { country } from 'src/app/core/interfaces/configuration/country.interface';
import { riskAssessment } from 'src/app/core/interfaces/branch-audit/riskAssessment.interface';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';
import {AlertService} from '../../../../core/services/alert.service';
import { formatDate } from '@angular/common';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
@Component({
  selector: 'app-risk-assessment-view',
  templateUrl: './risk-assessment-view.component.html',
  styleUrls: ['./risk-assessment-view.component.scss']
})
export class RiskAssessmentViewComponent implements OnInit {

  @ViewChild(DataTableDirective, {static: false})
  country: any;
  reviewPeriodTo: any;
  reviewPeriodFrom: any;
  createdBy: any;
  createdDate: any;
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings = {};
  ambsData: riskAssessment[] = [];
  formService: FormService = new FormService();
  dataTableService: DatatableService = new DatatableService();
  dtTrigger: Subject<any> = new Subject<any>();
  countries: country[] = [];
  Data: Array<any> = [];

  constructor(private http: HttpService , private fb: FormBuilder, private AlertService: AlertService, private location: Location) { 
  }

  goBack(){
    this.location.back();
  }

  ngOnDestroy(): void {

  }
  ngOnInit(): void {   
  };
}
