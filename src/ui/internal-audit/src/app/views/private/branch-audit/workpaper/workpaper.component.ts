import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { DataTableDirective } from 'angular-datatables';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';
import { workpaper } from '../../../../core/interfaces/branch-audit/workpaper.interface';
import {AlertService} from '../../../../core/services/alert.service';
import { Subject } from 'rxjs';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { topicHead } from 'src/app/core/interfaces/branch-audit/topicHead.interface';
import { commonValueAndType } from 'src/app/core/interfaces/configuration/commonValueAndType.interface';
import { questionnaire } from 'src/app/core/interfaces/branch-audit/questionnaire.interface';
import { Branch } from 'src/app/core/interfaces/branch-audit/branch.interface';
import { Router } from '@angular/router';
import { HelperService } from 'src/app/core/services/helper.service';

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
  topics: topicHead[] =[];
  questions: questionnaire[] =[];
  branches: Branch[] =[];
  sampledmonths: commonValueAndType[] = [];
  sampleSelectionMethods: commonValueAndType[] = [];
  controlActivityNatures: commonValueAndType[] = [];
  controlFrequencies: commonValueAndType[] = [];
  sampleSizes: commonValueAndType[] = [];
  testingConclusions: commonValueAndType[] = [];
  searchForm: FormGroup;
  formService: FormService = new FormService();
  dataTableService: DatatableService = new DatatableService();
  dtTrigger: Subject<any> = new Subject<any>();
 

  constructor(private http: HttpService,private router: Router, private helper: HelperService , private fb: FormBuilder, private AlertService: AlertService) {
   this.loadDropDownValues();

    this.searchForm = this.fb.group(
      {
        topicHeadId:[''],
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
            'workpaper/paginated',dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1), this.searchForm.get('topicHeadId')?.value)
            .subscribe(resp => that.workpapers = this.dataTableService.datatableMap(resp,callback));
      },
    };

  }

  // onSubmit(modalId:any):void{
  //   const localmodalId = modalId;
  //     if(this.workpaperForm.valid){
  //       if(this.formService.isEdit(this.workpaperForm.get('id') as FormControl)){
  //         this.http.put('workpaper',this.workpaperForm.value,null).subscribe(x=>{
  //           this.formService.onSaveSuccess(localmodalId,this.datatableElement);
  //           this.AlertService.success('Workpaper Updated Successfully');
  //           });
  //       }
  //       else{
  //         this.http.post('workpaper',this.workpaperForm.value).subscribe(x=>{ 
  //           this.formService.onSaveSuccess(localmodalId, this.datatableElement);
  //           this.AlertService.success('Workpaper Saved Successfully');
  //         }); 
          
  //       }
  //     }
  // }

  // edit(id: any):void {
  //   this.http
  //     .getById('workpaper',id)
  //     .subscribe(res => {
  //         const workpaperResponse = res as workpaper;
  //        //this.workpaperForm.setValue({id : workpaperResponse.id, name : workpaperResponse.name, remarks: countryResponse.remarks, code: countryResponse.code});
  //     });
  // }

  edit(id:string){
    this.router.navigate(['/branch-audit/workpaperCreate/'+ id] );
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
  // reset(){
  //   this.workpaperForm.reset();
  // }
  search(){
    this.dataTableService.redraw(this.datatableElement);
  }

  fileDownLoad(d: any) {
    console.log(d);
    this.http.getFilesAsBlob('Document/get-file-stream?Id=' + d,
    )
      .subscribe((resp: any) => {
        let fileName = resp.headers.get('content-disposition');
        console.log(fileName);
        //  return;


        this.helper.downloadFile(resp);

      }), (error: any) => console.log('Error downloading the file'),
      () => console.info('File downloaded successfully');
  }

  LoadTopicHeadDropdownList() 
  {
    this.http.paginatedPost('topicHead/paginated', 1000, 1, '').subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<topicHead>;
      this.topics = convertedResp.items;     
    })
  }

  loadDropDownValues() 
  {
    this.LoadTopicHeadDropdownList();
  }

}
