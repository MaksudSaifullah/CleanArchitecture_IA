import { Component, OnInit, ViewChild } from '@angular/core';
import { paginatedModelInterface, paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { HttpService } from 'src/app/core/services/http.service';
import {compositeUser} from '../../../core/interfaces/configuration/compositeUser.interface'
import { role } from '../../../../app/core/interfaces/security/role.interface';
import {AlertService} from '../../../../app/core/services/alert.service';
import { DataTableDirective } from 'angular-datatables';
import { DatatableService } from 'src/app/core/services/datatable.service';
import {PrivateRoutingModule} from '../private-routing.module'
import { Router } from '@angular/router';


@Component({
  selector: 'app-userlist',
  templateUrl: './userlist.component.html',
  styleUrls: ['./userlist.component.scss']
})
export class UserlistComponent implements OnInit {
  dtOptions: DataTables.Settings = {};
  compositeUsers: compositeUser [] = [];
  roles: role [] = [];
  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective | undefined;
  dataTableService: DatatableService = new DatatableService();
  
  userName: string= "";
  employeeName:string= "";
  userRole:string ="";

  constructor(private http: HttpService ,private AlertService: AlertService,private router: Router) { }

  ngOnInit(): void {
    this.LoadRole()
    this.LoadData();
  }

  search(){
    this.dataTableService.redraw(this.datatableElement);
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
            'userlist/Paginated',dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1),{"userName": this.userName,"employeeName": this.employeeName,"userRole": this.userRole}
          ).subscribe(resp => {
            var convertedResponse = resp as paginatedResponseInterface<compositeUser>;
            that.compositeUsers = convertedResponse.items;
            callback({
              recordsTotal: convertedResponse.totalCount,
              recordsFiltered: convertedResponse.totalCount,
              data: []
            });
          });
      },
    };

  }

  LoadRole() {
    this.http.get('role/all').subscribe(resp => {
      this.roles = (resp as role[]);
      console.log(this.roles);
    })
  }

  lockUser(id:string){
    const that = this;
    this.AlertService.confirmDialog().then(res =>{
      if(res.isConfirmed){
          this.http.post('userlist/LockUser' ,{"id":id,"IsAccountLocked":true}).subscribe(response=>{
          this.AlertService.successDialog('Locked','Account Locked successfully.');

          this.dataTableService.redraw(this.datatableElement);
        })
      }
    });
  }

  edit(id:string){
    this.router.navigateByUrl('/user-registration')
   
    // this.http.delete('Id/'+ id ,{}).subscribe(response=>{
    //   this.AlertService.successDialog('Deleted','Country deleted successfully.');

    // })
  }



}
