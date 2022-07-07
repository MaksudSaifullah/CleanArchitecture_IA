export interface riskProfile {
    id:               string;
    likelihoodType:   string;
    impactType:       string;
    ratingType:       string;
    effectiveFrom:    Date;
    effectiveTo:      Date;
    description:      string;
    isActive:         boolean;

}