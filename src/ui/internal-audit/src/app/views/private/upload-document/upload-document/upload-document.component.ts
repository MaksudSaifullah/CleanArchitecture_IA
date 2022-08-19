import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';
import { AlertService } from '../../../../core/services/alert.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DataTableDirective } from 'angular-datatables';
import { riskAssessmentOverdue } from 'src/app/core/interfaces/branch-audit/riskAssessment.interface';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { Subject } from 'rxjs';
import { role } from 'src/app/core/interfaces/security/role.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';

@Component({
  selector: 'app-upload-document',
  templateUrl: './upload-document.component.html',
  styleUrls: ['./upload-document.component.scss']
})
export class UploadDocumentComponent implements OnInit {
  @ViewChild(DataTableDirective, { static: false })
  dtElement?: DataTableDirective;
  dtOptions: DataTables.Settings = {};
  riskAssesmentOverdue: riskAssessmentOverdue[] = [];
  formService: FormService = new FormService();
  dataTableService: DatatableService = new DatatableService();
  dtTrigger: Subject<any> = new Subject<any>();
  uploadDocumentForm: FormGroup;
  roles: role[] = [];

  constructor(private http: HttpService, private fb: FormBuilder, private AlertService: AlertService) { 
    this.uploadDocumentForm = this.fb.group({
      documentVersion: [null, [Validators.required]],
      description: [null, [Validators.required]],
      approvedBy: [null, [Validators.required]],
      activeFrom: [null, [Validators.required]],
      activeTo: [null, [Validators.required]],
      uploadeddBy: [null, [Validators.required]],
      multiSelect: [null, [Validators.required]],
      documentName: [null, [Validators.required]],
      choosefile: [Date, [Validators.required]],
    });
  }

  ngOnInit(): void {
    this.LoadData();
  }
  LoadRole() {
    this.http.paginatedPost('role/paginated', 100, 1, {}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<role>;
      this.roles = convertedResp.items;
    })
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
    this.http.post('DataSync/getSyncDataRiskAssesment', {
      countryId: "8eb2932f-0df6-ec11-b3b0-00155d610b18",
      conversionRate: 88,
      effectiveTo: "2022-07-25",
      effectiveFrom: "2022-07-20",
      riskAssesmentId: "78675595-8f18-ed11-b3b2-00155d610b18",
      typeId: 1,
      pageSize: 10,
      pageNumber: 1
  }
     )
      .subscribe(resp => {
        this.riskAssesmentOverdue = resp as riskAssessmentOverdue[];
        this.dtTrigger.next(resp);
      })
  }


}
