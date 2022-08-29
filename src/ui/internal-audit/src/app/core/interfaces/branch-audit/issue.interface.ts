export interface issue {
    id:               string;
    code:             string;
    issueTitle?:      string;
    issueOwners?:     string;
    ratingType?:      string;
    actionOwners?:    string;    
    targetDate?:      Date;    
    statusType?:      string;

    auditScheduleId?: string;
    branchId?: string;
    impactTypeId?: string;
    likelihoodTypeId?: string;
    ratingTypeId?: string;
    statusTypeId?: string;
    policy?: string;
    details?: string;
    rootCause?: string;
    businessImpact?: string;
    potentialRisk?: string;
    auditorRecommendation?: string;
    remarks?: string | null;
    likelihoodType?: string | null;
    impactType?: string | null;
    branch?: string | null;
}