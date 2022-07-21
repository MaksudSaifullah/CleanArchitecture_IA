export interface riskAssessment {
    id:               string;
    countryId?:       string;
    auditTypeId?:     string;
    assesmentCode:    string;
    countryName:      string;
    auditTypeName:        string;
    effectiveFrom:    Date;
    effectiveTo:      Date;

}