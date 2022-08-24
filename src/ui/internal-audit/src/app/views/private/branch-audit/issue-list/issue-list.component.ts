
import { AfterViewInit, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { issue } from '../../../../core/interfaces/branch-audit/issue.interface';
import { commonValueAndType } from '../../../../core/interfaces/configuration/commonValueAndType.interface';
import { HttpService } from '../../../../core/services/http.service';
import Swal from 'sweetalert2';
import {FormService} from '../../../../core/services/form.service';
import {DatatableService} from '../../../../core/services/datatable.service';
import {AlertService} from '../../../../core/services/alert.service';
import { formatDate } from '@angular/common';
import { CommonResponseInterface } from 'src/app/core/interfaces/common-response.interface';
import { Router } from '@angular/router';

@Component({
  selector: 'app-issue-list',
  templateUrl: './issue-list.component.html',
  styleUrls: ['./issue-list.component.scss']
})
export class IssueListComponent implements OnInit {
  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective | undefined;
  dtOptions: DataTables.Settings = {};
  // likelihoodType: commonValueAndType[] = [];
  // impactType: commonValueAndType[] = [];
  // ratingType: commonValueAndType[] = [];
  // riskProfiles: riskProfile[] = [];
  //issueForm: FormGroup;
  issues: issue[] = [];

  searchForm: FormGroup;
  formService: FormService = new FormService();
  dataTableService: DatatableService = new DatatableService();
  dtTrigger: Subject<any> = new Subject<any>();
  //effectiveFrom: any;

  constructor(private http: HttpService , private fb: FormBuilder, private AlertService: AlertService, private router: Router) {
   // this.LoadDropDownValues();
    // this.issueForm = this.fb.group({
    //   id: [''],
    //   likelihoodTypeId:[null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
    //   impactTypeId: [null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
    //   ratingTypeId: [null,[Validators.required, Validators.pattern("^(?!null$).*$")]],
    //   description: [''],
    //   effectiveFrom: [Date,[Validators.required]],
    //   effectiveTo: [Date, [Validators.required]],
    //   isActive: []
    // }, { validator: this.customValidator.checkEffectiveDateToAfterFrom('effectiveFrom', 'effectiveTo') });
    this.searchForm = this.fb.group(
      {
        searchTerm: ['']
      }
    )
  }
  
  ngOnDestroy(): void {

  }
  ngOnInit(): void {
    this.loadData();
  }
  loadData() {
    const that = this;
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      serverSide: true,
      processing: true,
      searching: false,
      ordering:false,
      ajax: (dataTablesParameters: any, callback) => {
        this.http
          .paginatedPost(
            'issue/Paginated',dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1), this.searchForm.get('searchTerm')?.value
          ).subscribe(resp => that.issues = this.dataTableService.datatableMap(resp,callback));
      },
    };
  }
  reset():void {

  }
  search(){
    this.dataTableService.redraw(this.datatableElement);
  }

  edit(modalId:any, issue:any):void {
    const localmodalId = modalId;
    //console.log('hello');
    this.http
      .getById('issue', issue.id)
      .subscribe(res => {
          const issueResponse = res as issue;
         
          // this.riskProfileForm.setValue({id : riskProfileResponse.id, likelihoodTypeId : riskProfileResponse.likelihoodTypeId, 
          //   impactTypeId: riskProfileResponse.impactTypeId, ratingTypeId: riskProfileResponse.ratingTypeId, 
          //   effectiveFrom: formatDate(riskProfileResponse.effectiveFrom, 'yyyy-MM-dd', 'en'), effectiveTo: formatDate(riskProfileResponse.effectiveTo, 'yyyy-MM-dd', 'en'),
          //   description: riskProfileResponse.description, isActive: riskProfileResponse.isActive
          // });
      });
      localmodalId.visible = true;
      
  }

  delete(id:string){
    const that = this;
    this.AlertService.confirmDialog().then(res =>{
      if(res.isConfirmed){
          this.http.delete('issue/'+ id ,{}).subscribe(response=>{
          this.AlertService.successDialog('Deleted','Issue deleted successfully.');
          this.dataTableService.redraw(that.datatableElement);
        })
      }
    });
  }
  createNewIssue(){
    this.router.navigate(['branch-audit/new-issue']);
  }
}
