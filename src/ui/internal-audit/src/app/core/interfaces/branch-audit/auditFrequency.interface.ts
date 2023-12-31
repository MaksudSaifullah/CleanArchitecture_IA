export interface auditFrequency 
{

        id: string;
        countryId: string;
        auditScore: string;
        auditScoreId?: string;
        ratingType: string;
        ratingTypeId?: string;
        auditFrequencyType: string;
        auditFrequencyTypeId?: string;
        effectiveFrom: Date;
        effectiveTo: Date;
        countryName?: string;
}