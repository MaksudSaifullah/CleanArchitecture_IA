export interface AuditScheduleResponse {
    id?:                        string;
    scheduleStartDate:         Date;
    scheduleEndDate:           Date;
    executionState:            string; 
    scheduleState:              string;
    auditCreation:             AuditCreation;
    auditScheduleParticipants: AuditScheduleParticipantResponse[];
    auditScheduleBranch:       AuditScheduleBranchResponse[];
}

export interface AuditCreation {
    auditTypeId:     string;
    auditPlanId:     string;
    auditId:         string;
    year:            number;
    auditName:       string;
    auditPeriodFrom: string;
    auditPeriodTo:   Date;
    auditTypeName:   string;
}

export interface AuditScheduleBranchResponse {
    auditScheduleId?: string;
    branchId?:        string;
    branchName?:      string;
}

export interface AuditScheduleParticipantResponse {
    auditScheduleId?:          string;
    userId?:                   string;
    commonValueParticipantId?: number;
    user?:                     User;
}

export interface User {
    userName?:          string;
    fullName?:          null | string;
    profileImageUrl?:   null | string;
    isEnabled?:         boolean;
    isAccountExpired?:  boolean;
    isPasswordExpired?: boolean;
    isAccountLocked?:   boolean;
    employee?:          Employee;
}

export interface Employee {
    userId?:   string;
    photoId?:  string;
    name?:     string;
    email?:    string;
    isActive?: boolean;
}
