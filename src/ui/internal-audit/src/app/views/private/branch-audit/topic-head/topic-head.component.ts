import { Component, Input, OnInit, QueryList, ViewChildren } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DataTableDirective } from 'angular-datatables';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { FormService } from 'src/app/core/services/form.service';
import { HttpService } from 'src/app/core/services/http.service';
import { AlertService } from '../../../../core/services/alert.service';
import { topicHead } from 'src/app/core/interfaces/branch-audit/topicHead.interface';

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

  constructor(private http: HttpService, private fb: FormBuilder, private AlertService: AlertService) 
  {
    //this.loadDropDownValues();
    this.topicHeadForm = this.fb.group({
      id: [''],
      name: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]],
      effectiveFrom: ['', [Validators.required]],
      effectiveTo: ['', [Validators.required]],
      description: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],      
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
  reset(){

  }
  onSubmit(modalId: any): void
  {

  }
}
