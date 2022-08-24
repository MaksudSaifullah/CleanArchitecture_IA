export interface AuditScheduleResponse {
    id: string,
    auditId: string,
    scheduleId:string,
    auditTypeId: string,
    country : string,
    approver : string,
    teamLeader : string,
    auditor : string,
    executionStatus : string
    scheduleState : string,
    auditPeriodFrom: Date,
    auditPeriodTo: Date,
    scheduleStartDate : Date
    scheduleEndDate : Date
    branchList: AuditScheduleBranch []
    participantList: AuditScheduleParticipant []
}

export interface AuditScheduleBranch {
    auditScheduleId? : string,
    branchId : string
}

export interface AuditScheduleParticipant {
    userId : string,
    auditScheduleId? : string,
    commonValueParticipantId : number
    
}