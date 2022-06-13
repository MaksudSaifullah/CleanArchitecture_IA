﻿namespace Internal.Audit.Application.Features.Feature.Queries.GetFeatureList;
public record GetFeatureListResponseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string DisplayName { get; set; } = null!;
}