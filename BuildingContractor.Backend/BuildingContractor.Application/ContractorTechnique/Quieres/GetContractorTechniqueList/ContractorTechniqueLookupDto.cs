using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.ContractorTechnique.Quieres.GetContractorTechniqueList
{
    public class ContractorTechniqueLookupDto : IMapWith<ContractorTechniques>
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime buyDate { get; set; }
        public DateTime validaty { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ContractorTechniques, ContractorTechniqueLookupDto>()
                .ForMember(dto => dto.id, opt => opt.MapFrom(record => record.id))
                .ForMember(dto => dto.name, opt => opt.MapFrom(record => record.name))
                .ForMember(dto => dto.buyDate, opt => opt.MapFrom(record => record.buyDate))
                .ForMember(dto => dto.validaty, opt => opt.MapFrom(record => record.validaty));
        }
    }
}
