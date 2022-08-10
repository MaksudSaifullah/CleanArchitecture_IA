import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { DataTableDirective } from 'angular-datatables';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';
import { workpaper } from '../../../../core/interfaces/branch-audit/workpaper.interface';
import {AlertService} from '../../../../core/services/alert.service';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-workpaper',
  templateUrl: './workpaper.component.html',
  styleUrls: ['./workpaper.component.scss']
})
export class WorkpaperComponent implements OnInit {

  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings = {};
  workpapers: workpaper[] = [];
  searchForm: FormGroup;
  workpaperForm: FormGroup;
  formService: FormService = new FormService();
  dataTableService: DatatableService = new DatatableService();
  dtTrigger: Subject<any> = new Subject<any>();
 

  constructor(private http: HttpService , private fb: FormBuilder, private AlertService: AlertService) {
    this.workpaperForm = this.fb.group({
      id: [''],
      // name: ['',[Validators.required,Validators.maxLength(20),Validators.minLength(5)]],
      // code: ['',[Validators.required,Validators.maxLength(2),Validators.minLength(2),Validators.pattern('^[A-Z ]*$')]],
      // remarks: [''],
    });
    this.searchForm = this.fb.group(
      {
        searchTerm: ['']
      }
    )
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
      ordering: false,
      ajax: (dataTablesParameters: any, callback) => {
        this.http
          .paginatedPost(
            'workpaper/paginated',dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1), this.searchForm.get('searchTerm')?.value)
            .subscribe(resp => that.workpapers = this.dataTableService.datatableMap(resp,callback));
      },
    };

  }

  onSubmit(modalId:any):void{
    const localmodalId = modalId;
      if(this.workpaperForm.valid){
        if(this.formService.isEdit(this.workpaperForm.get('id') as FormControl)){
          this.http.put('workpaper',this.workpaperForm.value,null).subscribe(x=>{
            this.formService.onSaveSuccess(localmodalId,this.datatableElement);
            this.AlertService.success('Workpaper Updated Successfully');
            });
        }
        else{
          this.http.post('workpaper',this.workpaperForm.value).subscribe(x=>{ 
            this.formService.onSaveSuccess(localmodalId, this.datatableElement);
            this.AlertService.success('Workpaper Saved Successfully');
          }); 
          
        }
      }
  }

  edit(modalId:any, workpaper:any):void {
    const localmodalId = modalId;
    console.log(workpaper.id)
    this.http
      .getById('workpaper',workpaper.id)
      .subscribe(res => {
          const workpaperResponse = res as workpaper;
         // this.workpaperForm.setValue({id : workpaperResponse.id, name : workpaperResponse.name, remarks: countryResponse.remarks, code: countryResponse.code});
      });
      localmodalId.visible = true;
  }
  delete(id:string){
    const that = this;
    this.AlertService.confirmDialog().then(res =>{
      if(res.isConfirmed){
          this.http.delete('workpaper/'+ id ,{}).subscribe(response=>{
          this.AlertService.successDialog('Deleted','workpaper deleted successfully.');
          this.dataTableService.redraw(that.datatableElement);
        })
      }
    });
  }
  reset(){
    this.workpaperForm.reset();
  }
  search(){
    this.dataTableService.redraw(this.datatableElement);
  }
}
