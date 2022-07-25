import { Component, OnInit, ViewChild } from '@angular/core';
import { DataTableDirective } from 'angular-datatables';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { HttpService } from 'src/app/core/services/http.service';
import { EmailConfig} from 'src/app/core/interfaces/configuration/emailConfig.interface'
import { FormService } from 'src/app/core/services/form.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import {AlertService} from '../../../../core/services/alert.service';
import { country } from 'src/app/core/interfaces/configuration/country.interface';
import { EmailType } from 'src/app/core/interfaces/configuration/emailType.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';


@Component({
  selector: 'app-emailConfig',
  templateUrl: './emailConfig.component.html',
  styleUrls: ['./emailConfig.component.scss']
})
export class EmailConfigComponent implements OnInit {

  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings = {};
  dataTableService: DatatableService = new DatatableService();
  emailConfigs: EmailConfig[] = [];
  formService: FormService = new FormService();
  emailConfigForm: FormGroup;
  emailConfigSearchForm: FormGroup;
  countries: country[] = [];
  emailTypes: EmailType []=[];
  

  constructor(private http: HttpService, private fb: FormBuilder, private AlertService: AlertService) { 
    this.emailConfigForm = this.fb.group({
      id: [''],
      emailTypeId: [null,[Validators.required]],
      countryId: [null,[Validators.required]],
      templateSubject: ['',[Validators.required]],
      templateBody: ['',[Validators.required]],
      
    })

    this.emailConfigSearchForm = this.fb.group({
      searchText:['']
    })
  }

  ngOnInit() {
    this.LoadData();
    this.LoadCountry();
    this.LoadEmailType();
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
            'emailconfig/paginated',dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1),{"countryName": this.emailConfigSearchForm.value.searchText}
          ).subscribe(resp => that.emailConfigs = this.dataTableService.datatableMap(resp,callback));
      },
    };
  }
  search(){
    this.dataTableService.redraw(this.datatableElement);
  }
  clearSearch(){
    this.emailConfigSearchForm.setValue({searchText:''})
    this.dataTableService.redraw(this.datatableElement);
  }

  onSubmit(modalId:any):void{
    const localmodalId = modalId;
      if(this.emailConfigForm.valid){
        if(this.formService.isEdit(this.emailConfigForm.get('id') as FormControl)){
          this.http.put('emailconfig',this.emailConfigForm.value,null).subscribe(x=>{
            this.formService.onSaveSuccess(localmodalId,this.datatableElement);
            this.AlertService.success('Email Configuration Saved Successful');

          });
        }
        else{
         // console.log(this.emailConfigForm.value);
          this.http.post('emailconfig',this.emailConfigForm.value).subscribe(x=>{
            this.formService.onSaveSuccess(localmodalId,this.datatableElement);
            this.AlertService.success('Email Configuration Saved Successful');
          });
        }
      }
  }
  edit(modalId:any, config:any):void {
    const localmodalId = modalId;
    console.log(config)
    this.http
      .getById('emailconfig',config.id)
      .subscribe(res => {
          const configResponse = res as EmailConfig;
          this.emailConfigForm.setValue({id : configResponse.id, emailTypeId : configResponse.emailTypeId, countryId: configResponse.countryId, templateSubject: configResponse.templateSubject, templateBody: configResponse.templateBody});
      });
      localmodalId.visible = true;
  }

  delete(id:string){
   // console.log(id)
    const that = this;
    this.AlertService.confirmDialog().then(res =>{
      if(res.isConfirmed){
          this.http.delete('emailconfig/'+ id ,{}).subscribe(response=>{
          this.AlertService.successDialog('Deleted','Email Configuration deleted successfully.');
          this.dataTableService.redraw(that.datatableElement);
        })
      }
    });
  }

  LoadCountry() {
    this.http.paginatedPost('country/paginated', 100, 1, {}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<country>;
      this.countries = convertedResp.items;    
    })
  }
  LoadEmailType() {
    this.http.paginatedPost('emailconfig/paginatedEmailType', 100, 1, {}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<EmailType>;
      this.emailTypes = convertedResp.items;
    })
  }
  reset(){
    this.emailConfigForm.reset();
  }

}
