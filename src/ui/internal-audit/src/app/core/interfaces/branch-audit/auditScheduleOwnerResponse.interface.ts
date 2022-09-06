export interface AuditScheduleOwnerResponse {
    auditScheduleId?:                          string;
    commonValueAuditScheduleRiskOwnerTypetId?: number;
    branchId?:                                 string;
    branchName?:                               string;
    user:                                     User[];
}

export interface User {
    id?:       string;
    userName?: string;
}
export interface RiskOwner {
    id?:       string;
    userName?: string;
}
export interface ActionOwner {
    id?:       string;
    userName?: string;
}
