import { Component, Input } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

import { ClassToggleService, HeaderComponent } from '@coreui/angular-pro';
import { RoutingService } from 'src/app/core/services/routing.service';
import {BreadcumbQuery} from "../../../shared/breadcumb.query";
import {BehaviorSubject, Observable} from "rxjs";
import {BreadcumbModel, BreadCumbState, BreadcumbStore} from "../../../shared/breedcumb.store";
import {UserState} from "../../../shared/user.store";
import {UserQuery} from "../../../shared/user.query";

@Component({
  selector: 'app-default-header',
  templateUrl: './default-header.component.html',
})
export class DefaultHeaderComponent extends HeaderComponent {
  public breadcumb$: Observable<BreadcumbModel[]>;
  public user$: Observable<UserState>;
  @Input() sidebarId: string = "sidebar1";

  public newMessages = new Array(4)
  public newTasks = new Array(5)
  public newNotifications = new Array(5)

  public themeSwitch = new FormGroup({
    themeSwitchRadio: new FormControl('light'),
  });

  constructor(private userQuery: UserQuery,private classToggler: ClassToggleService,private route : RoutingService, private breadcumbQuery : BreadcumbQuery, private breedcumbStore:BreadcumbStore) {
    super();
    this.breadcumb$ = breadcumbQuery.activeBreadcumb$;
    this.user$ = userQuery.activeUser$;
  }

  setTheme(value: string): void {
    this.themeSwitch.setValue({ themeSwitchRadio: value });
    this.classToggler.toggle('body', 'dark-theme');
  }
  logout(){
    localStorage.removeItem('authenticatedUser');
    this.route.navigate('/login');

  }

  setState(text: string) {
    this.breedcumbStore.update({
      breadcumbModel: [{
        displayName:text,
        routerLink:''
      }]
    })
  }
}
