import { Component } from '@angular/core';
import { SessionQuery } from './core/state/user/User.Query';
import { SessionStore, User } from './core/state/user/User.Store';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'internal-audit';

  constructor(protected store: SessionStore, query: SessionQuery) {

    // Create a data
    const user : User[] =[
    {
      id : 1,
      token : '!%$%^#W$AKS12458245@#',
      name : 'ANIK'
    },
    {
      id : 2,
      token : '!%$%^#W$AKS12458245@#',
      name : 'SAHA'
    }
  ]

    store.upsert(user[1].id,user);
    query.getAll();

    console.log('GETALL',  query.getAll());


  }

}
