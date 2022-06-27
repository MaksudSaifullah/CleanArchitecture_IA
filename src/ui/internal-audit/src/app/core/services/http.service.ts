import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
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

  paginatedPost<T>(endpoint:string,_pageSize:number,_pageNumber:number,_searchItem: any): Observable<T> {
    let requestObject : paginatedModelInterface = {
      pageNumber:_pageNumber,
      pagesize:_pageSize,
      searchTerm:_searchItem
    }
    return this.httpClient.post<T>(`${this.hostName}/${endpoint}`, JSON.stringify(requestObject), this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  //#region [ Public ]
  get<T>(endpoint:string): Observable<T[]> {
    return this.httpClient
      .get<T[]>(`${this.hostName}/${endpoint}`)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  getById<T>(endpoint:string,id: string): Observable<T> {
    return this.httpClient
      .get<T>(`${this.hostName}/${endpoint}/${id}`)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  post<T>(endpoint:string,item: any): Observable<T> {
    return this.httpClient.post<T>(`${this.hostName}/${endpoint}`, JSON.stringify(item), this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  put<T>(endpoint:string,item: T,id:any): Observable<T> {
    return this.httpClient.put<T>(`${this.hostName}/${endpoint}`, JSON.stringify(item), this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  delete<T>(endpoint:string,item: T) {
    return this.httpClient.delete<T>(`${this.hostName}/${endpoint}`, this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
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
