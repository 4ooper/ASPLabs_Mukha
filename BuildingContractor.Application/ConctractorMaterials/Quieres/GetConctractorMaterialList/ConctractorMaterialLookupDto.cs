using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;
using System.ComponentModel.DataAnnotations;

namespace BuildingContractor.Application.ConctractorMaterials.Quieres.GetConctractorMaterialList
{
    public class ConctractorMaterialLookupDto : IMapWith<ConctractorMaterial>
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime validaty { get; set; }
        public ProducerContractorMaterialLookupDto producer { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ConctractorMaterial, ConctractorMaterialLookupDto>()
                .ForMember(materialDto => materialDto.id, opt => opt.MapFrom(material => material.id))
                .ForMember(materialDto => materialDto.name, opt => opt.MapFrom(material => material.name))
                .ForMember(materialDto => materialDto.createdDate, opt => opt.MapFrom(material => material.createdDate))
                .ForMember(materialDto => materialDto.validaty, opt => opt.MapFrom(material => material.validaty))
                .ForMember(materialDto => materialDto.producer, opt => opt.MapFrom(material => material.producer));
        }
    }
}