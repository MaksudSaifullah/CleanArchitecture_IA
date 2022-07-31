export interface riskAssessment {
    id:               string;
    countryId?:       string;
    countryName:      string;
    auditTypeId?:     string;
    auditTypeName:    string;
    assessmentCode:    string;
    effectiveFrom:    Date;
    effectiveTo:      Date;

}