import {filter} from "rxjs";
import {Query, toBoolean} from "@datorama/akita";
import {BreadCumbState, BreadcumbStore} from "./breedcumb.store";
import {Injectable} from "@angular/core";
@Injectable({ providedIn: 'root' })
export class BreadcumbQuery extends Query<BreadCumbState> {
  activeBreadcumb$ = this.select(x=>x.breadcumbModel);
  constructor(protected breadcumbStore:BreadcumbStore) {
    super(breadcumbStore);
  }

}
