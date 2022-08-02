export interface questionnaire {
    id: string;
    countryName?: string;
    topichHeadName?: string;
    question: string;
    effectiveFrom: Date;
    effectiveTo: Date; 
    countryId?: string;
    topicHeadId?: string;
    isActive?: boolean;
      
}