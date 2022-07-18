﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskCriterias.Queries.GetRiskCriteriaList;
public record RiskCriteriaDTO
{
    public Guid Id { get; set; }
    public string CountryId { get; set; }
    public string RiskCriteriaTypeId { get; set; }
    public decimal MinimumValue { get; set; }
    public decimal MaximumValue { get; set; }
    public string RatingTypeId { get; set; }
    public decimal Score { get; set; }
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
    public string? Description { get; set; } = null;


}


