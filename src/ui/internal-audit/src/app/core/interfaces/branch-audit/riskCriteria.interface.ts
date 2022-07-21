
    export interface riskCriteria {
        id: string;
        countryId: string;
        riskCriteriaTypeId?: string;
        riskCriteriaType: string;
        minimumValue: number;
        maximumValue: number;
        ratingTypeId?:string;
        ratingType:string;
        score: number;
        effectiveFrom: Date;
        effectiveTo: Date;
        description: string;
        countryName?: string;
    }

