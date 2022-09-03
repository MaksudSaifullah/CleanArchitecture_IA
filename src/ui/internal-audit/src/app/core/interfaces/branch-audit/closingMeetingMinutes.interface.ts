export interface ClosingMeetingMinutes 
{
    id: string;
    meetingMinutesCode?: string;
    scheduleCode?: string;
    auditScheduleId?: string;
    branchId?: string;
    meetingMinutesDate: Date;
    meetingMinutesName?: string;
    auditOn?: string;
    meetingHeld?: string;
    preparedByUserId?: string;
    agreedByUserId?: string;
    presentUserId : UserList[];
    appologiesUserId : UserList[];
    subjectMatter?: ClosingMeetingSubjects[];
    ownerId?: ClosingMeetingSubjects[];
    agreedBy?: string;
    createdOn?: Date;

}

export interface UserList
{
    userId?: string;
    closingMeetingMinutesId?: string; 
}

export interface ClosingMeetingSubjects
{
    userId?: string;
    closingMeetingMinutesId?: string; 
    subjectMatter?: string;
}