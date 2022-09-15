export interface  IssueValidation{
    issueId:                    string;
    validatedByUserId:          string;
    reviewedByUserID:           string;
    approvedByUserId:           string;
    reviewEvidenceDocumentId:   string;
    approvalEvidenceDocumentId: string;
    closureSummary:             string;
    validationDate:             Date;
    reviewDate:                 Date;
    approvalDate:               Date;
    issueClosureDate:           Date;
}
