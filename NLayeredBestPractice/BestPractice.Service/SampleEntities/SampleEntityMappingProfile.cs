using AutoMapper;
using BestPractice.Repository.SampleEntities;
using BestPractice.Service.SampleEntities.Create;
using BestPractice.Service.SampleEntities.Update;

namespace BestPractice.Service.SampleEntities;

/// <summary>
/// Configures AutoMapper mappings for the <see cref="SampleEntity"/> class and related DTOs.
/// This profile ensures consistent and efficient mapping between domain models and DTOs.
/// </summary>
public class SampleEntityMappingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SampleEntityMappingProfile"/> class.
    /// Defines mappings between <see cref="SampleEntity"/>, <see cref="SampleEntityDto"/>,
    /// <see cref="CreateSampleEntityRequest"/>, and <see cref="UpdateSampleEntityRequest"/>.
    /// </summary>
    public SampleEntityMappingProfile()
    {
        // Maps SampleEntity to SampleEntityDto and vice versa.
        CreateMap<SampleEntity, SampleEntityDto>().ReverseMap();

        // Maps CreateSampleEntityRequest to SampleEntity, converting the name to lowercase.
        CreateMap<CreateSampleEntityRequest, SampleEntity>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));

        // Maps UpdateSampleEntityRequest to SampleEntity, converting the name to lowercase.
        CreateMap<UpdateSampleEntityRequest, SampleEntity>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));
    }
}