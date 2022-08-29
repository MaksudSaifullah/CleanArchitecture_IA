export interface AuditSchedule {
    id: string,
    scheduleId: string,
    countryId: string,
    country : string,
    approver : string,
    teamLeader : string,
    auditor : string,
    executionStatus : string
    scheduleState : string,
    scheduleStartDate : Date
    scheduleEndDate : Date
}

