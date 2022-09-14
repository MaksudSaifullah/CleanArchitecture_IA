import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { AuditSchedule } from 'src/app/core/interfaces/branch-audit/auditSchedule.interface';
import { WPAuditScheduleBranch } from 'src/app/core/interfaces/branch-audit/auditScheduleBranch.interface';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { HelperService } from 'src/app/core/services/helper.service';
import { HttpService } from 'src/app/core/services/http.service';
import { checklist } from '../../../../core/interfaces/branch-audit/checklist.interface';
import {AlertService} from '../../../../core/services/alert.service';

@Component({
  selector: 'app-checklist',
  templateUrl: './checklist.component.html',
  styleUrls: ['./checklist.component.scss']
})
export class ChecklistComponent implements OnInit {

  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings = {};
  dataTableService: DatatableService = new DatatableService();
  searchForm: FormGroup;

  checklists: checklist[] = [];
  wpAuditScheduleBranches : WPAuditScheduleBranch[] = [];
  auditSchedules: AuditSchedule[] =[];
  paramId:string ='';

  constructor(private http: HttpService,private router: Router, private helper: HelperService , private fb: FormBuilder, private AlertService: AlertService) 
  {
    this.searchForm = this.fb.group(
      {
        searchTerm:[''],
      }
    )
  }

  ngOnInit(): void {
    this.LoadData();
    this.paramId = 'C09240DA-02DE-4B96-9A61-C9CA8F741C89';
   // this.LoadScheduleData(this.paramId);
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
            'checklist/paginated',dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1), this.searchForm.get('searchTerm')?.value)
            .subscribe(resp => that.checklists = this.dataTableService.datatableMap(resp,callback));
      },
    };

  }
  edit(id:string){
    this.router.navigate(['/branch-audit/checklist-create/'+ id] );
  }
  search(){
    this.dataTableService.redraw(this.datatableElement);
  }

  delete(id:string){
    const that = this;
    this.AlertService.confirmDialog().then(res =>{
      if(res.isConfirmed){
          this.http.delete('checklist/'+ id ,{}).subscribe(response=>{
          this.AlertService.successDialog('Deleted','Checklist deleted successfully.');
          this.dataTableService.redraw(that.datatableElement);
        })
      }
    });
  }

}
