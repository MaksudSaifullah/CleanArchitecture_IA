import { INavData } from '@coreui/angular-pro';

export const navItems: INavData[] = [
  {
    name: 'Dashboard',
    url: '/dashboard',
    iconComponent: { name: 'cil-speedometer' },
    badge: {
      color: 'info',
      text: ''
    }
  },
  
  {
    name: 'Public',
    url: '/public',
    iconComponent: { name: 'cil-puzzle' },
    children: [
      {
        name: 'about',
        url: '/public/about'
      }
    ]
  },
  {
    name: 'Pages',
    url: '/login',
    iconComponent: { name: 'cil-star' },
    children: [
      {
        name: 'Error 404',
        url: '/404'
      },
      {
        name: 'Error 500',
        url: '/500'
      }
    ]
  },
  {
    name: 'Public',
    url: '/about',
    iconComponent: { name: 'cilPaperPlane' },
    children: [
      {
        name: 'About',
        url: '/about'
      },
      {
        name: 'Login',
        url: '/login'
      },
    ]
  },
  {
    name: 'Configuration',
    url: '/configuration',
    iconComponent: { name: 'cilSettings' },
    children: [
      {
        name: 'Country',
        url: '/configuration/country',
      },
    ]
  },
];
