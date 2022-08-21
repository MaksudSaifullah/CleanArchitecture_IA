export interface AuditScheduleResponse {
    id: string,
    scheduleId:string
    country : string,
    approver : string,
    teamLeader : string,
    auditor : string,
    executionStatus : string
    scheduleState : string,
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