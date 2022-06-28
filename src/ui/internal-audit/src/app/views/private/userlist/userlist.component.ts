import { Component, OnInit } from '@angular/core';
import { paginatedModelInterface, paginatedResponseInterface } from 'src/app/core/interfaces/paginated.interface';
import { HttpService } from 'src/app/core/services/http.service';
import {compositeUser} from '../../../core/interfaces/configuration/compositeUser.interface'

@Component({
  selector: 'app-userlist',
  templateUrl: './userlist.component.html',
  styleUrls: ['./userlist.component.scss']
})
export class UserlistComponent implements OnInit {
  dtOptions: DataTables.Settings = {};
  compositeUsers: compositeUser [] = [];

  userName: string= "";
  employeeName:string= "";
  userRole:string ="";

  constructor(private http: HttpService ) { }

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


}
