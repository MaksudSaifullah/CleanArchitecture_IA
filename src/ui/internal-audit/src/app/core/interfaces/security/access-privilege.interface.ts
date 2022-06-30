export interface accessPrivilegeConfig {
    passwordPolicy:    PasswordPolicy;
    userLockingPolicy: UserLockingPolicy;
    sessionPolicy:     SessionPolicy;
}

export interface PasswordPolicy {
    minLength:                          number;
    maxLength:                          number;
    isAlphabetMandatory:                boolean;
    alphabetLength:                     number;
    isNumberMandatory:                  boolean;
    numericLength:                      number;
    isSpecialCharsMandatory:            boolean;
    specialCharsLength:                 number;
    isPasswordChangeForcedOnFirstLogin: boolean;
    isPasswordResetForcedPeriodically:  boolean;
    forcePasswordResetDays:             number;
    notifyPasswordResetDays:            number;
    effectiveFrom:                      Date;
    effectiveTo:                        Date;
}

export interface SessionPolicy {
    isEnabled:     boolean;
    duration:      number;
    effectiveFrom: Date;
    effectiveTo:   Date;
}

export interface UserLockingPolicy {
    isLockedOnNoLoginActivity:   boolean;
    noLoginActivityDays:         number;
    lockedOnFailedLoginAttempts: boolean;
    numberOfFailedLoginAttempts: number;
    failedLoginAttemptsDuration: number;
    failedLoginLockedDuration:   number;
    unlockedOnByAdmin:           boolean;
    unlockedOnByAdminDuration:   number;
    effectiveFrom:               Date;
    effectiveTo:                 Date;
}
