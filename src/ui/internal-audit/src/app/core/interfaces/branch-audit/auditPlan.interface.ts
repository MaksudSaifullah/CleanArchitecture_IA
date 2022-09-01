export interface auditPlan {
    id:               string;
    planCode:         string;
    countryId?:       string;
    countryName:      string;
    auditTypeId?:    string;
    auditTypeName:    string;
    planningYearId?:     string;
    planningYearName:    string;
    riskAssessmentId?: string;
    assessmentCode:    string;
    assessmentFrom:    Date;
    assessmentTo:      Date;
    createdOn: Date;
    createdBy: string;
    planningYear: string;
}