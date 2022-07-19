export interface riskAssessment {
    id:               string;
    countryId?:       string;
    auditTypeId?:     string;
    assesmentCode:    string;
    country:          string;
    auditType:        string;
    effectiveFrom:    Date;
    effectiveTo:      Date;

}