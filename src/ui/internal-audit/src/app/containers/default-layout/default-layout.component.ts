import { Component, OnInit } from '@angular/core';
import { NavigationCancel, NavigationEnd, NavigationError, NavigationStart, Router } from '@angular/router';
import { filter } from 'rxjs';

import { navItems } from './_nav';

@Component({
  selector: 'app-dashboard',
  templateUrl: './default-layout.component.html',
})
export class DefaultLayoutComponent implements OnInit {

  public navItems = navItems;

  public perfectScrollbarConfig = {
    suppressScrollX: true,
  };

  constructor(private router: Router) {
  }
  ngOnInit(): void {
    // this.router.events.pipe(
    //   filter(
    //     (e) =>
    //       e instanceof NavigationStart ||
    //       e instanceof NavigationEnd ||
    //       e instanceof NavigationCancel ||
    //       e instanceof NavigationError
    //   )
    // )
    // // ONLY runs on:
    // // NavigationStart, NavigationEnd, NavigationCancel, NavigationError
    // .subscribe(e=> {
    //   debugger
    //   if(typeof(e) == typeof(NavigationStart))
    //     console.log('navigation started')
    // });
  }
}
