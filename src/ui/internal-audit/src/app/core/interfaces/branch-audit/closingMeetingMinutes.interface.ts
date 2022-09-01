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
    subjectMatter?: string;
    agreedBy?: string;
    createdOn?: Date;

}

export interface UserList{
    userId?: string;
    closingMeetingMinutesId?: string; 
}