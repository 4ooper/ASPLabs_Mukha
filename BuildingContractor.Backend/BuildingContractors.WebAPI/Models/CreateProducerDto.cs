using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.Producers.Commands.CreateProducer;

namespace BuildingContractor.WebAPI.Models
{
    public class CreateProducerDto : IMapWith<CreateProducerCommand>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProducerDto, CreateProducerCommand>()
                .ForMember(recordCommand => recordCommand.Name,
                    opt => opt.MapFrom(recordDto => recordDto.Name));
        }
    }
}
