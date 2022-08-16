import { Store, StoreConfig } from '@datorama/akita';
import {Injectable} from "@angular/core";

export interface BreadCumbState {
  breadcumbModel: BreadcumbModel[]
}
export interface BreadcumbModel{
  displayName: string;
  routerLink: string;
}
export function createInitialState(): BreadCumbState {
  return {breadcumbModel:[]};
}

@StoreConfig({ name: 'breadcumb', resettable:true })
@Injectable({ providedIn: 'root' })
export class BreadcumbStore extends Store<BreadCumbState> {
  constructor() {
    super(createInitialState());
  }

  addMore(breadcumbModel : BreadcumbModel){
    var value = this.getValue();
    value.breadcumbModel.push(breadcumbModel);
  }


}
