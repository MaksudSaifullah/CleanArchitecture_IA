import { AfterViewInit, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ModalComponent } from '@coreui/angular-pro';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { riskCriteria } from '../../../../core/interfaces/branch-audit/riskCriteria.interface';
import { commonValueAndType } from '../../../../core/interfaces/configuration/commonValueAndType.interface';
import { HttpService } from '../../../../core/services/http.service';
import Swal from 'sweetalert2';
import {FormService} from '../../../../core/services/form.service';
import {DatatableService} from '../../../../core/services/datatable.service';
import {AlertService} from '../../../../core/services/alert.service';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { formatDate } from '@angular/common';
import { country } from 'src/app/core/interfaces/configuration/country.interface';
import { CutomvalidatorService } from 'src/app/core/services/cutomvalidator.service';


@Component({
  selector: 'app-risk-criteria',
  templateUrl: './risk-criteria.component.html',
  styleUrls: ['./risk-criteria.component.scss']
})
export class RiskCriteriaComponent implements OnInit {
  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings[] = [];
  // dtOptions: DataTables.Settings = {};
  riskCriteriaType: commonValueAndType[] = [];
  ratingType: commonValueAndType[] = [];
  riskCriterias: riskCriteria[] = [];
  countries: country[] = [];
  riskCriteriaForm: FormGroup;
  searchForm: FormGroup;
  formService: FormService = new FormService();
  dataTableService: DatatableService = new DatatableService();
  dtTrigger: Subject<any> = new Subject<any>();
  effectiveFrom: any;

  constructor(private http: HttpService , private fb: FormBuilder, private AlertService: AlertService, private customValidator: CutomvalidatorService,) {
    this.LoadDropDownValues();
    this.riskCriteriaForm = this.fb.group({
      id: [''],
      countryId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      riskCriteriaTypeId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      minimumValue: ['',[Validators.required]],
      maximumValue: ['',[Validators.required]],
      ratingTypeId: [null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      score: ['',[Validators.required,Validators.maxLength(10),Validators.minLength(1)]],
      effectiveFrom: [Date,[Validators.required]],
      effectiveTo: [Date, [Validators.required]],
      description: ['']
      
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
    
    this.dtOptions[0] = {
      pagingType: 'full_numbers',
      pageLength: 10,
      serverSide: true,
      processing: true,
      searching: false,
      ajax: (dataTablesParameters: any, callback) => {
        this.http
          .paginatedPost(
            'riskcriteria/paginated', dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1),this.searchForm.get('searchTerm')?.value
          ).subscribe(resp => that.riskCriterias = this.dataTableService.datatableMap(resp, callback));
      },
    };
  }

  LoadCountry() {
    this.http.paginatedPost('country/paginated', 100, 1, {}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<country>;
      this.countries = convertedResp.items;    
    })
  }

  LoadRiskCriteriaName() {
    this.http.get('commonValueAndType/riskratingname').subscribe(resp => {
      let convertedResp = resp as commonValueAndType[];
      this.riskCriteriaType = convertedResp;
    })
  }
  LoadRiskRating() {
    this.http.get('commonValueAndType/riskrating').subscribe(resp => {
      let convertedResp = resp as commonValueAndType[];
      this.ratingType = convertedResp;
    })
  }
  LoadDropDownValues() {
    this.LoadCountry();
    this.LoadRiskCriteriaName();
    this.LoadRiskRating();
  }

  onSubmit(modalId:any):void{
    const localmodalId = modalId;
    if (this.riskCriteriaForm.valid ){
      if(this.formService.isEdit(this.riskCriteriaForm.get('id') as FormControl)){
        this.http.put('riskCriteria',this.riskCriteriaForm.value,null).subscribe(x=>{
            localmodalId.visible = false;
            this.dataTableService.redraw(this.datatableElement);
            this.AlertService.success('Risk Criteria Updated Successful');
          });
      }
      else {
       // console.log(this.riskProfileForm.value);
        this.http.post('riskCriteria',this.riskCriteriaForm.value).subscribe(x=>{
          this.formService.onSaveSuccess(localmodalId,this.datatableElement);
          this.AlertService.success('Risk Criteria Saved successfully');
        });
      }      
    }
    else {     
      this.riskCriteriaForm.markAllAsTouched();
      return;
    }    
  }

  edit(modalId:any, riskCriteria:any):void {
    const localmodalId = modalId;
    //console.log('hello');
    this.http
      .getById('riskCriteria', riskCriteria.id)
      .subscribe(res => {
          const riskCriteriaResponse = res as riskCriteria;
          this.effectiveFrom = riskCriteriaResponse.effectiveFrom;
          //console.log(riskProfileResponse);
          this.riskCriteriaForm.setValue({id : riskCriteriaResponse.id, countryId:riskCriteriaResponse.countryId, riskCriteriaTypeId : riskCriteriaResponse.riskCriteriaTypeId, 
            minimumValue: riskCriteriaResponse.minimumValue, maximumValue: riskCriteriaResponse.maximumValue, 
            ratingTypeId: riskCriteriaResponse.ratingTypeId, score: riskCriteriaResponse.score,
            effectiveFrom: formatDate(riskCriteriaResponse.effectiveFrom, 'yyyy-MM-dd', 'en'), effectiveTo: formatDate(riskCriteriaResponse.effectiveTo, 'yyyy-MM-dd', 'en'),
            description: riskCriteriaResponse.description
          });
      });
      localmodalId.visible = true;
      
  }

  delete(id:string){
    const that = this;
    this.AlertService.confirmDialog().then(res =>{
      if(res.isConfirmed){
          this.http.delete('riskCriteria/'+ id ,{}).subscribe(response=>{
          this.AlertService.successDialog('Deleted','Risk Criteria deleted successfully.');
          this.dataTableService.redraw(that.datatableElement);
        })
      }
    });
  }
  reset(){
    this.riskCriteriaForm.reset();
  }

  search(){
    this.dataTableService.redraw(this.datatableElement);
  }

}
