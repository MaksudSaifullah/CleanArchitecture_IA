import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';
import { AlertService } from '../../../../core/services/alert.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DataTableDirective } from 'angular-datatables';
import { riskAssessmentOverdue } from 'src/app/core/interfaces/branch-audit/riskAssessment.interface';
import { UploadedDocumentList,DocumentGet } from 'src/app/core/interfaces/uploaded-document.interface';
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
  uploadedDocumentList: UploadedDocumentList[] = [];
  formService: FormService = new FormService();
  dataTableService: DatatableService = new DatatableService();
  dtTrigger: Subject<any> = new Subject<any>();
  uploadDocumentForm: FormGroup;
  roles: role[] = [];
  docu :DocumentGet={};

  constructor(private http: HttpService, private fb: FormBuilder, private AlertService: AlertService) { 
    this.LoadRole();
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
      documentId: ['', [Validators.required]],
      roleList: ['',[Validators.required]],
    });
  }

  ngOnInit(): void {
    this.LoadData();
  }
  LoadRole() {
    this.http.paginatedPost('role/paginated', 100, 1, {}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<role>;
      console.log(convertedResp);
     this.roles = convertedResp.items;
    })
  }
  fileDownLoad(d:any){
    console.log(d);
    //Document/get-file-stream?Id=1f72aaed-1c1e-ed11-b3b2-00155d610b18
    // this.http.get('Document/get-file-stream?Id='+'601d81e6-ac1f-ed11-b3b2-00155d610b18',
    this.http.get('Document?Id='+'601d81e6-ac1f-ed11-b3b2-00155d610b18',
    )
     .subscribe(resp => {
      console.log(resp);
      var s=resp as DocumentGet;
      console.log(s);
      console.log(s.path);
      
     })
  }
  // downloadFile(data: Response) {
  //   const blob = new Blob([data], { type: 'text/csv' });
  //   const url= window.URL.createObjectURL(blob);
  //   window.open(url);
  // }
  LoadData() {
    this.dtOptions = {
      pagingType: 'full_numbers',
        pageLength: 10,
        serverSide: true,
        processing: true,
        searching: false,
        ordering: false,
    };
    this.http.get('UploadDocumentPage/roleid?roleid=DD0F5C2E-2D1F-ED11-B3B2-00155D610B18&pageNumber=1&pageSize=-1',
     )
      .subscribe(resp => {
        this.uploadedDocumentList = resp as UploadedDocumentList[];
        console.log(this.uploadedDocumentList);
        this.dtTrigger.next(resp);
      })
  }


}
