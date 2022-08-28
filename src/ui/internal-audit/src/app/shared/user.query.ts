import {filter} from "rxjs";
import {Query, toBoolean} from "@datorama/akita";
import {UserState, UserStore} from "./user.store";
import {Injectable} from "@angular/core";
@Injectable({ providedIn: 'root' })
export class UserQuery extends Query<UserState> {
  activeUser$ = this.select(x=>x);
  constructor(protected UserStore:UserStore) {
    super(UserStore);
  }

}
