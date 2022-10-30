using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;

namespace BuildingContractor.WebAPI.Models
{
    public class ContractorMaterialDto : IMapWith<ConctractorMaterial>
    {
        public int id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ContractorMaterialDto, ConctractorMaterial>()
                .ForMember(customerCommand => customerCommand.id,
                    opt => opt.MapFrom(customerDto => customerDto.id));
        }
    }
}
