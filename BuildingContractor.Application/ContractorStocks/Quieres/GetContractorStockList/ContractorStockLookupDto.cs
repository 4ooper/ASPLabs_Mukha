using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;
using System.ComponentModel.DataAnnotations;

namespace BuildingContractor.Application.ContractorStocks.Quieres.GetContractorStockList
{
    public class ContractorStockLookupDto : IMapWith<ContractorStock>
    {
        public int id { get; set; }
        public int count { get; set; }
        public int price { get; set; }
        public ContractorStockMaterialDto conctractorMaterial { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ContractorStock, ContractorStockLookupDto>()
                .ForMember(materialDto => materialDto.id, opt => opt.MapFrom(material => material.id))
                .ForMember(materialDto => materialDto.count, opt => opt.MapFrom(material => material.count))
                //.ForMember(materialDto => materialDto.contractorMaterialID, opt => opt.MapFrom(material => material.contractorMaterialID))
                .ForMember(materialDto => materialDto.price, opt => opt.MapFrom(material => material.price))
                .ForMember(materialDto => materialDto.conctractorMaterial, opt => opt.MapFrom(material => material.conctractorMaterial));
        }
    }
}
