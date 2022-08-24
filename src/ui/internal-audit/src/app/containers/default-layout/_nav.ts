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
        name: 'Email Configuration',
        url: '/configuration/emailConfig',
      },
      {
        name: 'Risk Profile',
        url: '/configuration/risk-profile',
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
        name: 'User Role',
        url: '/security/userrole',
      },
      {
        name: 'Designation',
        url: '/security/designation',
      },
      {
        name: 'Access Privilege Config',
        url: '/security/access-privilege',
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
        name: 'Audit View',
        url: '/branch-audit/audit-view'
      },
      {
        name: 'Audit Schedule',
        url: '/branch-audit/audit-schedule'
      },
      {
        name: 'Work Paper Create',
        url: '/branch-audit/workpaperCreate'
      },
      {
        name: 'Work Paper',
        url: '/branch-audit/workpaper'
      },
      {
        name: 'Issue',
        url: '/branch-audit/issue-list'
      },
    ]
  },
  {
    name: 'Upload Document',
    url: '/upload-document',
    iconComponent: { name: 'cil-arrow-circle-top' },
    badge: {
      color: 'info',
      text: ''
    },
  },

];
