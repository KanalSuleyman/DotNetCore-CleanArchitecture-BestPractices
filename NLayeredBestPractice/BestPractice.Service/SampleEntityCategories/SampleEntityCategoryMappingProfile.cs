using AutoMapper;
using BestPractice.Repository.SampleEntityCategories;
using BestPractice.Service.SampleEntityCategories.Create;
using BestPractice.Service.SampleEntityCategories.Dtos;
using BestPractice.Service.SampleEntityCategories.Update;

namespace BestPractice.Service.SampleEntityCategories;

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
        CreateMap<SampleEntityCategory, SampleEntityCategoryDto>().ReverseMap();

        // Maps SampleEntityCategory to SampleEntityCategoryWithSampleEntitiesDto and vice versa.
        CreateMap<SampleEntityCategory, SampleEntityCategoryWithSampleEntitiesDto>().ReverseMap();

        // Maps CreateSampleEntityCategoryRequest to SampleEntityCategory, converting the name to lowercase.
        CreateMap<CreateSampleEntityCategoryRequest, SampleEntityCategory>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));

        // Maps UpdateSampleEntityCategoryRequest to SampleEntityCategory, converting the name to lowercase.
        CreateMap<UpdateSampleEntityCategoryRequest, SampleEntityCategory>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));
    }
}