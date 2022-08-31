export interface topicHead {
    id: string;
    countryId?: string;
    name: string;
    effectiveFrom: Date;
    effectiveTo: Date;
    description?: string;
    isActive?: boolean;
    countryName?: string;    
}
export interface topicHeadCal {
    id: string;
    value:string 
}