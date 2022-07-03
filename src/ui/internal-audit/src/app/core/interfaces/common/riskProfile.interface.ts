export interface riskProfile {
    id:               string;
    likelihoodTypeId: string;
    impactTypeId:     string;
    ratingTypeId:     string;
    effectiveFrom:    Date;
    effectiveTo:      Date;
    description:      string;
    isActive:         boolean;

}