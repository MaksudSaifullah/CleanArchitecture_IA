import {AfterViewInit, Component, ElementRef, OnInit, Renderer2} from '@angular/core';
import { NavigationCancel, NavigationEnd, NavigationError, NavigationStart, Router } from '@angular/router';
import { filter } from 'rxjs';

import { navItems } from './_nav';
import {BreadcumbStore} from "../../shared/breedcumb.store";
@Component({
  selector: 'app-dashboard',
  templateUrl: './default-layout.component.html',
})
export class DefaultLayoutComponent implements OnInit,AfterViewInit {

  public navItems = navItems;
  public nativeElement:HTMLElement | undefined;
  public perfectScrollbarConfig = {
    suppressScrollX: true,
  };

  constructor(private router: Router,private renderer: Renderer2,private elementRef: ElementRef, private breadcumbStore : BreadcumbStore) {

  }
  navItemClick(event:any){
    alert('working');
  }
  ngOnInit(): void {

  }

  ngAfterViewInit(): void {
    this.nativeElement = document.getElementById('sidebar1') as HTMLElement;
    let item = this.nativeElement?.getElementsByTagName('c-sidebar-nav-link') as HTMLCollectionOf<Element>;
    for(let i = 0; i < item.length;i++){
      var element = item[i] as HTMLElement;
      item[i].addEventListener('click',(x)=>{
        debugger;
        let childNodeText = item[i].textContent;
        var childNodeUrl = item[i].getElementsByTagName('a')[0].href.split('#')[1];
        let parentNodeText = item[i].parentElement?.parentElement?.firstChild?.textContent ?? '';
        this.breadcumbStore.update({
          breadcumbModel:[{
            displayName:parentNodeText,
            routerLink: '#'
          },{
            displayName:childNodeText ?? '',
            routerLink: childNodeUrl
          }]
        });
      });
    }
    var currentBreadCumbValue = this.breadcumbStore.getValue();
    if(currentBreadCumbValue.breadcumbModel.length == 0){
      let hash = location.hash.replace('#', '').split('/');
      let parent = navItems.filter(x=>x.name?.toLowerCase() == hash[1])[0];
      let child = parent.children?.filter(x=>x.url?.toString().toLowerCase() == location.hash.toLowerCase().replace('#', ''))[0];
      this.breadcumbStore.update({
        breadcumbModel:[{
          displayName:parent.name??'',
          routerLink:"#"
        },
          {
            displayName:child?.name??'',
            routerLink:"#"
          }]
      });
    }
  }
}
