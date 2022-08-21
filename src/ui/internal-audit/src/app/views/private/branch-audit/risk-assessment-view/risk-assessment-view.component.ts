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
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-risk-assessment-view',
  templateUrl: './risk-assessment-view.component.html',
  styleUrls: ['./risk-assessment-view.component.scss']
})
export class RiskAssessmentViewComponent implements OnInit {

  @ViewChild(DataTableDirective, {static: false})
  riskAssessmentCode: any;
  id : any;

  constructor(private http: HttpService , private fb: FormBuilder, private activateRoute: ActivatedRoute, private AlertService: AlertService, private location: Location) { 
  }

  goBack(){
    this.location.back();
  }

  ngOnDestroy(): void {

  }
  ngOnInit(): void {   
    this.id = this.activateRoute.snapshot.params['id'];
    this.LoadRiskAssessment(this.id);
  };

  LoadRiskAssessment(id : any)
  {
    this.http
    .getById('riskAssessment', id)
    .subscribe(res => {
        const result = res as riskAssessment;
        this.riskAssessmentCode = result.assessmentCode;

    });
  }

}
