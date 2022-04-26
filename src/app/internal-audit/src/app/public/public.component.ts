import { Component, OnInit } from '@angular/core';
import { RouterQuery } from '@datorama/akita-ng-router-store';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-public',
  templateUrl: './public.component.html',
  styleUrls: ['./public.component.css']
})
export class PublicComponent implements OnInit {
name= 'IA';
routerQueryParams$: Observable<any> | undefined;
constructor(
  private routerQuery: RouterQuery
) {}

public ngOnInit() {
  this.routerQueryParams$ = this.routerQuery.selectParams();
}
}
