using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;
using AutoMapper;

namespace BuildingContractor.Application.ConctractorMaterials.Quieres.GetContractorMaterialDetails
{
    public class ContractorMaterialDetailsVm : IMapWith<ConctractorMaterial>
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime validaty { get; set; }
        public ProducerContractorMaterialDetailsLookupDto producer { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ConctractorMaterial, ContractorMaterialDetailsVm>()
                .ForMember(materialDto => materialDto.id, opt => opt.MapFrom(material => material.id))
                .ForMember(materialDto => materialDto.name, opt => opt.MapFrom(material => material.name))
                .ForMember(materialDto => materialDto.createdDate, opt => opt.MapFrom(material => material.createdDate))
                .ForMember(materialDto => materialDto.validaty, opt => opt.MapFrom(material => material.validaty))
                .ForMember(materialDto => materialDto.producer, opt => opt.MapFrom(material => material.producer));
        }
    }
}
