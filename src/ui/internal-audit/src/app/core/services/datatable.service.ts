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

  datatableMap<T>(resp:any, callback:any,count:any=0){
    console.log('resp for dt');
    console.log(resp);
    if(count === 0){
      console.log('onlyyyyyyyyy ami');
      let convertedResp = resp as paginatedResponseInterface<T>;
      console.log(convertedResp);
      callback({
        recordsTotal: convertedResp.totalCount,
        recordsFiltered: convertedResp.totalCount,
        data: []
      });
      return convertedResp.items;
    }else{
      let convertedResp = resp ;
      console.log('tmi ami');
      console.log(convertedResp);
      callback({
        recordsTotal: 0,
        recordsFiltered: 0,
        data: []
      });
      return convertedResp;
    }
   
  }
  
}
