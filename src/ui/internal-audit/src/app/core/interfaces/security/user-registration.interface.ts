export interface UserRegistration {
    user: string;
    name: string;

}

export interface userRegistrationRequestData {
    user: User;
    employee: Employee;
    userRole: UserRole[];
    userCountry: UserCountry[];
}

export interface Employee {
    userId: string;
    designationId: string;
    photoId: string;
    name: string;
    email: string;
    isActive: boolean;
}

export interface User {
    id: string;
    userName: string;
    password: string;
    isEnabled: boolean;
    isAccountExpired: boolean;
    isPasswordExpired: boolean;
    isAccountLocked: boolean;
}

export interface UserCountry {
    countryId: string;
    userId?: string;
    isActive: boolean;
}

export interface UserRole {
    userId?: string;
    roleId: string;
}





export interface UserResponse {
    id?:                string;
    userName?:          string;
    password?:          string;
    isEnabled?:         boolean;
    isAccountExpired?:  boolean;
    isPasswordExpired?: boolean;
    isAccountLocked?:   boolean;
    userCountries:     UserCountry[];
    userRoles:         UserRole[];
    employee:          EmployeeResponse;
}

export interface EmployeeResponse {
    userId?:        string;
    designationId?: string;
    photoId?:       string;
    name?:          string;
    email?:         string;
    isActive?:      boolean;
    user?:          null;
    designation?:   null;
    id:            string;
    createdBy?:     string;
    createdOn?:     Date;
    updatedBy?:     null;
    updatedOn?:     null;
    reviewedBy?:    null;
    reviewedOn?:    null;
    approvedBy?:    null;
    approvedOn?:    null;
    isDeleted?:     boolean;
}

export interface UserCountryResponse {
    countryId?:  string;
    userId?:     string;
    isActive?:   boolean;
    country?:    null;
    user?:       null;
    id?:         string;
    createdBy?:  string;
    createdOn?:  Date;
    updatedBy?:  null;
    updatedOn?:  null;
    reviewedBy?: null;
    reviewedOn?: null;
    approvedBy?: null;
    approvedOn?: null;
    isDeleted?:  boolean;
}

export interface UserRoleResponse {
    userId?:     string;
    roleId?:     string;
    id?:         string;
    createdBy?:  string;
    createdOn?:  Date;
    updatedBy?:  null;
    updatedOn?:  null;
    reviewedBy?: null;
    reviewedOn?: null;
    approvedBy?: null;
    approvedOn?: null;
    isDeleted?:  boolean;
}
