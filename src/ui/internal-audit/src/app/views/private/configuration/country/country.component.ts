import { AfterViewInit, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ModalComponent } from '@coreui/angular-pro';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { country } from '../../../../core/interfaces/configuration/country.interface';
import { HttpService } from '../../../../core/services/http.service';
import Swal from 'sweetalert2';
import {FormService} from '../../../../core/services/form.service';
import {DatatableService} from '../../../../core/services/datatable.service';
import {AlertService} from '../../../../core/services/alert.service';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { CommonResponseInterface } from 'src/app/core/interfaces/common-response.interface';
import { RESOURCE_CACHE_PROVIDER } from '@angular/platform-browser-dynamic';
@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.scss']
})
export class CountryComponent implements OnInit {
  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings = {};
  countries: country[] = [];
  searchForm: FormGroup;
  countryForm: FormGroup;
  formService: FormService = new FormService();
  dataTableService: DatatableService = new DatatableService();
  dtTrigger: Subject<any> = new Subject<any>();

  constructor(private http: HttpService , private fb: FormBuilder, private AlertService: AlertService) {
    this.countryForm = this.fb.group({
      id: [''],
      name: ['',[Validators.required,Validators.maxLength(20),Validators.minLength(5)]],
      code: ['',[Validators.required,Validators.maxLength(2),Validators.minLength(2),Validators.pattern('^[A-Z ]*$')]],
      remarks: [''],
    });
    this.searchForm = this.fb.group(
      {
        searchTerm: ['']
      }
    )
  }
  ngOnDestroy(): void {

  }
  ngOnInit(): void {
    this.LoadData();
    };
  LoadData() {
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
            'country/paginated',dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1), this.searchForm.get('searchTerm')?.value)
            .subscribe(resp => that.countries = this.dataTableService.datatableMap(resp,callback));
      },
    };

  }

    onSubmit(modalId:any):void{
      const localmodalId = modalId;
        if(this.countryForm.valid){
          if(this.formService.isEdit(this.countryForm.get('id') as FormControl)){
            this.http.put('country',this.countryForm.value,null).subscribe(x=>{
              let resp = x as CommonResponseInterface;
              if(resp.success){
                this.formService.onSaveSuccess(localmodalId,this.datatableElement);
                this.AlertService.success('Country Updated Successfully');
              }
              else{
                this.AlertService.errorDialog('Unsuccessful', 'Duplicate Value ');
              }
             
            });
          }
          else{
            this.http.post('country',this.countryForm.value).subscribe(x=>{
              let resp = x as CommonResponseInterface;
              if(resp.success){
                this.formService.onSaveSuccess(localmodalId,this.datatableElement);
                this.AlertService.success('Country Saved Successfully');
              }
              else{
                this.AlertService.errorDialog('Unsuccessful', 'Duplicate Value');
              }    
            
            });
          }
        }
    }
    edit(modalId:any, country:any):void {
      const localmodalId = modalId;
      console.log(country.id)
      this.http
        .getById('country',country.id)
        .subscribe(res => {
            const countryResponse = res as country;
            this.countryForm.setValue({id : countryResponse.id, name : countryResponse.name, remarks: countryResponse.remarks, code: countryResponse.code});
        });
        localmodalId.visible = true;
    }
    delete(id:string){
      const that = this;
      this.AlertService.confirmDialog().then(res =>{
        if(res.isConfirmed){
            this.http.delete('country/'+ id ,{}).subscribe(response=>{
            this.AlertService.successDialog('Deleted','Country deleted successfully.');
            this.dataTableService.redraw(that.datatableElement);
          })
        }
      });
    }
    reset(){
      this.countryForm.reset();
    }
    search(){
      this.dataTableService.redraw(this.datatableElement);
    }
  }

