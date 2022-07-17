import { Injectable } from '@angular/core';
import { DataTableDirective } from 'angular-datatables';
import { paginatedResponseInterface } from '../interfaces/paginated.interface';

@Injectable({ providedIn: 'root' })
export class DatatableService {
  redraw(datatable: DataTableDirective | undefined) {
    datatable?.dtInstance.then((dtInstance: DataTables.Api) => {
      dtInstance.draw();
    });
  }

  datatableMap<T>(resp: any, callback: any, type: any = 'sp') {
    if (type === 'sp') {

      let convertedResp = resp as paginatedResponseInterface<T>;
      console.log(convertedResp);
      callback({
        recordsTotal: convertedResp.totalCount,
        recordsFiltered: convertedResp.totalCount,
        data: []
      });
      return convertedResp.items;
    } else {
      let convertedResp = resp;
      callback({
        recordsTotal: convertedResp.length == 0 ? 0 : convertedResp[0].totalCount.tc,
        recordsFiltered: convertedResp.length == 0 ? 0 : convertedResp[0].totalCount.tc,
        data: []
      });
      return convertedResp;
    }

  }

}
