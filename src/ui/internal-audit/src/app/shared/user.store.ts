import { Store, StoreConfig } from '@datorama/akita';

export interface UserState {
  profileImage: string;
  fullName: string;
}

export function createInitialState(): UserState {
  return {
    profileImage:'',
    fullName : ''
  }
}

@StoreConfig({ name: 'user' })
export class SessionStore extends Store<UserState> {
  constructor() {
    super(createInitialState());
  }
}
