export interface ScheduleOwner {
    data?: Datum[];
}

export interface Datum {
    auditScheduleId:                          string;
    userId:                                   string;
    branchId:                                 string;
    commonValueAuditScheduleRiskOwnerTypetId: number;
}

export interface AuditScheduleOwner {
    auditScheduleId:                          string;
    branchName:                               string;
    userName:                                 string;
}



// export interface ScheduleActionOwner {
//     id: string,
//     scheduleId: string,
//     branchId: string,
//     userId: string
// }

// export interface ScheduleSetDate {
//     id: string,
//     scheduleId: string,
//     auditIniciationDate: Date,
//     planningAndScopingStartDate: Date,
//     planningAndScopingEndDate: Date,
//     fieldWorkStartDate: Date,
//     fieldWorkEndDate: Date
// }


// export interface ScheduleRiskOwnerResponse {
//     id: string,
//     scheduleId: string,
//     branchId: string,
//     riskOwners: ScheduleRiskOwner []
// }

// export interface ScheduleActionOwnerResponse {
//     id: string,
//     scheduleId: string,
//     branchId: string,
//     actionOwners: ScheduleActionOwner []
// }