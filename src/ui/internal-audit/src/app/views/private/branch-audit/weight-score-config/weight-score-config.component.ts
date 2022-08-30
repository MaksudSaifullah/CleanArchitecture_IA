import { Component, OnInit, ViewChild } from '@angular/core';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';
import { AlertService } from '../../../../core/services/alert.service';
import { FormBuilder, FormControl, FormGroup, Validators, FormArray } from '@angular/forms';
import { country } from 'src/app/core/interfaces/configuration/country.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { CutomvalidatorService } from 'src/app/core/services/cutomvalidator.service'
import { topicHead, topicHeadCal } from 'src/app/core/interfaces/branch-audit/topicHead.interface';
import { DataTableDirective } from 'angular-datatables';
import { DatatableService } from 'src/app/core/services/datatable.service';

@Component({
  selector: 'app-weight-score-config',
  templateUrl: './weight-score-config.component.html',
  styleUrls: ['./weight-score-config.component.scss']
})
export class WeightScoreConfigComponent implements OnInit {
  @ViewChild(DataTableDirective, { static: false })
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings = {};
  countries: country[] = [];
  weightConfigForm!: FormGroup;
  dataTableService: DatatableService = new DatatableService();
  topicHeads: topicHead[] = [];
  topicHeadCal: topicHeadCal[] = [];
  countryId:any;
  fromDate:any;
  todate:any;
  calculation : any;

  constructor(private http: HttpService, private fb: FormBuilder, private AlertService: AlertService, private customValidator: CutomvalidatorService) { }

  ngOnInit(): void {
    this.LoadCountries();

    this.weightConfigForm = this.fb.group({
      // id: [''],
      countryId: [null, [Validators.required, Validators.pattern("^(?!null$).*$")]],
      effectiveFrom: [null, [Validators.required]],
      effectiveTo: [null, [Validators.required]]

    }, { validator: this.customValidator.checkEffectiveDateToAfterFrom('effectiveFrom', 'effectiveTo') })
    this.LoadTableData();
  }
  LoadCountries() {
    this.http.paginatedPost('country/paginated', 1000, 1, {}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<country>;
      this.countries = convertedResp.items;
    })
  }
  LoadTableData() {
    var requestModel = {
      countryId: this.weightConfigForm.value?.countryId,
      fromDate: this.weightConfigForm.value?.effectiveFrom,
      todate: this.weightConfigForm.value?.effectiveTo,
    }
    console.log('requestModel')
    console.log(requestModel)
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
          .post(
            'topicHead/GetByCountryIdAndDateRange', {countryId:this.countryId,fromDate:this.fromDate,todate:this.todate}
          ).subscribe(resp => this.topicHeads = this.dataTableService.datatableMap(resp, callback,'my'));
      },
    };
  }
  onSubmit() {

  }
  onCancel() {
    this.weightConfigForm.reset();
  }
  onSearch() {
    if (this.weightConfigForm.valid) {
      console.log(this.weightConfigForm.value?.countryId);
   
        this.countryId= this.weightConfigForm.value?.countryId,
        this.fromDate= this.weightConfigForm.value?.effectiveFrom,
        this.todate= this.weightConfigForm.value?.effectiveTo,
      
      //console.log('ok')
      // var requestModel = {
      //   countryId:this.weightConfigForm.value?.countryId,
      //   fromDate:this.weightConfigForm.value?.effectiveFrom,
      //   todate:this.weightConfigForm.value?.effectiveTo,
      // }
      // this.http.post('topicHead/GetByCountryIdAndDateRange',requestModel).subscribe(resp => {
      //   let convertedResp = resp as topicHead[];
      //   console.log(convertedResp)
      // })
      this.dataTableService.redraw(this.datatableElement);
      console.log(this.topicHeads)
    } else {
      //console.log('not ok')

      this.weightConfigForm.markAllAsTouched();
    }
  }

  
  numberOnly(event:any, name:string=''): boolean {
    
    
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode > 31 && ((event.target.value.length > 0 ? charCode < 48 : charCode < 49) || charCode > 57)) {
      return false;
    }

    return true;
  }
  // GetDatas(x:any,y:any){
  //   console.log(x)
  //   console.log(y)
  // }

  
  GetDatas(event: any, i: any): void {
   
   
   const index = this.topicHeadCal.indexOf(i, 0);
   if (index > -1) {
    console.log('removeddddddddddd')
    this.topicHeadCal.splice(index, 1);
   }
   this.topicHeadCal.push(i,event.target.value);
   console.log('-----------------------')
    console.log(this.topicHeadCal)
   console.log('-----------------------')

  
  }
}
