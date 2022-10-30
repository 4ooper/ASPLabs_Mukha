using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.ConctractorMaterials.Commands.CreateContractorMaterial;
using BuildingContractor.Domain;

namespace BuildingContractor.WebAPI.Models
{
    public class CreateContractorMaterialDto : IMapWith<CreateContractorMaterialCommand>
    {
        public string name { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime validaty { get; set; }
        public ProducerDto producer { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateContractorMaterialDto, CreateContractorMaterialCommand>()
                .ForMember(customerCommand => customerCommand.name,
                    opt => opt.MapFrom(customerDto => customerDto.name))
                .ForMember(customerCommand => customerCommand.createdDate,
                    opt => opt.MapFrom(customerDto => customerDto.createdDate))
                .ForMember(customerCommand => customerCommand.validaty,
                    opt => opt.MapFrom(customerDto => customerDto.validaty))
                .ForMember(customerCommand => customerCommand.producer,
                    opt => opt.MapFrom(customerDto => customerDto.producer));
        }
    }
}
