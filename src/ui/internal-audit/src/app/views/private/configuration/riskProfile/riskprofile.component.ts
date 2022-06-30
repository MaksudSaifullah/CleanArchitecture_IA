import { AfterViewInit, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ModalComponent } from '@coreui/angular-pro';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { riskProfile } from '../../../../core/interfaces/common/riskProfile.interface';
import { HttpService } from '../../../../core/services/http.service';
import Swal from 'sweetalert2';
import {FormService} from '../../../../core/services/form.service';
import {DatatableService} from '../../../../core/services/datatable.service';
import {AlertService} from '../../../../core/services/alert.service';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
@Component({
  selector: 'app-riskProfile',
  templateUrl: './riskProfile.component.html',
  styleUrls: ['./riskProfile.component.scss']
})
export class RiskProfileComponent implements OnInit {
    // ngOnInit(): void {
    //     throw new Error('Method not implemented.');
    // }
  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings = {};
  riskProfiles: riskProfile[] = [];
  riskProfileForm: FormGroup;
  formService: FormService = new FormService();
  dataTableService: DatatableService = new DatatableService();
  dtTrigger: Subject<any> = new Subject<any>();

  constructor(private http: HttpService , private fb: FormBuilder, private AlertService: AlertService) {
    this.riskProfileForm = this.fb.group({
      id: [''],
      LikelihoodTypeId: [''],
      ImpactTypeId: [''],
      RatingTypeId: [''],
      EffectiveFrom: Date,
      EffectiveTo: Date,
      Description: ['',[Validators.required,Validators.maxLength(20),Validators.minLength(5)]],
      
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
          .paginatedPost(
            'riskProfile/paginated',dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1),{}
          ).subscribe(resp => that.riskProfiles = this.dataTableService.datatableMap(resp,callback));
      },
    };

  }

    onSubmit(modalId:any):void{
      const localmodalId = modalId;
        if(this.riskProfileForm.valid){
          if(this.formService.isEdit(this.riskProfileForm.get('id') as FormControl)){
            this.http.put('riskProfile',this.riskProfileForm.value,null).subscribe(x=>{
              this.formService.onSaveSuccess(localmodalId,this.datatableElement);
              this.AlertService.success('Country Saved Successful');

            });
          }
          else{
            this.http.post('riskProfile',this.riskProfileForm.value).subscribe(x=>{
              this.formService.onSaveSuccess(localmodalId,this.datatableElement);
              this.AlertService.success('Country Saved Successful');
            });
          }
        }
    }

    edit(modalId:any, riskProfile:any):void {
      const localmodalId = modalId;
      console.log(riskProfile.id)
      this.http
        .getById('riskProfile',riskProfile.id)
        .subscribe(res => {
            const riskProfileResponse = res as riskProfile;
            this.riskProfileForm.setValue({id : riskProfileResponse.id, LikelihoodTypeId : riskProfileResponse.LikelihoodTypeId, ImpactTypeId: riskProfileResponse.ImpactTypeId,
                 RatingTypeId: riskProfileResponse.RatingTypeId,
                 EffectiveFrom: riskProfileResponse.EffectiveFrom,
                 EffectiveTo: riskProfileResponse.EffectiveTo,
                 Description: riskProfileResponse.Description
                });
        });
        localmodalId.visible = true;
    }
    delete(id:string){
      const that = this;
      this.AlertService.confirmDialog().then(res =>{
        if(res.isConfirmed){
            this.http.delete('riskProfile/'+ id ,{}).subscribe(response=>{
            this.AlertService.successDialog('Deleted','Country deleted successfully.');
            this.dataTableService.redraw(that.datatableElement);
          })
        }
      });
    }
    reset(){
      this.riskProfileForm.reset();
    }
  }

