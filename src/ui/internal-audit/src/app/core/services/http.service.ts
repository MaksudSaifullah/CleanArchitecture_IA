import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import {Observable, pipe, throwError,isObservable, firstValueFrom} from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import {paginatedModelInterface} from './../interfaces/paginated.interface'

@Injectable({
  providedIn: 'root',
})



export class HttpService {
  hostName:string | undefined = environment.hostName;
  constructor(
    private httpClient: HttpClient
  ) {

  }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  filePostHttpOptions = {
    headers: new HttpHeaders({'enctype': 'multipart/form-data'})
  }


  paginatedPost<T>(endpoint:string,_pageSize:number,_pageNumber:number,_searchItem: any): Observable<T> {
    let requestObject : paginatedModelInterface = {
      pageNumber:_pageNumber,
      pagesize:_pageSize,
      searchTerm:_searchItem
    }
    return this.httpClient.post<T>(`${this.hostName}/${endpoint}`, JSON.stringify(requestObject), this.httpOptions)
      .pipe(
        retry(0),
        catchError(this.handleError)
      )
  }

  //#region [ Public ]
  get<T>(endpoint:string): Observable<T> {
    return this.httpClient
      .get<T>(`${this.hostName}/${endpoint}`)
      .pipe(
        retry(0),
        catchError(this.handleError)
      )
  }

  getById<T>(endpoint:string,id: string): Observable<T> {
    console.log("getByID", `${this.hostName}/${endpoint}/${id}`)
    return this.httpClient
      .get<T>(`${this.hostName}/${endpoint}/${id}`)
      .pipe(
        retry(0),
        catchError(this.handleError)
      )
  }

  post<T>(endpoint:string,item: any): Observable<T> {
    console.log(JSON.stringify(item));
    return this.httpClient.post<T>(`${this.hostName}/${endpoint}`, JSON.stringify(item), this.httpOptions)
      .pipe(
        retry(0),
        catchError(this.handleError)
      )
  }

  put<T>(endpoint:string,item: T,id:any): Observable<T> {
    return this.httpClient.put<T>(`${this.hostName}/${endpoint}`, JSON.stringify(item), this.httpOptions)
      .pipe(
        retry(0),
        catchError(this.handleError)
      )
  }

  delete<T>(endpoint:string,item: T) {
    return this.httpClient.delete<T>(`${this.hostName}/${endpoint}`, this.httpOptions)
      .pipe(
        retry(0),
        catchError(this.handleError)
      )
  }

  postFile(documentSourceId:string,documentSourceName: string, name:string, file :any,fileUploadUrl:any){
    // appending form data
    console.log(fileUploadUrl);
    let formData:FormData = new FormData();
    formData.append('documentSourceId',documentSourceId);
    formData.append('DocumentSourceName',documentSourceName);
    formData.append('Name',name);
    formData.append('file',file);
    // appending form data end
    return this.httpClient.post(`${`${this.hostName}/${fileUploadUrl}`}`, formData,this.filePostHttpOptions).pipe(retry(0),catchError(this.handleError));
  }



  getFilesAsBlob(endpoint:any): any  {
    
      return this.httpClient.get(`${this.hostName}/${endpoint}`, { responseType: 'blob',  observe: 'response'});
  }


  //#endregion

  //#region [ Private ]
  private handleError(error: HttpErrorResponse){
    let errorMessage = '';

    if(error.error instanceof ErrorEvent){
      //error client
      errorMessage = error.error.message;
    } else {
      //error server
      errorMessage = `Error: ${error.status}, ` + `Message: ${error.message}`;
    }

    return throwError(errorMessage);
  }
  //#endregion

}
