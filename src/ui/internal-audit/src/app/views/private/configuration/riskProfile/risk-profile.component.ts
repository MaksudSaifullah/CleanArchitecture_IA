import { AfterViewInit, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
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
//import {MatDatepickerModule} from '@angular/material/datepicker';

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
  formService: FormService = new FormService();
  dataTableService: DatatableService = new DatatableService();
  dtTrigger: Subject<any> = new Subject<any>();

  constructor(private http: HttpService , private fb: FormBuilder, private AlertService: AlertService) {
    this.LoadDropDownValues();
    this.riskProfileForm = this.fb.group({
      id: [''],
      likelihoodLevel:[null,[Validators.required]],
      impactLevel: [null,[Validators.required]],
      riskLevel: [null,[Validators.required]],
      Description: ['',[Validators.maxLength(200),Validators.minLength(2)]],
      EffectiveFrom: Date,
      EffectiveTo: Date    
    })
  }
  ngOnDestroy(): void {

  }
  ngOnInit(): void {
   // debugger;
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
            'riskprofile/paginated',dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1),{}
          ).subscribe(resp => that.riskProfiles = this.dataTableService.datatableMap(resp,callback));
      },
    };

  }

  LoadLikelihoodLevel() {
    this.http.get('commonValueAndType/leveloflikelihood').subscribe(resp => {
      let convertedResp = resp as commonValueAndType[];
      this.likelihoodType = convertedResp;
      //console.log(this.likelihoodType);
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

    onSubmit(modalId:any):void{
      debugger;
      const localmodalId = modalId;
        if(this.riskProfileForm.valid){
          if(this.formService.isEdit(this.riskProfileForm.get('id') as FormControl)){
            this.http.put('riskProfile',this.riskProfileForm.value,null).subscribe(x=>{
              this.formService.onSaveSuccess(localmodalId,this.datatableElement);
              this.AlertService.success('Risk Profile Saved successfully');

            });
          }
          else{
            this.http.post('riskProfile',this.riskProfileForm.value).subscribe(x=>{
              this.formService.onSaveSuccess(localmodalId,this.datatableElement);
              this.AlertService.success('Risk Profile Saved successfully');
            });
         }
       }
    }

    // edit(modalId:any, riskProfile:any):void {
    //   const localmodalId = modalId;
    //   console.log(riskProfile.id)
    //   this.http
    //     .getById('riskProfile',riskProfile.id)
    //     .subscribe(res => {
    //         const riskProfileResponse = res as riskProfile;
    //         this.riskProfileForm.setValue({id : riskProfileResponse.id, LikelihoodTypeId : riskProfileResponse.likelihoodTypeId, ImpactTypeId: riskProfileResponse.impactTypeId,
    //              RatingTypeId: riskProfileResponse.ratingTypeId,
    //              EffectiveFrom: riskProfileResponse.effectiveFrom,
    //              EffectiveTo: riskProfileResponse.effectiveTo,
    //              Description: riskProfileResponse.description
    //             });
    //     });
    //     localmodalId.visible = true;
    // }
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
  }

