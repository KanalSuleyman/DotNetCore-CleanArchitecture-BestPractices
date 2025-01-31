using AutoMapper;
using CleanArchitecture.Application.Features.SampleEntityCategory.Create;
using CleanArchitecture.Application.Features.SampleEntityCategory.Dto;
using CleanArchitecture.Application.Features.SampleEntityCategory.Update;

namespace CleanArchitecture.Application.Features.SampleEntityCategory;

/// <summary>
/// Configures AutoMapper mappings for the <see cref="SampleEntityCategory"/> class and related DTOs.
/// This profile ensures consistent and efficient mapping between domain models and DTOs.
/// </summary>
public class SampleEntityCategoryMappingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SampleEntityCategoryMappingProfile"/> class.
    /// Defines mappings between <see cref="SampleEntityCategory"/>, <see cref="SampleEntityCategoryDto"/>,
    /// <see cref="SampleEntityCategoryWithSampleEntitiesDto"/>, <see cref="CreateSampleEntityCategoryRequest"/>,
    /// and <see cref="UpdateSampleEntityCategoryRequest"/>.
    /// </summary>
    public SampleEntityCategoryMappingProfile()
    {
        // Maps SampleEntityCategory to SampleEntityCategoryDto and vice versa.
        CreateMap<Domain.Entities.SampleEntityCategory, SampleEntityCategoryDto>().ReverseMap();

        // Maps SampleEntityCategory to SampleEntityCategoryWithSampleEntitiesDto and vice versa.
        CreateMap<Domain.Entities.SampleEntityCategory, SampleEntityCategoryWithSampleEntitiesDto>().ReverseMap();

        // Maps CreateSampleEntityCategoryRequest to SampleEntityCategory, converting the name to lowercase.
        CreateMap<CreateSampleEntityCategoryRequest, Domain.Entities.SampleEntityCategory>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));

        // Maps UpdateSampleEntityCategoryRequest to SampleEntityCategory, converting the name to lowercase.
        CreateMap<UpdateSampleEntityCategoryRequest, Domain.Entities.SampleEntityCategory>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));
    }
}