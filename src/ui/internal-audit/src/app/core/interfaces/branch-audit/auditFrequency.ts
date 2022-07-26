export interface auditFrequency {

        id: string;
        countryId: string;
        auditScore: string;
        ratingType: string;
        auditFrequencyType: string;
        effectiveFrom: Date;
        effectiveTo: Date;
        countryName?: string;
}