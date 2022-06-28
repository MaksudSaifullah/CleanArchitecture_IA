export interface paginatedModelInterface{
  pagesize:number;
  pageNumber:number;
  searchTerm: any
}


export interface paginatedResponseInterface <T> {
  totalCount: number,
  items: T[]
}
