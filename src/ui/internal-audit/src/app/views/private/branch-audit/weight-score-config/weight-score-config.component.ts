import { Component, OnInit } from '@angular/core';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';
import { AlertService } from '../../../../core/services/alert.service';
import { FormBuilder, FormControl, FormGroup, Validators, FormArray } from '@angular/forms';
import { country } from 'src/app/core/interfaces/configuration/country.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { CutomvalidatorService } from 'src/app/core/services/cutomvalidator.service'
import { topicHead } from 'src/app/core/interfaces/branch-audit/topicHead.interface';

@Component({
  selector: 'app-weight-score-config',
  templateUrl: './weight-score-config.component.html',
  styleUrls: ['./weight-score-config.component.scss']
})
export class WeightScoreConfigComponent implements OnInit {
  countries: country[] = [];
  weightConfigForm!: FormGroup;

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
