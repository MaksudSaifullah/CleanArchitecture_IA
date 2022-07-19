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


@Component({
  selector: 'app-risk-criteria',
  templateUrl: './risk-criteria.component.html',
  styleUrls: ['./risk-criteria.component.scss']
})
export class RiskCriteriaComponent implements OnInit {
  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings = {};
  riskCriteriaType: commonValueAndType[] = [];
  ratingType: commonValueAndType[] = [];
  riskCriterias: riskCriteria[] = [];
  countries: country[] = [];
  riskCriteriaForm: FormGroup;
  formService: FormService = new FormService();
  dataTableService: DatatableService = new DatatableService();
  dtTrigger: Subject<any> = new Subject<any>();
  effectiveFrom: any;

  constructor(private http: HttpService , private fb: FormBuilder, private AlertService: AlertService) {
    this.LoadDropDownValues();
    this.riskCriteriaForm = this.fb.group({
      id: [''],
      countryId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      riskCriteriaTypeId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      minimumValue: [''],
      maximumValue: [''],
      ratingTypeId: [null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      score: [''],
      effectiveFrom: [Date,[Validators.required]],
      effectiveTo: [Date, [Validators.required]],
      description: ['']
      
    })
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
      ajax: (dataTablesParameters: any, callback) => {
        this.http
          // .paginatedPost(
          //   'riskprofile/paginated',dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1),{}
          // ).subscribe(resp => that.riskProfiles = this.dataTableService.datatableMap(resp,callback));
      },
    };

  }

  // LoadLikelihoodLevel() {
  //   this.http.get('commonValueAndType/leveloflikelihood').subscribe(resp => {
  //     let convertedResp = resp as commonValueAndType[];
  //     this.likelihoodType = convertedResp;
  //   })
  // }

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
   // this.LoadLikelihoodLevel();
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
            this.AlertService.success('Risk Criteria Saved Successful');
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
          this.riskCriteriaForm.setValue({id : riskCriteriaResponse.id, riskCriteriaTypeId : riskCriteriaResponse.riskCriteriaTypeId, 
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

}

