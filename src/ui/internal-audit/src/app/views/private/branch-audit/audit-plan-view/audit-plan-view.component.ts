import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { Location } from '@angular/common';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { UploadedDocumentsNotify } from 'src/app/core/interfaces/uploaded-document.interface';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { FormService } from 'src/app/core/services/form.service';
import { HelperService } from 'src/app/core/services/helper.service';
import { HttpService } from 'src/app/core/services/http.service';
import { AlertService } from '../../../../core/services/alert.service';
import { CutomvalidatorService } from 'src/app/core/services/cutomvalidator.service';
import { formatDate } from '@angular/common';
import { auditPlan } from 'src/app/core/interfaces/branch-audit/auditPlan.interface';
import { riskAssessmentOverdue } from 'src/app/core/interfaces/branch-audit/riskAssessment.interface';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-audit-plan-view',
  templateUrl: './audit-plan-view.component.html',
  styleUrls: ['./audit-plan-view.component.scss']
})
export class AuditPlanViewComponent implements OnInit {
  dtOptions: DataTables.Settings = {};
  @ViewChild(DataTableDirective, { static: false })
  datatableElement: DataTableDirective | undefined;
  dataTableService: DatatableService = new DatatableService();
  formService: FormService = new FormService();
  dtTrigger: Subject<any> = new Subject<any>();
  auditPlanViewForm: FormGroup;
  auditPlanResponse: auditPlan | undefined;
  auditPlanTableData: riskAssessmentOverdue[] = [];
  paramId:string ='';

  constructor(private http: HttpService, private fb: FormBuilder,  private activateRoute: ActivatedRoute, private AlertService: AlertService, private helper: HelperService, private customValidator: CutomvalidatorService, private location: Location) {
    this.auditPlanViewForm = this.fb.group({
      planningId: [null, [Validators.required]],
    },
      {
        validator: [this.customValidator.checkIfFieldContainsSpace('documentName'),this.customValidator.checkEffectiveDateToAfterFrom('activeFrom', 'activeTo')],
      });

    // const p = this.helper.getDocumentSource('Upload_All_Document');
    // let yy=this.http.waitFor(p) ;
    // console.log( yy);
  }

  ngOnInit() {
    this.paramId = this.activateRoute.snapshot.params['id'];
    this.LoadAuditPlan(this.paramId);
    //  this.LoadDocumentUploadConfig();
  }

  LoadAuditPlan(id : any)
  {
    this.http
    .getById('auditplan', id)
    .subscribe(res => {
        this.auditPlanResponse = res as auditPlan;
        console.log(res);
        this.auditPlanViewForm.setValue({
          planningId: this.auditPlanResponse.planCode,
          // conversionRate: 88,
          // effectiveTo: formatDate(auditPlanResponse.effectiveTo, 'yyyy-MM-dd', 'en'),
          // effectiveFrom: formatDate(auditPlanResponse.effectiveFrom, 'yyyy-MM-dd', 'en')
        });
        this.LoadData();
    });
  }

  goBack(){
    this.location.back();
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
    this.http.post('DataSync/getSyncDataRiskAssesmentAvg', { "countryId": this.auditPlanResponse?.countryId, "riskAssesmentId": this.auditPlanResponse?.riskAssessmentId}
     )
      .subscribe(resp => {
        this.auditPlanTableData = resp as any[];
        this.dtTrigger.next(resp);
      })
    }
}
