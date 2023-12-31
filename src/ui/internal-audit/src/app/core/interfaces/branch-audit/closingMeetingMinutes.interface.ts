export interface ClosingMeetingMinutes 
{
    id?: string;
    meetingMinutesCode?: string;
    scheduleCode?: string;
    auditScheduleId?: string;
    auditScheduleBranchId?: string;
    meetingMinutesDate: string;
    meetingMinutesName?: string;
    auditOn?: string;
    meetingHeld?: string;
    preparedByUserId?: string;
    agreedByUserId?: string;
    agreedBy?: string;
    createdOn?: Date;
    

    closingMeetingPresent?: addMeetingPresent[];
    closingMeetingApology?: addMeetingApology[];
    closingMeetingSubject?: addMeetingSubject[];
    
    userPresents?: addMeetingPresent[];
    userApologies?: addMeetingApology[];
    meetingMinutesSubjects?: addMeetingSubject[];

}

export interface addMeetingPresent
{
    userId?: string;
}

export interface addMeetingApology
{
    userId?: string;
}

export interface addMeetingSubject
{
    userId?: string;
    subjectMatter?: string;
}
