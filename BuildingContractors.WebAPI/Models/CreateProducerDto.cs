using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.Producers.Commands.CreateProducer;

namespace BuildingContractor.WebAPI.Models
{
    public class CreateProducerDto : IMapWith<CreateProducerCommand>
    {
        public string name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProducerDto, CreateProducerCommand>()
                .ForMember(customerCommand => customerCommand.name,
                    opt => opt.MapFrom(customerDto => customerDto.name));
        }
    }
}
