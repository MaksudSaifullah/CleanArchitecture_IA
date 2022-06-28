import { Component, OnInit } from '@angular/core';
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
          .get(
            'api/v1/userlist/GetList'
          ).subscribe(resp => {
            that.compositeUsers = (resp as compositeUser[]);
            callback({
              recordsTotal: that.compositeUsers.length,
              recordsFiltered: that.compositeUsers.length,
              data: []
            });
          });
      },
    };

  }


}
