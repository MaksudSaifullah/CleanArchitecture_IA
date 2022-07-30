export interface auditPlan {
    id:               string;
    planCode:         string;
    countryName:      string;
    auditTypeName:    string;
    planningYearId:     string;
    planningYearName:    string;
    riskAssesmentId?: string;
    assesmentCode:    string;
    assesmentFrom:    Date;
    assesmentTo:      Date;
}