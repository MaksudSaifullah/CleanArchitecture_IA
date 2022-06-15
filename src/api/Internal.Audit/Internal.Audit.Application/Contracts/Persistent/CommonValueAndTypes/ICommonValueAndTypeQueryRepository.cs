using Internal.Audit.Domain.Entities.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.CommonValueAndTypes
{
    public interface ICommonValueAndTypeQueryRepository : IAsyncQueryRepository<CommonValueAndType>
    {
        Task<IEnumerable<CommonValueAndType>> GetEMailType();
        Task<IEnumerable<CommonValueAndType>> GetLevelOfLikelihood();
        Task<IEnumerable<CommonValueAndType>> GetLevelOfImpact();
        Task<IEnumerable<CommonValueAndType>> GetRiskRating();
        Task<IEnumerable<CommonValueAndType>> GetRiskRatingName();
        Task<IEnumerable<CommonValueAndType>> GetLOProductivity();
        Task<IEnumerable<CommonValueAndType>> GetYear();
        Task<IEnumerable<CommonValueAndType>> GetSampledMonth();
        Task<IEnumerable<CommonValueAndType>> GetSampleSelectionMethod();
        Task<IEnumerable<CommonValueAndType>> GetNatureOfControlActivity();
        Task<IEnumerable<CommonValueAndType>> GetControlFrequency();
        Task<IEnumerable<CommonValueAndType>> GetIssueStatus();
        Task<IEnumerable<CommonValueAndType>> GetAuditConducted();
        Task<IEnumerable<CommonValueAndType>> GetDetestConclusion();
        Task<IEnumerable<CommonValueAndType>> GetYesNo();

    }
}
