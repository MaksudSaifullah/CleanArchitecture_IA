export interface UserRegistration {
    user: string;
    name: string;

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

export interface Employee {
    userId: string;
    designationId: string;
    photoId: string;
    name: string;
    email: string;
    isActive: boolean;
}

export interface UserRole {
    userId: string;
    roleId: string;
}

export interface UserCountry {
    countryId: string;
    userId: string;
    isActive: boolean;
}

export interface userRegistrationRequestData {
    user: User;
    employee: Employee;
    userRole: UserRole[];
    userCountry: UserCountry[];
}

