import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';
import { AlertService } from '../../../../core/services/alert.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DataTableDirective } from 'angular-datatables';
import { riskAssessmentOverdue } from 'src/app/core/interfaces/branch-audit/riskAssessment.interface';
import { UploadedDocumentList, DocumentGet, UploadDocumentRequest, UploadedDocumentsNotify, DocumentSource } from 'src/app/core/interfaces/uploaded-document.interface';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { Subject } from 'rxjs';
import { role } from 'src/app/core/interfaces/security/role.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { HelperService } from 'src/app/core/services/helper.service'
import { userRegistrationRequestData, UserCountry, UserRole, UserResponse } from 'src/app/core/interfaces/security/user-registration.interface'
import { FileResponseInterface } from 'src/app/core/interfaces/file-response.interface';

@Component({
  selector: 'app-upload-document',
  templateUrl: './upload-document.component.html',
  styleUrls: ['./upload-document.component.scss']
})
export class UploadDocumentComponent implements OnInit {
  dtOptions: DataTables.Settings = {};
  @ViewChild(DataTableDirective, { static: false })
  datatableElement: DataTableDirective | undefined;
  dataTableService: DatatableService = new DatatableService();

  riskAssesmentOverdue: riskAssessmentOverdue[] = [];
  uploadedDocumentList: UploadedDocumentList[] = [];
  formService: FormService = new FormService();
  dtTrigger: Subject<any> = new Subject<any>();
  uploadDocumentForm: FormGroup;
  roles: role[] = [];
  docu: DocumentGet = {};
  globalFileValue: any;
  documentRawSource: DocumentSource = {};

  constructor(private http: HttpService, private fb: FormBuilder, private AlertService: AlertService, private helper: HelperService) {
    this.LoadRole();
    this.uploadDocumentForm = this.fb.group({
      documentVersion: [null, [Validators.required]],
      description: [null, [Validators.required]],
      approvedBy: [null, [Validators.required]],
      activeFrom: [null, [Validators.required]],
      activeTo: [null, [Validators.required]],
      uploadeddBy: [null, [Validators.required]],
      documentName: [null, [Validators.required]],

      documentId: ['', [Validators.required]],
      roleList: ['', [Validators.required]],
    });
  }

  ngOnInit(): void {
    this.LoadData();
    this.LoadDocumentUploadConfig();
  }
  LoadDocumentUploadConfig() {
    this.documentRawSource = this.helper.getDocumentSource('Upload_All_Document');
    console.log(this.documentRawSource);
  }
  LoadRole() {
    this.http.paginatedPost('role/paginated', 100, 1, {}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<role>;
      console.log(convertedResp);
      this.roles = convertedResp.items;
    })
  }
  onFileChange(event: any) {
    if (event.target.files.length > 0) {

      let doc = this.documentRawSource as DocumentSource;
      console.log(doc)
        return;
      let _file: File = event.target.files[0] as File;
      // const file = event.target.files[0];
      this.http.postFile(doc.id == undefined ? '':'', doc.name==undefined ? '':'', 'Document', _file.name, _file).subscribe(x => {
        let response = x as FileResponseInterface;
        this.globalFileValue = response.id;
      });
    }

  }
  fileDownLoad(d: any) {
    console.log(d);
    //Document/get-file-stream?Id=1f72aaed-1c1e-ed11-b3b2-00155d610b18
    // this.http.get('Document/get-file-stream?Id='+'601d81e6-ac1f-ed11-b3b2-00155d610b18',
    this.http.getFilesAsBlob('Document/get-file-stream?Id=' + d,
    )
      .subscribe((resp: any) => {
        let fileName = resp.headers.get('content-disposition');
        console.log(fileName);
        //  return;


        this.helper.downloadFile(resp);

      }), (error: any) => console.log('Error downloading the file'),
      () => console.info('File downloaded successfully');
  }


  LoadData() {
    console.log('sakndljkashjkldaslkjh')
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
            'UploadDocumentPage/roleid', dataTablesParameters.length, ((dataTablesParameters.start / dataTablesParameters.length) + 1), { "roleid": 'dd0f5c2e-2d1f-ed11-b3b2-00155d610b18' }
          ).subscribe(resp => that.uploadedDocumentList = this.dataTableService.datatableMap(resp, callback));
      },

    }
  }
  delete(id: any) {
    const that = this;
    this.AlertService.confirmDialog().then(res => {
      if (res.isConfirmed) {
        this.http.delete('UploadDocumentPage/id?Id=' + id, {}).subscribe(response => {
          this.AlertService.successDialog('Deleted', 'Document  deleted successfully.');
          this.dataTableService.redraw(that.datatableElement);
        })
      }
    });
  }
  onSubmit(): void {
    const that = this;
    if (this.uploadDocumentForm.valid) {




      // let doc = this.helper.getDocumentSource('Upload_All_Document');
      // let _file: File = this.filestore as File;

      // this.http.postFile(doc.id, doc.name, 'Document', 'user.png', _file).subscribe(x => {
      //   let response = x as FileResponseInterface;
      //   globalFileValue = response.id;
      // });









      let roleList: UploadedDocumentsNotify[] = [];

      let useca: UserRole[] = this.uploadDocumentForm.value.roleList as UserRole[];

      if (Array.isArray(useca)) {
        useca.forEach(function (value) {
          let urole: UserRole = { roleId: value.toString() }
          roleList.push(urole);
        });

      }

      const requestModel = {
        documentVersion: this.uploadDocumentForm.value.documentVersion.trim(),
        documentId: this.globalFileValue,
        description: this.uploadDocumentForm.value.description.trim(),
        approvedBy: this.uploadDocumentForm.value.approvedBy.trim(),
        activeFrom: this.uploadDocumentForm.value.activeFrom,
        activeTo: this.uploadDocumentForm.value.activeTo,
        uploadedBy: this.uploadDocumentForm.value.uploadedBy.trim(),
        uploadedDocumentsNotify: roleList
      }

    }
    else {
      this.uploadDocumentForm.markAllAsTouched();
      this.AlertService.error('Provide Valid Information');
    }
  }
  onCancel(): void {
    this.uploadDocumentForm.reset();
  }

}
