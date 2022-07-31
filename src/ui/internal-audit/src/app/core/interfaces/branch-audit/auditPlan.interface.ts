export interface auditPlan {
    id:               string;
    planCode:         string;
    countryName:      string;
    auditTypeName:    string;
    planningYearId:     string;
    planningYearName:    string;
    riskAssessmentId?: string;
    assessmentCode:    string;
    assessmentFrom:    Date;
    assessmentTo:      Date;
}