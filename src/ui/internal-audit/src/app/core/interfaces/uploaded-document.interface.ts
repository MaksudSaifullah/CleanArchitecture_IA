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
   
}




export interface UploadDocumentRequest {
    documentVersion:         string;
    documentId:              string;
    description:             string;
    approvedBy:              string;
    activeFrom:              Date;
    activeTo:                Date;
    uploadedBy:              string;
    uploadedDocumentsNotify: UploadedDocumentsNotify[];
}

export interface UploadedDocumentsNotify {
    roleId: string;
}
export interface DocumentSource {
    id?:   string;
    name?: string;
}

