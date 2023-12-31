﻿using Internal.Audit.Domain.Entities.common;

namespace Internal.Audit.Application.Contracts.Persistent.Designations;

public interface IDesignationQueryRepository : IAsyncQueryRepository<Designation>
{
    Task<(long, IEnumerable<Designation>)> GetAll(int pageSize, int pageNumber, dynamic searchTerm=null);
    Task<Designation> GetById(Guid id);
}

