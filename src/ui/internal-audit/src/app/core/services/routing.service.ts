
import { Location } from '@angular/common';
import { Injectable } from '@angular/core';
import { Router, ActivatedRoute} from '@angular/router';
@Injectable({providedIn: 'root'})
@Injectable({providedIn: 'root'})
export class RoutingService {
  constructor(private route: ActivatedRoute,private router: Router,private location:Location) { }

  navigate(url:string){
    this.router.navigateByUrl(url);
  }

  back(){
    this.location.back();
  }
}
