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
        //Task<IEnumerable<CommonValueAndType>> GetAllEMailType();
        //Task<IEnumerable<CommonValueAndType>> GetAllLevelOfLikelihood();
        //Task<IEnumerable<CommonValueAndType>> GetAllLevelOfImpact();
        //Task<IEnumerable<CommonValueAndType>> GetAllRiskRating();
        //Task<IEnumerable<CommonValueAndType>> GetAllRiskRatingName();
        //Task<IEnumerable<CommonValueAndType>> GetAllLOProductivity();
        //Task<IEnumerable<CommonValueAndType>> GetAllYear();
        //Task<IEnumerable<CommonValueAndType>> GetAllSampledMonth();
        //Task<IEnumerable<CommonValueAndType>> GetAllSampleSelectionMethod();
        //Task<IEnumerable<CommonValueAndType>> GetAllNatureOfControlActivity();
        //Task<IEnumerable<CommonValueAndType>> GetAllControlFrequency();
        //Task<IEnumerable<CommonValueAndType>> GetAllIssueStatus();
        //Task<IEnumerable<CommonValueAndType>> GetAllAuditConducted();
        //Task<IEnumerable<CommonValueAndType>> GetAllDetestConclusion();
        //Task<IEnumerable<CommonValueAndType>> GetAllYesNo();
        Task<IEnumerable<CommonValueAndType>> GetCommonValueType(string type);

    }
}
