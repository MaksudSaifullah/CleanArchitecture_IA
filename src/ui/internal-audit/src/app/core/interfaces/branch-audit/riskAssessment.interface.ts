export interface riskAssessment {
    id:               string;
    countryId?:       string;
    countryName:      string;
    auditTypeId?:     string;
    auditTypeName:    string;
    assesmentCode:    string;
    effectiveFrom:    Date;
    effectiveTo:      Date;

}