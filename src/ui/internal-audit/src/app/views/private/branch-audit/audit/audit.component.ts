import { Component, OnInit, ViewChild } from '@angular/core';
import { DataTableDirective } from 'angular-datatables';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { HttpService } from 'src/app/core/services/http.service';
import { EmailConfig} from 'src/app/core/interfaces/configuration/emailConfig.interface'
import { FormService } from 'src/app/core/services/form.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import {AlertService} from '../../../../core/services/alert.service';
import { country } from 'src/app/core/interfaces/configuration/country.interface';
import { Audit } from 'src/app/core/interfaces/branch-audit/audit.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';

@Component({
  selector: 'app-audit',
  templateUrl: './audit.component.html',
  styleUrls: ['./audit.component.scss']
})
export class AuditComponent implements OnInit {
  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings = {};
  dataTableService: DatatableService = new DatatableService();
  audits: Audit[] = [];
  formService: FormService = new FormService();
  // auditForm: FormGroup;
   auditSearchForm: FormGroup;
  countries: country[] = [];
  //emailTypes: EmailType []=[];

  constructor(private http: HttpService, private fb: FormBuilder, private AlertService: AlertService) {
    // this.auditForm = this.fb.group({
    //   id: [''],
    //   emailTypeId: [null,[Validators.required]],
    //   countryId: [null,[Validators.required]],
    //   templateSubject: ['',[Validators.required]],
    //   templateBody: ['',[Validators.required]],
      
    // })

    this.auditSearchForm = this.fb.group({
      searchText:['']
    })
   }

  ngOnInit() {
    this.LoadData();
    // this.LoadCountry();
    // this.LoadEmailType();
  }

  LoadData() {
    const that = this;
    
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      serverSide: true,
      processing: true,
      searching: false,
      ordering:false,
      ajax: (dataTablesParameters: any, callback) => {
        this.http
          .paginatedPost(
            'audit/paginated',dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1),{"auditId": this.auditSearchForm.value.searchText}
          ).subscribe(resp => that.audits = this.dataTableService.datatableMap(resp,callback));
      },
    };
  }
   search(){
     this.dataTableService.redraw(this.datatableElement);
   }
  // clearSearch(){
  //   this.auditSearchForm.setValue({searchText:''})
  //   this.dataTableService.redraw(this.datatableElement);
  // }

  // onSubmit(modalId:any):void{
  //   const localmodalId = modalId;
  //     if(this.auditForm.valid){
  //       if(this.formService.isEdit(this.auditForm.get('id') as FormControl)){
  //         this.http.put('audit',this.auditForm.value,null).subscribe(x=>{
  //           this.formService.onSaveSuccess(localmodalId,this.datatableElement);
  //           this.AlertService.success('Audit Saved Successful');

  //         });
  //       }
  //       else{
  //        // console.log(this.emailConfigForm.value);
  //         this.http.post('audit',this.auditForm.value).subscribe(x=>{
  //           this.formService.onSaveSuccess(localmodalId,this.datatableElement);
  //           this.AlertService.success('Audit Saved Successful');
  //         });
  //       }
  //     }
  // }
  // edit(modalId:any, config:any):void {
  //   const localmodalId = modalId;
  //   console.log(config)
  //   this.http
  //     .getById('audit',config.id)
  //     .subscribe(res => {
  //         const configResponse = res as EmailConfig;
  //         this.auditForm.setValue({id : configResponse.id, emailTypeId : configResponse.emailTypeId, countryId: configResponse.countryId, templateSubject: configResponse.templateSubject, templateBody: configResponse.templateBody});
  //     });
  //     localmodalId.visible = true;
  // }

  // delete(id:string){
  //  // console.log(id)
  //   const that = this;
  //   this.AlertService.confirmDialog().then(res =>{
  //     if(res.isConfirmed){
  //         this.http.delete('audit/'+ id ,{}).subscribe(response=>{
  //         this.AlertService.successDialog('Deleted','Audit deleted successfully.');
  //         this.dataTableService.redraw(that.datatableElement);
  //       })
  //     }
  //   });
  // }

  // LoadCountry() {
  //   this.http.paginatedPost('country/paginated', 100, 1, {}).subscribe(resp => {
  //     let convertedResp = resp as paginatedResponseInterface<country>;
  //     this.countries = convertedResp.items;    
  //   })
  // }
  // LoadEmailType() {
  //   this.http.paginatedPost('emailconfig/paginatedEmailType', 100, 1, {}).subscribe(resp => {
  //     let convertedResp = resp as paginatedResponseInterface<EmailType>;
  //     this.emailTypes = convertedResp.items;
  //   })
  // }
  // reset(){
  //   this.auditForm.reset();
  // }
}
