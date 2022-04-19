import { Injectable } from '@angular/core';
import { EntityStore, Store, StoreConfig } from '@datorama/akita';

export interface User {
   token: string;
   name: string;
   id: number;
}

@Injectable({
  providedIn: 'root'
})

@StoreConfig({ name: 'session', idKey: 'id' })
export class SessionStore extends EntityStore<User> {
  constructor() {
    super() ;
  }
}