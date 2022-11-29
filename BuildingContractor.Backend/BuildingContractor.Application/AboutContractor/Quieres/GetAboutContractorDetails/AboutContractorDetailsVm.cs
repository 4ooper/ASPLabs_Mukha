using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;
using BuildingContractor.Application.ContractorStocks.Quieres.GetContractorStockDetails;
using BuildingContractor.Application.Contractors.Quieres.GetContractorDetails;
using BuildingContractor.Application.ContractorTechnique.Quieres.GetContractorTechniqueDetails;
using AutoMapper;

namespace BuildingContractor.Application.AboutContractor.Quieres.GetAboutContractorDetails
{
    public class AboutContractorDetailsVm : IMapWith<Domain.AboutContractor>
    {
        public int id { get; set; }
        public ContractorDetailsVm contractor { get; set; }
        public ContractorStockDetailsVm contractorStock { get; set; }   
        public ContractorTechniqueDetailsVm contractorTechnique { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.AboutContractor, AboutContractorDetailsVm>()
                .ForMember(materialDto => materialDto.id, opt => opt.MapFrom(material => material.id))
                .ForMember(materialDto => materialDto.contractor, opt => opt.MapFrom(material => material.contractor))
                .ForMember(materialDto => materialDto.contractorStock, opt => opt.MapFrom(material => material.contractorStock))
                .ForMember(materialDto => materialDto.contractorTechnique, opt => opt.MapFrom(material => material.contractorTechnique));
        }
    }
}
