import { Injectable } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
@Injectable({providedIn: 'root'})
export class RoutingService {
  constructor(private route: ActivatedRoute,private router: Router) { }

  navigate(url:string){
    this.router.navigateByUrl(url);
  }

}
