import * as internal from "stream";

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

export interface riskAssessmentOverdue {
    id: string;
    slNo: string;
    branchName: string;
    averageOverdueinSLL: string;
    dataRequestQueueService : {
        id : any;
    };

}