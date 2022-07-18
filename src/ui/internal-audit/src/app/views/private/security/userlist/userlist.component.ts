import { Component, OnInit, ViewChild } from '@angular/core';
import { paginatedModelInterface, paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { HttpService } from 'src/app/core/services/http.service';
import {compositeUser} from '../../../../core/interfaces/configuration/compositeUser.interface'
import { role } from '../../../../core/interfaces/security/role.interface';
import {AlertService} from '../../../../core/services/alert.service';
import { DataTableDirective } from 'angular-datatables';
import { DatatableService } from 'src/app/core/services/datatable.service';
import {ActivatedRoute, Router } from '@angular/router';


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

  constructor(private http: HttpService , private activateRoute:ActivatedRoute, private AlertService: AlertService,private router: Router) { }

  ngOnInit(): void {
    let paramId = this.activateRoute.snapshot.params['id'];

    if(paramId === 'inserted'){
      this.AlertService.successDialog('Added','User Added successfully.');
    }
    else if(paramId === 'updated'){
      this.AlertService.successDialog('Update','User Updated successfully.');
    }

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
          ).subscribe(resp => that.compositeUsers = this.dataTableService.datatableMap(resp,callback));
      },

      

    };

  }

  LoadRole() {
    this.http.paginatedPost('role/paginated', 100, 1, {}).subscribe(resp => {
      let convertedResp = resp as paginatedResponseInterface<role>;
      this.roles = convertedResp.items;
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
    this.router.navigate(['security/userRegistration'], {queryParams: {id: id}});
  }

  

}
