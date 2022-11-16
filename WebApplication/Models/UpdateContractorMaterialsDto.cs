using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.ConctractorMaterials.Commands.UpdateContractorMaterial;

namespace WebApplication.Models
{
    public class UpdateContractorMaterialsDto : IMapWith<UpdateContractorMaterialCommand>
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime validaty { get; set; }
        public int producer { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateContractorMaterialsDto, UpdateContractorMaterialCommand>()
                .ForMember(customerCommand => customerCommand.id,
                    opt => opt.MapFrom(customerDto => customerDto.id))
                .ForMember(customerCommand => customerCommand.name,
                    opt => opt.MapFrom(customerDto => customerDto.name))
                .ForMember(customerCommand => customerCommand.createdDate,
                    opt => opt.MapFrom(customerDto => customerDto.createdDate))
                .ForMember(customerCommand => customerCommand.validaty,
                    opt => opt.MapFrom(customerDto => customerDto.validaty))
                .ForMember(customerCommand => customerCommand.ProducerID,
                    opt => opt.MapFrom(customerDto => customerDto.producer));
        }
    }
}
