import { AfterViewInit, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ModalComponent } from '@coreui/angular-pro';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { country } from 'src/app/core/interfaces/configuration/country.interface';
import { auditFrequency } from 'src/app/core/interfaces/branch-audit/auditFrequency.interface';
import { commonValueAndType } from '../../../../core/interfaces/configuration/commonValueAndType.interface';
import { HttpService } from '../../../../core/services/http.service';
import Swal from 'sweetalert2';
import {FormService} from '../../../../core/services/form.service';
import {DatatableService} from '../../../../core/services/datatable.service';
import {AlertService} from '../../../../core/services/alert.service';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { formatDate } from '@angular/common';
import { CutomvalidatorService } from 'src/app/core/services/cutomvalidator.service'

@Component({
  selector: 'app-audit-frequency',
  templateUrl: './audit-frequency.component.html',
  styleUrls: ['./audit-frequency.component.scss']
})
export class AuditFrequencyComponent implements OnInit {
  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings = {};
  auditScore: commonValueAndType[] = [];
  ratingType: commonValueAndType[] = [];
  auditFrequencyType: commonValueAndType[] = [];
  auditFrequencies: auditFrequency[] = [];
  countries: country[] = [];
  auditFrequencyForm: FormGroup;
  searchForm: FormGroup;
  formService: FormService = new FormService();
  dataTableService: DatatableService = new DatatableService();
  dtTrigger: Subject<any> = new Subject<any>();
  //effectiveFrom: any;

  constructor(private http: HttpService , private fb: FormBuilder, private AlertService: AlertService, private customValidator: CutomvalidatorService,) {
    this.LoadDropDownValues();
    this.auditFrequencyForm = this.fb.group({
      id: [''],
      countryId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      auditScoreId: [null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      ratingTypeId: [null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      auditFrequencyTypeId: [null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      effectiveFrom: [Date,[Validators.required]],
      effectiveTo: [Date, [Validators.required]]
      
    }, { validator: this.customValidator.checkEffectiveDateToAfterFrom('effectiveFrom', 'effectiveTo') });
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
            'auditFrequency/paginated',dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1),this.searchForm.get('searchTerm')?.value
          ).subscribe(resp => that.auditFrequencies = this.dataTableService.datatableMap(resp,callback));
      },
    };

  }
  LoadCountry() {
    this.http.paginatedPost('country/paginated', 100, 1, {}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<country>;
      this.countries = convertedResp.items;    
    })
  }

  LoadAuditScoreType() {
    this.http.get('commonValueAndType/auditscore').subscribe(resp => {
      let convertedResp = resp as commonValueAndType[];
      this.auditScore = convertedResp;
    })
  }

  LoadAuditFrequencyType() {
    this.http.get('commonValueAndType/auditfrequency').subscribe(resp => {
      let convertedResp = resp as commonValueAndType[];
      this.auditFrequencyType = convertedResp;
    })
  }

  LoadRatingType() {
    this.http.get('commonValueAndType/riskrating').subscribe(resp => {
      let convertedResp = resp as commonValueAndType[];
      this.ratingType = convertedResp;
    })
  }

  LoadDropDownValues() {
    this.LoadCountry();
    this.LoadAuditScoreType();
    this.LoadAuditFrequencyType();
    this.LoadRatingType();
  }

//   checkIfEndDateAfterStartDate (c: AbstractControl) {
//     //safety check
//     if (!c.get('effectiveFrom').value || !c.get('effectiveTo').value) { return null }
//     // carry out the actual date checks here for is-endDate-after-startDate
//     // if valid, return null,
//     // if invalid, return an error object (any arbitrary name), like, return { invalidEndDate: true }
//     // make sure it always returns a 'null' for valid or non-relevant cases, and a 'non-null' object for when an error should be raised on the formGroup
// }


  onSubmit(modalId:any):void{
    const localmodalId = modalId;
    if (this.auditFrequencyForm.valid ){
      if(this.formService.isEdit(this.auditFrequencyForm.get('id') as FormControl)){
        this.http.put('auditFrequency',this.auditFrequencyForm.value,null).subscribe(x=>{
            localmodalId.visible = false;
            this.dataTableService.redraw(this.datatableElement);
            this.AlertService.success('Audit Frequency Updated Successfully');
          });
      }
      else {
       // console.log(this.riskProfileForm.value);
        this.http.post('auditFrequency',this.auditFrequencyForm.value).subscribe(x=>{
          this.formService.onSaveSuccess(localmodalId,this.datatableElement);
          this.AlertService.success('Audit Frequency Saved Successfully');
        });
      }      
    }
    else {     
      this.auditFrequencyForm.markAllAsTouched();
      return;
    }    
  }

  edit(modalId:any, auditFrequency:any):void {
    const localmodalId = modalId;
    //console.log('hello');
    this.http
      .getById('auditFrequency', auditFrequency.id)
      .subscribe(res => {
          const auditFrequencyResponse = res as auditFrequency;
          //this.effectiveFrom = riskProfileResponse.effectiveFrom;
          //console.log(riskProfileResponse);
          this.auditFrequencyForm.setValue({id : auditFrequencyResponse.id, countryId : auditFrequencyResponse.countryId, 
            auditScoreId: auditFrequencyResponse.auditScoreId, ratingTypeId: auditFrequencyResponse.ratingTypeId, 
            auditFrequencyTypeId: auditFrequencyResponse.auditFrequencyTypeId,
            effectiveFrom: formatDate(auditFrequencyResponse.effectiveFrom, 'yyyy-MM-dd', 'en'), 
            effectiveTo: formatDate(auditFrequencyResponse.effectiveTo, 'yyyy-MM-dd', 'en')

          });
      });
      localmodalId.visible = true;
      
  }

  delete(id:string){
    const that = this;
    this.AlertService.confirmDialog().then(res =>{
      if(res.isConfirmed){
          this.http.delete('auditFrequency/'+ id ,{}).subscribe(response=>{
          this.AlertService.successDialog('Deleted','Audit Frequency deleted successfully.');
          this.dataTableService.redraw(that.datatableElement);
        })
      }
    });
  }
  reset(){
    this.auditFrequencyForm.reset();
  }
  search(){
    this.dataTableService.redraw(this.datatableElement);
  }

}

