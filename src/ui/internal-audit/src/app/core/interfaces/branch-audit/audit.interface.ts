export interface Audit {
    id: string;
    countryId: string;
    auditTypeId: string;
    planId: string;
    auditId: string;
    year: string;
    auditName: string;
    auditTypeName: string;
    countryName: string;
    auditPeriodFrom: string;
    auditPeriodTo: string;
    createdOn: Date;
}
