import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  
  data = {
    type: 'line',
    labels: ['Rare', 'Unlikely', 'Moderate', 'Likeley', 'Almost Certain'],
    datasets: [
      {
        label: 'Significant',
        backgroundColor: '#36A2EB',
        data: [40, 40 , 100 , 150, 230]
      },
      {
        label: 'Extreme',
        backgroundColor: '#ff0000',
        data: [50, 10, 200, 130, 50]
      },
      {
        label: 'High',
        backgroundColor: '#d97373',
        data: [150, 200, 50, 60, 90]
      },
      {
        label: 'Moderate',
        backgroundColor: '#067a23',
        data: [160, 240, 150, 90, 70]
      },
      {
        label: 'Low',
        backgroundColor: '#05ed3f',
        data: [200, 50, 200, 180, 100]
      }
    ],
    options: {
      plugins: {
          title: {
              display: true,
              text: 'Custom Chart Title'
          }
      }
  }
  };
  
  chartPieData = {
    labels: ['Reject & Close', 'Approved', 'Reject with Feedback','Send for Approval'],
    datasets: [
      {
        data: [150, 50, 100, 200],
        backgroundColor: ['#FF6384','#05ed3f', '#FFCE56', '#36A2EB'],
        hoverBackgroundColor: ['#FF6384','#05ed3f', '#FFCE56','#36A2EB']
      }
    ]
  };

}
