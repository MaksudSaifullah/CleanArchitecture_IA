﻿using Internal.Audit.Domain.Entities.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.CommonValueAndTypes
{
    public interface ICommonValueAndTypeQueryRepository : IAsyncQueryRepository<CommonValueAndType>
    {        
        Task<IEnumerable<CommonValueAndType>> GetCommonValueType(string type);
        Task<CommonValueAndType> GetByIDCreationValue(int value);

    }
}
