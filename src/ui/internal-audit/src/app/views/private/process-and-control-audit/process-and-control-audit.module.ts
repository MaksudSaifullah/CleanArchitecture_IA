import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccordionModule, ButtonModule, CardModule, FormModule, GridModule, ModalModule, MultiSelectModule, NavModule, TabsModule } from '@coreui/angular-pro';
import { IconModule } from '@coreui/icons-angular';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DataTablesModule } from 'angular-datatables';
import { HttpClientModule } from '@angular/common/http';
import { CdkAccordionModule } from '@angular/cdk/accordion';
import { ProcessAndControlAuditRoutingModule } from './process-and-control-audit-routing.module';
import { RiskConfigurationsComponent } from './risk-configurations/risk-configurations.component';
import { RiskCriteriaComponent } from './risk-configurations/risk-criteria/risk-criteria.component';
import { RiskRatingComponent } from './risk-configurations/risk-rating/risk-rating.component';
import { AuditFrequencyComponent } from './risk-configurations/audit-frequency/audit-frequency.component';


@NgModule({
  declarations: [
    RiskConfigurationsComponent,
    RiskCriteriaComponent,
    RiskRatingComponent,
    AuditFrequencyComponent
  ],
  imports: [
    CommonModule,
    ProcessAndControlAuditRoutingModule,
    GridModule,
    CardModule,
    FormModule,
    MultiSelectModule,
    ModalModule,
    ButtonModule,
    ReactiveFormsModule,
    DataTablesModule,
    FormsModule,
    TabsModule,
    NavModule,
    HttpClientModule,
    AccordionModule,
    CdkAccordionModule,
    IconModule,
  ]
})
export class ProcessAndControlAuditModule { }
