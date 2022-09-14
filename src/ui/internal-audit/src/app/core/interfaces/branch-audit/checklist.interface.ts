export interface checklist {
  id?: string
  checklistCode?: string
  auditScheduleId?: string
  auditScheduleBranchId?: string
  auditScheduleBranchName?: string
  regionId?: string
  openingDate?: string
  disbursementDate?: string
  branchManagerName?: string
  bmJoiningDate?: string
  auditDate?: string
  auditOn?: string
  lastAuditFromDate?: string
  lastAuditToDate?: string
  isDraft?: boolean
  checklistTopic?: ChecklistTopic[]
  createdBy?: string
}

export interface ChecklistTopic {
  topicHeadId?: string
  checklistId?: string
  checklistTopicDetail?: ChecklistTopicDetail[]
}

export interface ChecklistTopicDetail {
  checklistTopicId?: string
  questionId?: string
  testStepId?: string
  documentId?: string
  testingResult?: string
  testingConclusion?: string
  totalScore?: number
  obtainedScore?: number
  weight?: number
  weightedScore?: number
}
