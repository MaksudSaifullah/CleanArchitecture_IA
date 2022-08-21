import { Store, StoreConfig } from '@datorama/akita';
import {Injectable} from "@angular/core";

export interface UserState {
  profileImage: string;
  fullName: string;
  designation:string
}

export function createInitialState(): UserState {
  return {
    profileImage:'',
    fullName : '',
    designation:''
  }
}

@StoreConfig({ name: 'user' })
@Injectable({ providedIn: 'root' })
export class UserStore extends Store<UserState> {
  constructor() {
    super(createInitialState());
  }
}
