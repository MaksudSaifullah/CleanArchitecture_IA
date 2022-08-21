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
import { firstValueFrom, Subject } from 'rxjs';
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
  globalFile: File | any = null;
  documentRawSourceInfo: DocumentSource = {};

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

    // const p = this.helper.getDocumentSource('Upload_All_Document');
    // let yy=this.http.waitFor(p) ;
    // console.log( yy);
  }

  async ngOnInit() {
    this.LoadData();

    try {

      console.log('-----------------------------')
      this.documentRawSourceInfo = await this.helper.getDocumentSource('Upload_All_Document') as DocumentSource;
      console.log(this.documentRawSourceInfo)
      console.log('-----------------------------')

    } catch (error) {
      console.log(error);
    }

    //  this.LoadDocumentUploadConfig();
  }
  async LoadDocumentUploadConfig() {
    //  let t= firstValueFrom(this.helper.getDocumentSource('Upload_All_Document')).then(c=>{
    //   this.documentRawSource=c as DocumentSource;
    //  });

    console.log('hiiiii');

    console.log(this.documentRawSourceInfo);
    console.log('hiiiii');
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

      let doc = this.documentRawSourceInfo;    
      this.globalFile = event.target.files[0] as File;    
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


      let roleList: UploadedDocumentsNotify[] = [];

      let useca: UserRole[] = this.uploadDocumentForm.value.roleList as UserRole[];

      if (Array.isArray(useca)) {
        useca.forEach(function (value) {
          let urole: UserRole = { roleId: value.toString() }
          roleList.push(urole);
        });

      }

      let doc = this.documentRawSourceInfo;
      const file = this.globalFile as File;
      this.http.postFile(doc.id == null ? '' : doc.id, doc.name == null ? '' : doc.name, this.uploadDocumentForm.value.documentName.trim(), file, 'Document').subscribe(x => {
        let response = x as FileResponseInterface;
        this.globalFileValue = response.id;

        const requestModel = {
          documentVersion: this.uploadDocumentForm.value.documentVersion,
          documentId: this.globalFileValue,
          description: this.uploadDocumentForm.value.description,
          approvedBy: this.uploadDocumentForm.value.approvedBy.trim(),
          activeFrom: this.uploadDocumentForm.value.activeFrom,
          activeTo: this.uploadDocumentForm.value.activeTo,
          uploadedBy: this.uploadDocumentForm.value.uploadeddBy.trim(),
          uploadedDocumentsNotify: roleList
        }

        this.http.post('UploadDocumentPage',requestModel).subscribe(x=>{
          this.AlertService.successDialog('Success','Document uploaded successfully.');
          this.uploadDocumentForm.patchValue({roleList:null});
          this.uploadDocumentForm.get('roleList')?.setValue([]);
          this.uploadDocumentForm.reset();
          this.ResetForm();
          // this.uploadDocumentForm.get('roleList')?.setValue([]);
          this.dataTableService.redraw(this.datatableElement);

        })
       // console.log(requestModel)
      });

      // let doc = this.helper.getDocumentSource('Upload_All_Document');
      // let _file: File = this.filestore as File;

      // this.http.postFile(doc.id, doc.name, 'Document', 'user.png', _file).subscribe(x => {
      //   let response = x as FileResponseInterface;
      //   globalFileValue = response.id;
      // });

    }
    else {
      this.uploadDocumentForm.markAllAsTouched();
      this.AlertService.error('Provide Valid Information');
    }
  }
  onCancel(): void {
    // this.uploadDocumentForm.get('roleList')?.setValue([]);
    // this.uploadDocumentForm.patchValue({roleList:null});
   
    this.ResetForm();
  }


  private ResetForm() {
    this.uploadDocumentForm.reset();
    $('.form-multi-select-selection-cleaner').prop("disabled", false);
    $('.form-multi-select-selection-cleaner').trigger('click');
    setTimeout(() => {
      $('.form-multi-select').removeClass('show');
      $('.form-multi-select').removeClass('cdk-focused');
      $('.form-multi-select').removeClass('cdk-mouse-focused');
      this.uploadDocumentForm.reset();
    }, 300);
  }
}
