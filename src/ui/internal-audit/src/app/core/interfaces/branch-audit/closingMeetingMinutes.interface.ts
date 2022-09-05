export interface ClosingMeetingMinutes 
{
    id?: string;
    meetingMinutesCode?: string;
    scheduleCode?: string;
    auditScheduleId?: string;
    auditScheduleBranchId?: string;
    meetingMinutesDate: Date;
    meetingMinutesName?: string;
    auditOn?: string;
    meetingHeld?: string;
    preparedByUserId?: string;
    agreedByUserId?: string;
    agreedBy?: string;
    createdOn?: Date;
    

    closingMeetingPresent: addMeetingPresent[];
    closingMeetingApology: addMeetingApology[];
    closingMeetingSubject: addMeetingSubject[];
   

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
