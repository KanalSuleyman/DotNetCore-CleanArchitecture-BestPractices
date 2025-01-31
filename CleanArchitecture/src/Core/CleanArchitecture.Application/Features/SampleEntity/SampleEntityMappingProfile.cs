using AutoMapper;
using BestPractice.Service.SampleEntities.Update;
using CleanArchitecture.Application.Features.SampleEntity.Create;
using CleanArchitecture.Application.Features.SampleEntity.Dto;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.SampleEntity;

/// <summary>
/// Configures AutoMapper mappings for the <see cref="SampleEntity"/> class and related DTOs.
/// This profile ensures consistent and efficient mapping between domain models and DTOs.
/// </summary>
public class SampleEntityMappingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SampleEntityMappingProfile"/> class.
    /// Defines mappings between <see cref="SampleEntity"/>, <see cref="UpdateSampleEntityRequest"/>,
    /// <see cref="SampleEntityDto"/>, and <see cref="CreateSampleEntityRequest"/>.
    /// </summary>
    public SampleEntityMappingProfile()
    {
        // Maps SampleEntity to SampleEntityDto and vice versa.
        CreateMap<Domain.Entities.SampleEntity, SampleEntityDto>().ReverseMap();

        // Maps CreateSampleEntityRequest to SampleEntity, converting the name to lowercase.
        CreateMap<CreateSampleEntityRequest, Domain.Entities.SampleEntity>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));

        // Maps UpdateSampleEntityRequest to SampleEntity, converting the name to lowercase.
        CreateMap<UpdateSampleEntityRequest, Domain.Entities.SampleEntity>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));
    }
}