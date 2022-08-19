import { Injectable } from '@angular/core';
import { HttpService } from 'src/app/core/services/http.service';
import { DocumentSource } from '../interfaces/uploaded-document.interface';
@Injectable({
    providedIn: 'root',
  })
export class HelperService {
  
  constructor(private http:HttpService){

  }
    downloadFile(response:any) {
        console.log('sdfhashdosahdoisaod');
        console.log(response.headers);
        let header_content = response.headers.get('content-disposition');

        console.log('skjjkshj');
        console.log( header_content?.split(';')[1].split('=')[1]);
      

        let navigatorVariable: any = window.navigator;
        let file = header_content?.split(';')[1].split('=')[1];      
        let extension = file?.split('.')[1].toLowerCase();
        // It is necessary to create a new blob object with mime-type explicitly set
        // otherwise only Chrome works like it should
        var newBlob = new Blob([response.body], { type: this.createFileType(extension) })
    
        // IE doesn't allow using a blob object directly as link href
        // instead it is necessary to use msSaveOrOpenBlob
        if (window.navigator && navigatorVariable.msSaveOrOpenBlob) {
            navigatorVariable.msSaveOrOpenBlob(newBlob);
          return;
        }
    
        // For other browsers: 
        // Create a link pointing to the ObjectURL containing the blob.
        const data = window.URL.createObjectURL(newBlob);
        var link = document.createElement('a');
        link.href = data;
        link.download = file;
        link.click();
        setTimeout(() => {
          // For Firefox it is necessary to delay revoking the ObjectURL
          window.URL.revokeObjectURL(data);
        }, 400)
      }
    
      createFileType(e:any) {
        let fileType: string = "";
        if (e.includes( 'pdf') || e.includes( 'csv')) {
          fileType = `application/${e}`;
        }
        else if (e.includes( 'jpeg') || e.includes( 'jpg') || e.includes( 'png')) {
          fileType = `image/${e}`;
        }
        else if (e.includes( 'txt') ){
          fileType = 'text/plain';
        }
    
        else if (e.includes('ppt') || e.includes( 'pot') || e.includes( 'pps') || e.includes( 'ppa')) {
          fileType = 'application/vnd.ms-powerpoint';
        }
        else if (e.includes( 'pptx')) {
          fileType = 'application/vnd.openxmlformats-officedocument.presentationml.presentation';
        }
        else if (e.includes( 'doc') || e.includes( 'dot')) {
          fileType = 'application/msword';
        }
        else if (e.includes( 'docx')) {
          fileType = 'application/vnd.openxmlformats-officedocument.wordprocessingml.document';
        }
        else if (e.includes( 'xls') || e.includes( 'xlt') || e.includes( 'xla')) {
          fileType = 'application/vnd.ms-excel';
        }
        else if (e.includes( 'xlsx')) {
          fileType = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet';
        }
    
        return fileType;
      }

      getDocumentSource(type:any):any{
      this.http.get('DocumentSource').subscribe(resp => {
        let result = resp as DocumentSource[];
        console.log(result);
        let filteredData=  result.find((obj) => {
          return obj.name?.toLowerCase() === type.toLowerCase();
        });
        console.log(filteredData);
      return filteredData;
      })
      // let x:DocumentSource={id:'0',name:''}
      // return x;
      }
}

