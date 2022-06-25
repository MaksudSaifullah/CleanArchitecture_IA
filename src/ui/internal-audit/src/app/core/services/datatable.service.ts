import { Injectable } from '@angular/core';
import { DataTableDirective } from 'angular-datatables';

@Injectable({providedIn: 'root'})
export class DatatableService {
  redraw(datatable : DataTableDirective | undefined){
    datatable?.dtInstance.then((dtInstance: DataTables.Api) => {
      dtInstance.draw();
    });
  }
}
