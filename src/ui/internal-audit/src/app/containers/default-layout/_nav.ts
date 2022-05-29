import { INavData } from '@coreui/angular';

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
    name: 'Configuration',
    title: true
  },
  {
    name: 'Common',
    url: '/common',
    iconComponent: { name: 'cil-puzzle' },
    children: [
      {
        name: 'Country',
        url: '/configuration/country',
      },
      {
        name: 'Ishita',
        url: '/configuration/ishita',
      },
    ]
  },
];
