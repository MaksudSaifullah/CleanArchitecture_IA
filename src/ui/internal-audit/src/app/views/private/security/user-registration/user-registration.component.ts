import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
  styleUrls: ['./user-registration.component.scss']
})
export class UserRegistrationComponent implements OnInit {
  countryList:any[]=[1,2,3,4,5];
  constructor() { }

  ngOnInit(): void {
  }

}
