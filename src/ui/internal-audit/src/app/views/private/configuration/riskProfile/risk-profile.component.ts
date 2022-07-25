import { AfterViewInit, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ModalComponent } from '@coreui/angular-pro';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { riskProfile } from '../../../../core/interfaces/common/riskProfile.interface';
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
  selector: 'app-riskProfile',
  templateUrl: './risk-profile.component.html',
  styleUrls: ['./risk-profile.component.scss']
})
export class RiskProfileComponent implements OnInit {
  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings = {};
  likelihoodType: commonValueAndType[] = [];
  impactType: commonValueAndType[] = [];
  ratingType: commonValueAndType[] = [];
  riskProfiles: riskProfile[] = [];
  riskProfileForm: FormGroup;
  searchForm: FormGroup;
  formService: FormService = new FormService();
  dataTableService: DatatableService = new DatatableService();
  dtTrigger: Subject<any> = new Subject<any>();
  //effectiveFrom: any;

  constructor(private http: HttpService , private fb: FormBuilder, private AlertService: AlertService, private customValidator: CutomvalidatorService,) {
    this.LoadDropDownValues();
    this.riskProfileForm = this.fb.group({
      id: [''],
      likelihoodTypeId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      impactTypeId: [null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      ratingTypeId: [null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      description: [''],
      effectiveFrom: [Date,[Validators.required]],
      effectiveTo: [Date, [Validators.required]],
      isActive: []
      
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
      ajax: (dataTablesParameters: any, callback) => {
        this.http
          .paginatedPost(
            'riskprofile/paginated',dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1),this.searchForm.get('searchTerm')?.value
          ).subscribe(resp => that.riskProfiles = this.dataTableService.datatableMap(resp,callback));
      },
    };

  }

  LoadLikelihoodLevel() {
    this.http.get('commonValueAndType/leveloflikelihood').subscribe(resp => {
      let convertedResp = resp as commonValueAndType[];
      this.likelihoodType = convertedResp;
    })
  }

  LoadImpactLevel() {
    this.http.get('commonValueAndType/levelofimpact').subscribe(resp => {
      let convertedResp = resp as commonValueAndType[];
      this.impactType = convertedResp;
    })
  }

  LoadRiskRating() {
    this.http.get('commonValueAndType/riskrating').subscribe(resp => {
      let convertedResp = resp as commonValueAndType[];
      this.ratingType = convertedResp;
    })
  }

  LoadDropDownValues() {
    this.LoadLikelihoodLevel();
    this.LoadImpactLevel();
    this.LoadRiskRating();
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
    if (this.riskProfileForm.valid ){
      if(this.formService.isEdit(this.riskProfileForm.get('id') as FormControl)){
        this.http.put('riskProfile',this.riskProfileForm.value,null).subscribe(x=>{
            localmodalId.visible = false;
            this.dataTableService.redraw(this.datatableElement);
            this.AlertService.success('Risk Profile Updated Successfully');
          });
      }
      else {
       // console.log(this.riskProfileForm.value);
        this.http.post('riskProfile',this.riskProfileForm.value).subscribe(x=>{
          this.formService.onSaveSuccess(localmodalId,this.datatableElement);
          this.AlertService.success('Risk Profile Saved Successfully');
        });
      }      
    }
    else {     
      this.riskProfileForm.markAllAsTouched();
      return;
    }    
  }

  edit(modalId:any, riskProfile:any):void {
    const localmodalId = modalId;
    //console.log('hello');
    this.http
      .getById('riskProfile', riskProfile.id)
      .subscribe(res => {
          const riskProfileResponse = res as riskProfile;
          //this.effectiveFrom = riskProfileResponse.effectiveFrom;
          //console.log(riskProfileResponse);
          this.riskProfileForm.setValue({id : riskProfileResponse.id, likelihoodTypeId : riskProfileResponse.likelihoodTypeId, 
            impactTypeId: riskProfileResponse.impactTypeId, ratingTypeId: riskProfileResponse.ratingTypeId, 
            effectiveFrom: formatDate(riskProfileResponse.effectiveFrom, 'yyyy-MM-dd', 'en'), effectiveTo: formatDate(riskProfileResponse.effectiveTo, 'yyyy-MM-dd', 'en'),
            description: riskProfileResponse.description, isActive: riskProfileResponse.isActive
          });
      });
      localmodalId.visible = true;
      
  }

  delete(id:string){
    const that = this;
    this.AlertService.confirmDialog().then(res =>{
      if(res.isConfirmed){
          this.http.delete('riskProfile/'+ id ,{}).subscribe(response=>{
          this.AlertService.successDialog('Deleted','Risk Profile deleted successfully.');
          this.dataTableService.redraw(that.datatableElement);
        })
      }
    });
  }
  reset(){
    this.riskProfileForm.reset();
  }
  search(){
    this.dataTableService.redraw(this.datatableElement);
  }

}

