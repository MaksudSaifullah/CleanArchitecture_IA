import { Component, OnInit, QueryList, ViewChildren } from '@angular/core';
import { DataTableDirective } from 'angular-datatables';
import { country } from 'src/app/core/interfaces/configuration/country.interface';
import { UploadedDocumentList } from 'src/app/core/interfaces/uploaded-document.interface';
import { DatatableService } from 'src/app/core/services/datatable.service';
import { HelperService } from 'src/app/core/services/helper.service';
import { HttpService } from 'src/app/core/services/http.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  @ViewChildren(DataTableDirective)
  dtElements: QueryList<DataTableDirective> | undefined;
  dtOptions: DataTables.Settings[] = [];
  countries: country[] = [];
  documents: UploadedDocumentList[] = [];
  dataTableService: DatatableService = new DatatableService();
  
  constructor(private http: HttpService, private helper: HelperService ) { }

  ngOnDestroy(): void {

  }
  ngOnInit(): void {
    this.LoadDocument();

    };
    LoadDocument() {
      const that = this;
  
      this.dtOptions[0]= {
        pagingType: 'full_numbers',
        pageLength: 5,
        serverSide: true,
        processing: true,
        searching: false,
        lengthChange: false,
        ordering: false,
        info: false,
        ajax: (dataTablesParameters: any, callback) => {
          this.http
            .paginatedPost(
              'UploadDocumentPage/roleid', dataTablesParameters.length, ((dataTablesParameters.start / dataTablesParameters.length) + 1), { "roleid": 'dd0f5c2e-2d1f-ed11-b3b2-00155d610b18' }
            ).subscribe(resp => that.documents = this.dataTableService.datatableMap(resp, callback));
        },
      };
  
    }

    LoadAudit() {
      const that = this;
  
      this.dtOptions[1]= {
        pagingType: 'full_numbers',
        pageLength: 5,
        serverSide: true,
        processing: true,
        searching: false,
        lengthChange: false,
        ordering: false,
        info: false,
        ajax: (dataTablesParameters: any, callback) => {
          this.http
            .paginatedPost(
              'UploadDocumentPage/roleid', dataTablesParameters.length, ((dataTablesParameters.start / dataTablesParameters.length) + 1), { "roleid": 'dd0f5c2e-2d1f-ed11-b3b2-00155d610b18' }
            ).subscribe(resp => that.documents = this.dataTableService.datatableMap(resp, callback));
        },
      };
  
    }

  fileDownLoad(d: any) {
    console.log(d);
    this.http.getFilesAsBlob('Document/get-file-stream?Id=' + d,
    )
      .subscribe((resp: any) => {
        let fileName = resp.headers.get('content-disposition');
        console.log(fileName);
        this.helper.downloadFile(resp);
      }), (error: any) => console.log('Error downloading the file'),
      () => console.info('File downloaded successfully');
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
    ],
  
   
  };

  chartPieOptions = {
    responsive: false,
    aspectRatio: 0.5
  };


}
