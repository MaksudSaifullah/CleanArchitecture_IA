export interface  IssueValidation{
    issueId:                    string;
    validatedByUserId:          string;
    reviewedByUserID:           string;
    approvedByUserId:           string;
    reviewEvidenceDocumentId:   string;
    approvalEvidenceDocumentId: string;
    closureSummary:             string;
    auditReportDate:            Date;
    validationDate:             Date;
    reviewDate:                 Date;
    approvalDate:               Date;
    issueClosureDate:           Date;
    reviewEvidenceDocument: EvidenceDocument;
    approvalEvidenceDocument: EvidenceDocument;

}
export interface EvidenceDocument {
    id?: string;
    documentSourceId?: string;
    path?: string;
    name?: string;
    format?: string;
    documentSource?: string;
}

