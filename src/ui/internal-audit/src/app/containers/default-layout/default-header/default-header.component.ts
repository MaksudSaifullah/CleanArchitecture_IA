import { Component, Input } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

import { ClassToggleService, HeaderComponent } from '@coreui/angular-pro';
import { RoutingService } from 'src/app/core/services/routing.service';

@Component({
  selector: 'app-default-header',
  templateUrl: './default-header.component.html',
})
export class DefaultHeaderComponent extends HeaderComponent {

  @Input() sidebarId: string = "sidebar1";

  public newMessages = new Array(4)
  public newTasks = new Array(5)
  public newNotifications = new Array(5)

  public themeSwitch = new FormGroup({
    themeSwitchRadio: new FormControl('light'),
  });

  constructor(private classToggler: ClassToggleService,private route : RoutingService) {
    super();
  }

  setTheme(value: string): void {
    this.themeSwitch.setValue({ themeSwitchRadio: value });
    this.classToggler.toggle('body', 'dark-theme');
  }
  logout(){
    localStorage.removeItem('authenticatedUser');
    this.route.navigate('/login');

  }
}
