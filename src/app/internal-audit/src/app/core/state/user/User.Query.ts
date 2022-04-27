import { Injectable } from "@angular/core";
import { QueryEntity } from "@datorama/akita";
import { RouterQuery } from "@datorama/akita-ng-router-store";
import { switchMap } from "rxjs";
import { SessionStore, User } from "./User.Store";

@Injectable({
    providedIn: 'root'
  })

export class SessionQuery extends QueryEntity<User> {
//   selectArticle$ = this.routerQuery.selectParams('id').pipe(
//     switchMap(id => this.selectEntity(id))
//  );
    constructor(protected override store: SessionStore, private routerQuery: RouterQuery){
      super(store);
    }
  }