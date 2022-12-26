using AutoMapper;
using BuildingContractor.Domain;
using BuildingContractor.Application.Common.Mappings;

namespace BuildingContractor.Application.Contractors.Quieres.GetContractorDetails
{
    public class ContractorStockMaterialDetailsDto : IMapWith<Material>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Material, ContractorStockMaterialDetailsDto>()
                .ForMember(recordCommand => recordCommand.Name,
                    opt => opt.MapFrom(recordDto => recordDto.Name));
        }
    }
}
