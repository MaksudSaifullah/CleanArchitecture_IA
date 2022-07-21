import { Component, Input, OnInit, QueryList, ViewChildren } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { DataTableDirective } from 'angular-datatables';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';
import { AlertService } from '../../../../core/services/alert.service';
import { topicHead } from 'src/app/core/interfaces/branch-audit/topicHead.interface';
import { country } from 'src/app/core/interfaces/configuration/country.interface';
import { paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';

@Component({
  selector: 'app-topic-head',
  templateUrl: './topic-head.component.html',
  styleUrls: ['./topic-head.component.scss']
})
export class TopicHeadComponent implements OnInit {
  @Input('tabPaneIdx')
  tabIndex!: string;

  @ViewChildren(DataTableDirective)
  dtElements: QueryList<DataTableDirective> | undefined;
  // datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings[] = [];
  topicHeadForm: FormGroup;
  formService: FormService = new FormService();
  dataTableService: DatatableService = new DatatableService();
  topicheads: topicHead[] = [];
  countries: country[] = [];

  constructor(private http: HttpService, private fb: FormBuilder, private AlertService: AlertService) 
  {
    this.loadDropDownValues();
    this.topicHeadForm = this.fb.group({
      id: [''],
      countryId: [null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
      name: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      effectiveFrom: [Date, [Validators.required]],
      effectiveTo: [Date, [Validators.required]],
      description: ['', [Validators.maxLength(300)]],      
    })
  }

  ngOnInit(): void {
    this.LoadData();
  }

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
            'topicHead/paginated', dataTablesParameters.length, ((dataTablesParameters.start / dataTablesParameters.length) + 1), ''
          ).subscribe(resp => that.topicheads = this.dataTableService.datatableMap(resp, callback));
      },
    };
  }

  loadDropDownValues() 
  {
    this.LoadCountries();
  }

  LoadCountries() 
  {
    this.http.paginatedPost('country/paginated', 100, 1, {}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<country>;
      this.countries = convertedResp.items;     
    })
  }

  onSubmit(modalId:any):void 
  {
    const localmodalId = modalId;
    if (this.topicHeadForm.valid ){
      if(this.formService.isEdit(this.topicHeadForm.get('id') as FormControl)){
        this.http.put('topicHead',this.topicHeadForm.value,null).subscribe(x=>{
          this.formService.onSaveSuccess(localmodalId, this.ReloadAllDataTable());          
          this.AlertService.success('Topic Head saved Successful');
        });
      }
      else {
       // console.log(this.riskProfileForm.value);
        this.http.post('topicHead',this.topicHeadForm.value).subscribe(x=>{
          this.formService.onSaveSuccess(localmodalId,this.ReloadAllDataTable());
          this.AlertService.success('Topic Head saved successfully');
        });
      }      
    }
    else {     
      this.topicHeadForm.markAllAsTouched();
      return;
    }    
  }

  private ReloadAllDataTable() {
    this.dtElements?.forEach((dtElement: DataTableDirective, index: number) => {
      this.dataTableService.redraw(dtElement);
    });
  }
  reset(){
    this.topicHeadForm.reset();
  }
  
  delete(id: string) {
    const that = this;
    this.AlertService.confirmDialog().then(res => {
      if (res.isConfirmed) {
        this.http.delete('topicHead/id?Id=' + id, {}).subscribe(response => {
          this.AlertService.successDialog('Deleted', 'Topic Head deleted successfully.');
          this.ReloadAllDataTable();
        })
      }
    });
  }
}
