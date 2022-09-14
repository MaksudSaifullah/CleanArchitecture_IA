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
      countryName: [null, [Validators.required]],
      assessmentTo: [Date, [Validators.required]],
      assessmentFrom: [Date, [Validators.required]],
      createdAt: [Date, [Validators.required]],
      auditType: [null, [Validators.required]],
      planningYear: [null, [Validators.required]],
      assesmentId: [null, [Validators.required]],
      createdBy: [null, [Validators.required]],
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
        console.log(this.auditPlanResponse);
        this.auditPlanViewForm.setValue({
          planningId: this.auditPlanResponse.planCode,
          countryName: this.auditPlanResponse.countryName,
          assessmentTo: formatDate(this.auditPlanResponse.assessmentTo, 'yyyy-MM-dd', 'en'),
          assessmentFrom: formatDate(this.auditPlanResponse.assessmentFrom, 'yyyy-MM-dd', 'en'),
          createdAt: formatDate(this.auditPlanResponse.createdOn, 'yyyy-MM-dd', 'en'),
          auditType: this.auditPlanResponse.auditTypeName,
          planningYear: this.auditPlanResponse.planCode,
          assesmentId: this.auditPlanResponse.assessmentCode,
          createdBy: this.auditPlanResponse.createdBy
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
    this.http.post('DataSync/getSyncDataRiskAssesmentAvg', { "countryId": this.auditPlanResponse?.countryId, "riskAssesmentId": this.auditPlanResponse?.riskAssessmentId, "pageSize": -1, "pageNumber": 0}
     )
      .subscribe(resp => {
        this.auditPlanTableData = resp as any[];
        this.dtTrigger.next(resp);
      })
    }
}
