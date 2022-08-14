import { INavData } from '@coreui/angular-pro';

export const navItems: INavData[] = [
  {
    name: 'Dashboard',
    url: '/dashboard',
    iconComponent: { name: 'cil-speedometer' },
    badge: {
      color: 'info',
      text: ''
    },
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
        name: 'Audit Fequency',
        url: '/branch-audit/audit-frequency'
      },
      {
        name: 'Audit Creation',
        url: '/branch-audit/audit'
      },
      {
        name: 'Audit Schedule',
        url: '/branch-audit/audit-schedule'
      },
      {
        name: 'WorkPaper',
        url: '/branch-audit/workpaper'
      },
    ]
  },

];
