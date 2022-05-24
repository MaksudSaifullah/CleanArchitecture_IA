import { INavData } from '@coreui/angular';

export const navItems: INavData[] = [
  {
    name: 'Home',
    url: '/dashboard',
    iconComponent: { name: 'cil-speedometer' },
    badge: {
      color: 'info',
      text: ''
    }
  },
  {
    name: 'Product',
    url: '/',
    iconComponent: { name: 'cil-puzzle' },
    children: [
      {
        name: 'Loan Officers',
        url: '/base/accordion',
        iconComponent: { name: 'cil-pencil' },
      },
      {
        name: 'Master Roll',
        url: '/base/breadcrumbs',
        iconComponent: { name: 'cil-pencil' },
      },
      {
        name: 'Monthly Report',
        url: '/base/breadcrumbs',
        iconComponent: { name: 'cil-pencil' },
      },
      {
        name: 'Daily Overdue Report',
        url: '/base/breadcrumbs',
        iconComponent: { name: 'cil-pencil' },
      },
      {
        name: 'Program Type',
        url: '/base/breadcrumbs',
        iconComponent: { name: 'cil-pencil' },
        children:[{
            name: 'Program',
            url: '/base/accordion',
        }]
      },
      {
        name: 'Program Group',
        url: '/base/breadcrumbs',
        iconComponent: { name: 'cil-pencil' },
      },
      {
        name: 'Grace Period',
        url: '/base/breadcrumbs',
        iconComponent: { name: 'cil-pencil' },
      }
    ]
  },
  {
    name: 'Banking',
    url: '/',
    iconComponent: { name: 'cil-notes' },
    children: [
      {
        name: 'Customer',
        url: '/base/accordion',
      },
      {
        name: 'Account',
        url: '/base/breadcrumbs'
      },
      {
        name: 'Banking Report',
        url: '/base/breadcrumbs'
      },
      {
        name: 'View Statement',
        url: '/base/breadcrumbs'
      }
    ]
  },
  {
    name: 'Accounts',
    url: '/',
    iconComponent: { name: 'cil-chart-pie' },
    children: [
      {
        name: 'Chart Of Account',
        url: '/base/accordion',
      },
      {
        name: 'Currency Rate',
        url: '/base/breadcrumbs'
      },
      {
        name: 'Accounts Report',
        url: '/base/breadcrumbs'
      },
      {
        name: 'Trial Balance Report',
        url: '/base/breadcrumbs'
      }
    ]
  },
  {
    name: 'Monitoring',
    url: '/',
    iconComponent: { name: 'cil-bell' },
    // children: [
    //   {
    //     name: 'Chart Of Account',
    //     url: '/base/accordion',
    //   },
    //   {
    //     name: 'Currency Rate',
    //     url: '/base/breadcrumbs'
    //   },
    //   {
    //     name: 'Accounts Report',
    //     url: '/base/breadcrumbs'
    //   },
    //   {
    //     name: 'Trial Balance Report',
    //     url: '/base/breadcrumbs'
    //   }
    // ]
  },
  {
    name: 'Location',
    url: '/',
    iconComponent: { name: 'cil-drop' },
    children: [
      {
        name: 'State',
        url: '/base/accordion',
      },
      {
        name: 'Config',
        url: '/base/breadcrumbs'
      },
      {
        name: 'Scheme',
        url: '/base/breadcrumbs'
      },
      {
        name: 'District',
        url: '/base/breadcrumbs'
      },
      {
        name: 'Group Type',
        url: '/base/breadcrumbs'
      },
      {
        name: 'Zone',
        url: '/base/breadcrumbs'
      },
      {
        name: 'Region',
        url: '/base/breadcrumbs'
      },
      {
        name: 'Branch',
        url: '/base/breadcrumbs'
      },
      {
        name: 'Program Group Duration',
        url: '/base/breadcrumbs'
      },
      {
        name: 'Region',
        url: '/base/breadcrumbs'
      }
      
    ]
  },
  {
    name: 'Configuration',
    url: '/',
    iconComponent: { name: 'cil-puzzle' },
    children: [
      {
        name: 'Working Day',
        url: '/base/accordion',
      },
      {
        name: 'Calendar',
        url: '/base/breadcrumbs'
      },
      {
        name: 'Calendar Guide',
        url: '/base/breadcrumbs'
      },
      {
        name: 'District',
        url: '/base/breadcrumbs'
      },
      {
        name: 'Group Type',
        url: '/base/breadcrumbs'
      }
    ]
  },
];
