export interface ClosingMeetingMinutes 
{
    id: string;
    meetingMinutesCode?: string;
    scheduleCode?: string;
    auditScheduleId?: string;
    auditSchedulebranchId?: string;
    meetingMinutesDate: Date;
    meetingMinutesName?: string;
    auditOn?: string;
    meetingHeld?: string;
    preparedByUserId?: string;
    agreedByUserId?: string;
    presentUserId : string;
    appologiesUserId : string;
    subjectMatter?: string;
    agreedBy?: string;
    createdOn?: Date;
    closingMeetingPresent?: addMeetingPresent[];
    closingMeetingApology?: addMeetingApology[];
    closingMeetingSubject?: addMeetingSubject[];
   

}

export interface addMeetingPresent
{
    userId?: string;
    closingMeetingMinutesId?: string; 
}

export interface addMeetingApology
{
    userId?: string;
    closingMeetingMinutesId?: string; 
}

export interface addMeetingSubject
{
    userId?: string;
    closingMeetingMinutesId?: string; 
    subjectMatter?: string;
}
