using AutoMapper;
using System;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.AboutContractor.Commands.UpdateAboutContractor;

namespace BuildingContractor.WebAPI.Models
{
    public class UpdateAboutContractorDto : IMapWith<UpdateAboutContractorCommand>
    {
        public int id { get; set; }
        public int contractorID { get; set; }
        public int contractorStockID { get; set; }
        public int contractorTechniquesID { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateAboutContractorDto, UpdateAboutContractorCommand>()
                .ForMember(customerCommand => customerCommand.id,
                    opt => opt.MapFrom(customerDto => customerDto.id))
                .ForMember(customerCommand => customerCommand.contractorID,
                    opt => opt.MapFrom(customerDto => customerDto.contractorID))
                .ForMember(customerCommand => customerCommand.contractorStockID,
                    opt => opt.MapFrom(customerDto => customerDto.contractorStockID))
                .ForMember(customerCommand => customerCommand.contractorTechniquesID,
                    opt => opt.MapFrom(customerDto => customerDto.contractorTechniquesID));
        }
    }
}
