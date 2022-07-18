export interface riskProfile {
    id:               string;
    likelihoodTypeId?:string;
    likelihoodType:   string;
    impactTypeId?:    string;
    impactType:       string;
    ratingTypeId?:    string;
    ratingType:       string;
    effectiveFrom:    Date;
    effectiveTo:      Date;
    description?:     string;
    isActive?:        boolean;

}