import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DefaultLayoutComponent} from './containers';
import { Page404Component } from './views/pages/page404/page404.component';
import { Page500Component } from './views/pages/page500/page500.component';
import { LoginComponent } from './views/public/components/login/login.component';
import { AboutComponent } from './views/public/components/about/about.component';
import{ AuthGuard} from './core/guards/auth.guard'
import {ForgotPasswordComponent} from "./views/public/components/forgot-password/forgot-password.component";
import {ResetPasswordComponent} from "./views/public/components/reset-password/reset-password.component";
const routes: Routes = [
  {
    path: '',
    component: DefaultLayoutComponent,
    data: {
      title: 'Home'
    },
    canActivate:[AuthGuard],
    children: [
      // {
      //   path: 'dashboard',
      //   canActivate: [AuthGuard],
      //   loadChildren: () =>
      //     import('./views/dashboard/dashboard.module').then((m) => m.DashboardModule)
      // },
      {
        path: '',
        canActivate: [AuthGuard],
        loadChildren: () =>
          import('./views/private/private.module').then((m) => m.PrivateModule)
      },
      {
        path: 'pages',
        loadChildren: () =>
          import('./views/pages/pages.module').then((m) => m.PagesModule)
      },
      {
        path: 'public',
        loadChildren: () =>
          import('./views/public/public.module').then((m) => m.PublicModule)
      }
    ]
  },
  {
    path: '404',
    component: Page404Component,
    data: {
      title: 'Page 404'
    }
  },
  {
    path: '500',
    component: Page500Component,
    data: {
      title: 'Page 500'
    }
  },
  {
    path: 'login',
    component: LoginComponent,
    data: {
      title: 'Login Page'
    }
  },
  {
    path: 'about',
    component: AboutComponent,
    data: {
      title: 'About Page'
    }
  },
  {
    path: 'forgot-password',
    component: ForgotPasswordComponent,
    data: {
      title: 'Forgot Password'
    }
  },
  {
    path: 'reset-password/:code',
    component: ResetPasswordComponent,
    data: {
      title: 'Reset Password'
    }
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      scrollPositionRestoration: 'top',
      anchorScrolling: 'enabled',
      initialNavigation: 'enabledBlocking'
    })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
