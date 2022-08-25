export interface AuditScheduleBranch {
    auditScheduleId? : string,
    branchId : string
}


export interface WPAuditScheduleBranch {
    id:              string;
    auditScheduleId: string;
    branch:          Branch;
}

export interface Branch {
    id : string;
    branchId:   number;
    branchCode: number;
    branchName: string;
}
