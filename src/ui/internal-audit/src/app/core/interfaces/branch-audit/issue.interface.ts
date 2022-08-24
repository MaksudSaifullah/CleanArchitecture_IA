export interface issue {
    id:               string;
    code:             string;
    issuetitle?:      string;
    owner?:           string;
    rating?:          string;
    actionOwner?:     string;    
    targetDate?:      Date;    
    status?:          string;
}