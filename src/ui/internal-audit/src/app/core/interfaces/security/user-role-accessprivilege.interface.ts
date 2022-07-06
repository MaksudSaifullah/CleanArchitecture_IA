export interface UserRoleAccessPrivilege {
    id?:        string;
    moduleId?:  string;
    featureId?: string;
    module?:    Feature;
    feature?:   Feature;
}

export interface Feature {
    name?:           string;
    displayName?:    string;
    isActive?:       boolean;
    moduleFeatures?: null;
    featureActions?: null;
    roleFeatures?:   null;
    id?:             string;
    
}
export interface ModuleList {
    id?:        string;
    displayname?:  string;
    name?:  string;
   
}