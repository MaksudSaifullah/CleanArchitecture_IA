export interface AuditSchedule {
    id: string,
    country : string,
    approver : string,
    teamLeader : string,
    auditor : string,
    executionStatus : string
    scheduleStatus : string,
    scheduleStartDate : Date
    scheduleEndDate : Date
}

