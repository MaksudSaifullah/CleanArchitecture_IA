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

    issueOwnerList?: IssueOwner[];
    issueBranchList?: IssueBranch[];
    actionPlans?: IssueActionPlan[];
}

export interface IssueBranch {
    id?: string;
    issueId?: string;
    branchId?: string;
}
export interface IssueOwner{
    id?: string;
    issueId?: string;
    ownerId?: string;

}
export interface IssueActionPlan{
    id?: string;
    issueId?: string;
    actionPlanCode?: string;
    //ownerId?: string;
    issueActionPlanOwnerList?: IssueActionPlanOwner[];
    evidenceDocumentId?: string;
    managementPlan?: string;
    targetDate?: Date;
    isActionTaken?: boolean;
    actionTakenDate?: Date;
    actionTakenRemarks?: string
}
export interface IssueActionPlanOwner{
    id?: string;
    issueActionPlanId?: string;
    ownerId?: string;

}