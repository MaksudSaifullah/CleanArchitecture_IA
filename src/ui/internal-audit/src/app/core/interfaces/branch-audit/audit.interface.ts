export interface Audit {
    id: string;
    countryId: string;
    auditTypeId: string;
    auditScheduleId: string;
    planId: string;
    auditPlanId: string;
    auditId: string;
    year: string;
    auditName: string;
    auditTypeName: string;
    countryName: string;
    auditPeriodFrom: string;
    auditPeriodTo: string;
    scheduleState : string
    executionState : string,
    createdOn: Date;
}
