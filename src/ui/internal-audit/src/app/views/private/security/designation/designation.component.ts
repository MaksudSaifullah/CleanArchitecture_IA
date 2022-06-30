import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { designation } from 'src/app/core/interfaces/security/designation.interface';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';
import {AlertService} from '../../../../core/services/alert.service';

@Component({
  selector: 'app-designation',
  templateUrl: './designation.component.html',
  styleUrls: ['./designation.component.scss']
})
export class DesignationComponent implements OnInit {
  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings = {};
  designations: designation[] = [];
  designationForm: FormGroup;
  formService: FormService = new FormService();
  dataTableService: DatatableService = new DatatableService();
  dtTrigger: Subject<any> = new Subject<any>();

  constructor(private http: HttpService , private fb: FormBuilder, private AlertService: AlertService) {
    this.designationForm = this.fb.group({
      id: [''],
      name: ['',[Validators.required,Validators.maxLength(50),Validators.minLength(2)]],
      description: ['',[Validators.required]]      
    })
  }
  ngOnDestroy(): void {
  }
  ngOnInit(): void {
    this.LoadData();
  }
  
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
            'designation/paginated', dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1),{}
          ).subscribe(resp => {
            let convertedResp = resp as paginatedResponseInterface<designation>;
            console.log(convertedResp);
            that.designations = convertedResp.items;
            callback({
              recordsTotal: convertedResp.totalCount,
              recordsFiltered: convertedResp.totalCount,
              data: []
            });
          });
      },
    };

  }
  onSubmit(modalId:any):void 
  {
    const localmodalId = modalId;
      if(this.designationForm.valid){        
        if(this.formService.isEdit(this.designationForm.get('id') as FormControl)){
          this.http.put('designation',this.designationForm.value,null).subscribe(x=>{
            localmodalId.visible = false;
            this.dataTableService.redraw(this.datatableElement);
            this.AlertService.success('Designation Saved Successful');

          });
        }
        else{
          this.http.post('designation',this.designationForm.value).subscribe(x=>{
            localmodalId.visible = false;
            this.dataTableService.redraw(this.datatableElement);
            this.AlertService.success('Designation Saved Successful');
          });
        }
      }
      else{
        this.AlertService.error('Invalid Information');
      }
  }
  edit(modalId:any, designation:any):void 
  {
    debugger;
    const localmodalId = modalId;
    console.log(designation.id)
    this.http
      .getById('designation',designation.id)
      .subscribe(res => {
          const designationResponse = res as designation;
          this.designationForm.setValue({id : designationResponse.id, name : designationResponse.name, description: designationResponse.description});
      });
      localmodalId.visible = true;
  }
  delete(id:string){
    const that = this;
    this.AlertService.confirmDialog().then(res =>{
      if(res.isConfirmed){
          this.http.delete('designation/'+ id ,{}).subscribe(response=>{
          this.AlertService.successDialog('Deleted','Designation deleted successfully.');
          this.dataTableService.redraw(that.datatableElement);
        })
      }
    });
  }
  reset(){
    this.designationForm.reset();
  }

}
