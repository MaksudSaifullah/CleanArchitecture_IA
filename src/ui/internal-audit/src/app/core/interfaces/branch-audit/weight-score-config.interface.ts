export interface WeightScoreConfigRequest {
    weightScoreData?: WeightScoreDatum[];
}

export interface WeightScoreDatum {
    countryId?:   string;
    topicHeadId?: string;
    score?:       number;
}
