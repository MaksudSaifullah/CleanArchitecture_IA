import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  constructor() { }

  saveToken(token: string){
    localStorage.setItem('$ia-token', token);
  }

  getToken(){
    return localStorage.getItem('$ia-token');
  }

  removeToken(){
    localStorage.removeItem('$ia-token');
  }

  setItem(key: string, value: any){

  }

  getItem(key: string){
    
  }
}
