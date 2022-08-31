import { Component, OnInit, ViewChild } from '@angular/core';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';
import { AlertService } from '../../../../core/services/alert.service';
import { FormBuilder, FormControl, FormGroup, Validators, FormArray } from '@angular/forms';
import { country } from 'src/app/core/interfaces/configuration/country.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { CutomvalidatorService } from 'src/app/core/services/cutomvalidator.service'
import { topicHead, topicHeadCal } from 'src/app/core/interfaces/branch-audit/topicHead.interface';
import { WeightScoreConfigRequest, WeightScoreDatum } from 'src/app/core/interfaces/branch-audit/weight-score-config.interface';
import { DataTableDirective } from 'angular-datatables';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { firstValueFrom } from 'rxjs';

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
  countryId: any;
  fromDate: any;
  todate: any;
  calculation: any;
  tableHide: boolean = true;
  request: WeightScoreConfigRequest[] = [];
  constructor(private http: HttpService, private fb: FormBuilder, private AlertService: AlertService, private customValidator: CutomvalidatorService) { }

  ngOnInit(): void {
    this.LoadCountries();

    this.weightConfigForm = this.fb.group({
      // id: [''],
      countryId: [null, [Validators.required, Validators.pattern("^(?!null$).*$")]],
      effectiveFrom: [null, [Validators.required]],
      effectiveTo: [null, [Validators.required]],
      maxval: [0, Validators.maxLength(100)]

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
            'topicHead/GetByCountryIdAndDateRange', { countryId: this.countryId, fromDate: this.fromDate, todate: this.todate }
          ).subscribe(resp => this.topicHeads = this.dataTableService.datatableMap(resp, callback, 'my'));
      },
    };
  }
  onSubmit() {
    if (this.weightConfigForm.valid) {
      let sum = 0;
      this.topicHeadCal.forEach((ctrl: topicHeadCal) => {
        sum += Number(ctrl.value)
      });
      if (sum != 100) {
        this.AlertService.errorDialog('Error', 'All value sum must need to be equal 100')
        return;
      }
      let xx: WeightScoreConfigRequest = { weightScoreData: [] };


      this.CreateRequestModel(xx);
      this.http.post('weightscoreconfiguration', xx).subscribe(x => {
        this.AlertService.success('Configuration added successfully');
      })






    } else {
      this.weightConfigForm.markAllAsTouched();
    }

  }
  async CreateRequestModel(xx: WeightScoreConfigRequest): Promise<any> {
    this.topicHeadCal.forEach(async (ctrl: topicHeadCal) => {
      let x: WeightScoreDatum = {
        countryId: this.weightConfigForm.value?.countryId,
        score: Number(ctrl.value),
        topicHeadId: ctrl.id
      };
      xx.weightScoreData?.push(x);
    });
  }

  onCancel() {
    this.weightConfigForm.reset();
    this.topicHeadCal = [];
    this.countryId = null;
    this.fromDate = null;
    this.todate = null;
    this.dataTableService.redraw(this.datatableElement);
  }
  onSearch() {
    if (this.weightConfigForm.valid) {
      console.log(this.weightConfigForm.value?.countryId);
      this.topicHeadCal = [];
      this.countryId = this.weightConfigForm.value?.countryId;
        this.fromDate = this.weightConfigForm.value?.effectiveFrom;
        this.todate = this.weightConfigForm.value?.effectiveTo;

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

    } else {
      //console.log('not ok')

      this.weightConfigForm.markAllAsTouched();
    }
  }


  numberOnly(event: any, name: string = ''): boolean {


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

    const a1: topicHeadCal = {
      id: i,
      value: event.target.value
    };

    const index = this.topicHeadCal.findIndex(j => j.id === i);

    if (index > -1) {
      this.topicHeadCal.splice(index, 1);
    }
    this.topicHeadCal.push(a1)
    console.log(this.topicHeadCal)
    let sum = 0;
    this.topicHeadCal.forEach((ctrl: topicHeadCal) => {
      sum += Number(ctrl.value)
    });
    if (sum > 100) {
      this.AlertService.toastrService.error("All value sum can't be greater than 100");
    }

  }
}
