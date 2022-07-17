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

export interface RoleSelectedList {
    pageSize?:   number;
    pageNumber?: number;
    roleId?:     string;
    searchTerm?: string;
}

export interface RoleSelectedListResponse {
    items?:      RoleBody[];
    totalCount?: number;
}

export interface RoleBody {
    id?:             string;
    auditModuleId?:  string;
    auditFeatureId?: string;
    roleId?:         string;
    isView?:         boolean;
    isCreate?:       boolean;
    isEdit?:         boolean;
    isDelete?:       boolean;
}

