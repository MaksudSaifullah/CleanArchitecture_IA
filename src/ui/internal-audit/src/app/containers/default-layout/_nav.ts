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
  
  // {
  //   name: 'Public',
  //   url: '/public',
  //   iconComponent: { name: 'cil-puzzle' },
  //   children: [
  //     {
  //       name: 'about',
  //       url: '/public/about'
  //     }
  //   ]
  // },
  // {
  //   name: 'Pages',
  //   url: '/login',
  //   iconComponent: { name: 'cil-star' },
  //   children: [
  //     {
  //       name: 'Error 404',
  //       url: '/404'
  //     },
  //     {
  //       name: 'Error 500',
  //       url: '/500'
  //     }
  //   ]
  // },
  // {
  //   name: 'Public',
  //   url: '/about',
  //   iconComponent: { name: 'cilPaperPlane' },
  //   children: [
  //     {
  //       name: 'About',
  //       url: '/about'
  //     },
  //     {
  //       name: 'Login',
  //       url: '/login'
  //     },
  //   ]
  // },
  {
    name: 'Configuration',
    url: '/configuration',
    iconComponent: { name: 'cilSettings' },
    children: [
      {
        name: 'Country',
        url: '/configuration/country',
      },
      {
        name: 'Risk Profile',
        url: '/configuration/risk-profile',
      },
      {
        name: 'Email Config',
        url: '/configuration/emailConfig',
      },
    ]
  },
  {
    name: 'Security',
    url: '/security',
    iconComponent: { name: 'cilMenu' },
    children: [
      {
        name: 'User Registration',
        url: '/security/userRegistration',
      },
      {
        name: 'User List',
        url: '/security/userlist',
      },
      {
        name: 'Role',
        url: '/security/userrole',
      },
      {
        name: 'Access Privilege Config',
        url: '/security/access-privilege',
      },
      {
        name: 'Designation',
        url: '/security/designation',
      },
      
    ]
  },
  {
    name: 'Branch Audit',
    url: '/branch-audit',
    iconComponent: { name: 'cil-puzzle' },
    children: [
      {
        name: 'Topic Head',
        url: '/branch-audit/topichead'
      },
      // {
      //   name: 'Risk Criteria',
      //   url: '/branch-audit/risk-criteria'
      // },
      {
        name: 'Risk Criteria',
        url: '/branch-audit/risk-criteria'
      },
      {
        name: 'Risk Assessment',
        url: '/branch-audit/risk-assessment'
      },
      {
        name: 'Risk Assessment View',
        url: '/branch-audit/risk-assessment-view'
      },
      {
        name: 'Audit Fequency',
        url: '/branch-audit/audit-frequency'
      },
      {
        name: 'Audit Creation',
        url: '/branch-audit/audit'
      }
    ]
  },
  
];
