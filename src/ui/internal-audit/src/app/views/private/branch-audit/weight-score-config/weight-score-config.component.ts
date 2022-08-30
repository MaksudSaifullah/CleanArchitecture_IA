import { Component, OnInit, ViewChild } from '@angular/core';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';
import { AlertService } from '../../../../core/services/alert.service';
import { FormBuilder, FormControl, FormGroup, Validators, FormArray } from '@angular/forms';
import { country } from 'src/app/core/interfaces/configuration/country.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { CutomvalidatorService } from 'src/app/core/services/cutomvalidator.service'
import { topicHead } from 'src/app/core/interfaces/branch-audit/topicHead.interface';
import { DataTableDirective } from 'angular-datatables';

@Component({
  selector: 'app-weight-score-config',
  templateUrl: './weight-score-config.component.html',
  styleUrls: ['./weight-score-config.component.scss']
})
export class WeightScoreConfigComponent implements OnInit {
  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings = {};
  countries: country[] = [];
  weightConfigForm!: FormGroup;
 topicHeads:topicHead[]=[];
  constructor(private http: HttpService, private fb: FormBuilder, private AlertService: AlertService, private customValidator: CutomvalidatorService) { }

  ngOnInit(): void {
    this.LoadCountries();
    this.weightConfigForm = this.fb.group({
      // id: [''],
      countryId: [null, [Validators.required, Validators.pattern("^(?!null$).*$")]],
      effectiveFrom: ['', [Validators.required]],
      effectiveTo: ['', [Validators.required]]

    }, { validator: this.customValidator.checkEffectiveDateToAfterFrom('effectiveFrom', 'effectiveTo') })
  }
  LoadCountries() {
    this.http.paginatedPost('country/paginated', 1000, 1, {}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<country>;
      this.countries = convertedResp.items;
    })
  }
  // LoadTable(){
  //   const that=this;
  //   this.dtOptions = {
  //     pagingType: 'full_numbers',
  //     pageLength: 10,
  //     serverSide: true,
  //     processing: true,
  //     searching: false,
  //     ordering: false,
  //     ajax: (dataTablesParameters: any, callback) => {
  //       console.log('hellllo:' );
  //       this.http
  //         .paginatedPost(
  //           'designation/paginated', dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1), this.searchForm.get('searchTerm')?.value
  //         ).subscribe(resp => {
  //           let convertedResp = resp as paginatedResponseInterface<designation>;
  //           console.log(convertedResp);
  //          // that.designations = convertedResp.items;
  //           callback({
  //             recordsTotal: convertedResp.totalCount,
  //             recordsFiltered: convertedResp.totalCount,
  //             data: []
  //           });
  //         });
  //     },
  //   };
  // }
  onSubmit() {

  }
  onCancel() {
    this.weightConfigForm.reset();
  }
  onSearch() {
    if(this.weightConfigForm.valid){
    //console.log('ok')
    var requestModel = {
      countryId:this.weightConfigForm.value?.countryId,
      fromDate:this.weightConfigForm.value?.effectiveFrom,
      todate:this.weightConfigForm.value?.effectiveTo,
    }
    this.http.post('topicHead/GetByCountryIdAndDateRange',requestModel).subscribe(resp => {
      let convertedResp = resp as topicHead[];
      console.log(convertedResp)
    })
    }else{
    //console.log('not ok')

      this.weightConfigForm.markAllAsTouched();
    }
  }
}
