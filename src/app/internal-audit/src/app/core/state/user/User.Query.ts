import { Injectable } from "@angular/core";
import { QueryEntity } from "@datorama/akita";
import { SessionStore, User } from "./User.Store";

@Injectable({
    providedIn: 'root'
  })

export class SessionQuery extends QueryEntity<User> {
    constructor(protected override store: SessionStore){
      super(store);
    }
  }