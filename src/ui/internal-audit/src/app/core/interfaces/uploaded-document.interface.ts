export interface UploadedDocumentList {
    documentVersion?: string;
    documentId?:      string;
    description?:     string;
    approvedBy?:      string;
    activeFrom?:      Date;
    activeTo?:        Date;
    uploadedBy?:      string;
    notifyList?:      string;
    document?:        Document;
    totalCount?:      TotalCount;
}

export interface Document {
    documentSourceId?: string;
    path?:             string;
    name?:             string;
    format?:           string;
}

export interface TotalCount {
    tc?: number;
}


export interface DocumentGet {
    id?:               string;
    documentSourceId?: string;
    path?:             string;
    name?:             string;
    format?:           string;
    documentSource?:   DocumentSource;
}

export interface DocumentSource {
    name?:       string;
    isActive?:   boolean;
    id?:         string;
    createdBy?:  string;
    createdOn?:  Date;
    updatedBy?:  null;
    updatedOn?:  null;
    reviewedBy?: null;
    reviewedOn?: null;
    approvedBy?: null;
    approvedOn?: null;
    isDeleted?:  boolean;
}
