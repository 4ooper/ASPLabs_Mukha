using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.AboutContractor.Commands.CreateAboutContractor;

namespace BuildingContractor.WebAPI.Models
{
    public class CreateAboutContractorDto : IMapWith<CreateAboutContractorCommand>
    {
        public int contractorID { get; set; }
        public int contractorStockID { get; set; }
        public int contractorTechniquesID { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAboutContractorDto, CreateAboutContractorCommand>()
                .ForMember(customerCommand => customerCommand.contractorID,
                    opt => opt.MapFrom(customerDto => customerDto.contractorID))
                .ForMember(customerCommand => customerCommand.contractorStockID,
                    opt => opt.MapFrom(customerDto => customerDto.contractorStockID))
                .ForMember(customerCommand => customerCommand.contractorTechniquesID,
                    opt => opt.MapFrom(customerDto => customerDto.contractorTechniquesID));
        }
    }
}
