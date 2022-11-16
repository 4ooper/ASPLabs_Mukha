using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;
using AutoMapper;

namespace BuildingContractor.Application.ContractorTechnique.Quieres.GetContractorTechniqueDetails
{
    public class ContractorTechniqueDetailsVm : IMapWith<ContractorTechniques>
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime buyDate { get; set; }
        public DateTime validaty { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ContractorTechniques, ContractorTechniqueDetailsVm>()
                .ForMember(vm => vm.id, opt => opt.MapFrom(record => record.id))
                .ForMember(vm => vm.name, opt => opt.MapFrom(record => record.name))
                .ForMember(vm => vm.buyDate, opt => opt.MapFrom(record => record.buyDate))
                .ForMember(vm => vm.validaty, opt => opt.MapFrom(record => record.validaty));
        }
    }
}
