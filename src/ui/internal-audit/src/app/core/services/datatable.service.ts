import { Injectable } from '@angular/core';
import { DataTableDirective } from 'angular-datatables';
import { paginatedResponseInterface } from '../interfaces/paginated.interface';

@Injectable({providedIn: 'root'})
export class DatatableService {
  redraw(datatable : DataTableDirective | undefined){
    datatable?.dtInstance.then((dtInstance: DataTables.Api) => {
      dtInstance.draw();
    });
  }

  datatableMap<T>(resp:any, callback:any){
    let convertedResp = resp as paginatedResponseInterface<T>;
    console.log(convertedResp);
    callback({
      recordsTotal: convertedResp.totalCount,
      recordsFiltered: convertedResp.totalCount,
      data: []
    });
    return convertedResp.items;
  }
}
