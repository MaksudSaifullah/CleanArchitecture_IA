using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AmbsDataSyncs.Queries.GetAmbsDataSyncDataByCountryAndDateInfo;

public class GetAmbsDataSyncDataByCountryAndDateInfoDTO
{
    public Guid Id { get; set; }
    public Guid DataRequestQueueServiceId { get; set; }
    public int BranchCode { get; set; }
    public long BranchId { get; set; }    
    public string? BranchName { get; set; }
    public decimal Amount { get; set; }
    public decimal? AmountConverted { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }

    public virtual DataRequestQueueServiceDTO DataRequestQueueService { get; set; } = null!;
   public virtual RiskCriteriaDTOs RiskCriteria { get; set; } = null!;
}


public class DataRequestQueueServiceDTO
{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }   
    public string RequestType { get; set; }   
    
    public bool IsActive { get; set; }
    public virtual CountryDTOs Country { get; set; }

}

public class CountryDTOs
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Remarks { get; set; } = null!;

    //Navigation properties
   // public virtual ICollection<UserCountry> UserCountries { get; set; } = null!;

}

public class RiskCriteriaDTOs
{

    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public Guid RatingTypeId { get; set; }    
    public Guid RiskCriteriaTypeId { get; set; }
    public DateTime EffectiveFrom { get; set; }    
    public DateTime EffectiveTo { get; set; }
    public decimal MinimumValue { get; set; }   
    public decimal MaximumValue { get; set; }
    public decimal Score { get; set; }
    public string? Description { get; set; } = null!;
   
    public virtual CountryDTOs Country { get; set; } = null!;

    public virtual CommonValueAndTypeDTO CommonValueRatingType { get; set; } = null!;
    public virtual CommonValueAndTypeDTO CommonValueRiskCriteriaType { get; set; } = null!;


}
public class CommonValueAndTypeDTO
{
    public Guid Id { get; set; }
    public Int32 Value { get; set; }  
    public string Text { get; set; } = null!;
}
