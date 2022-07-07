import { Component, OnInit } from '@angular/core';
import { country } from 'src/app/core/interfaces/configuration/country.interface';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { HttpService } from 'src/app/core/services/http.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  dtOptions: DataTables.Settings = {};
  countries: country[] = [];
  dataTableService: DatatableService = new DatatableService();
  constructor(private http: HttpService ) { }

  ngOnInit(): void {
    this.LoadData();
    };
  LoadData() {
    const that = this;

    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 5,
      serverSide: true,
      processing: true,
      searching: false,
      lengthChange: false,
      info: false,
      ajax: (dataTablesParameters: any, callback) => {
        this.http
          .paginatedPost(
            'country/paginated',dataTablesParameters.length,((dataTablesParameters.start/dataTablesParameters.length)+1),{}
          ).subscribe(resp => that.countries = this.dataTableService.datatableMap(resp,callback));
      },
    };

  }
  
  data = {
    type: 'line',
    labels: ['Rare', 'Unlikely', 'Moderate', 'Likeley', 'Almost Certain'],
    datasets: [
      {
        label: 'Significant',
        backgroundColor: '#36A2EB',
        data: [40, 40 , 100 , 150, 230]
      },
      {
        label: 'Extreme',
        backgroundColor: '#ff0000',
        data: [50, 10, 200, 130, 50]
      },
      {
        label: 'High',
        backgroundColor: '#d97373',
        data: [150, 200, 50, 60, 90]
      },
      {
        label: 'Moderate',
        backgroundColor: '#067a23',
        data: [160, 240, 150, 90, 70]
      },
      {
        label: 'Low',
        backgroundColor: '#05ed3f',
        data: [200, 50, 200, 180, 100]
      }
    ],
    options: {
      plugins: {
          title: {
              display: true,
              text: 'Custom Chart Title'
          }
      }
  }
  };
  
  chartPieData = {
    labels: ['Reject & Close', 'Approved', 'Reject with Feedback','Send for Approval'],
    datasets: [
      {
        data: [150, 50, 100, 200],
        backgroundColor: ['#FF6384','#05ed3f', '#FFCE56', '#36A2EB'],
        hoverBackgroundColor: ['#FF6384','#05ed3f', '#FFCE56','#36A2EB']
      }
    ]
  };


}
