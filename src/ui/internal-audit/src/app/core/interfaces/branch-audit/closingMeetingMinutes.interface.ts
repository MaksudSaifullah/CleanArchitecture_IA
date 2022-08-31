export interface ClosingMeetingMinutes 
{
    id: string;
    meetingMinutesCode?: string;
    auditScheduleId?: string;
    branchId?: string;
    meetingMinutesDate: Date;
    meetingMinutesName?: string;
    auditOn?: string;
    meetingHeld?: string;
    preparedByUserId?: string;
    agreedByUserId?: string;
    subjectMatter?: string;
    agreedBy?: string;
    createdOn?: Date;
}
