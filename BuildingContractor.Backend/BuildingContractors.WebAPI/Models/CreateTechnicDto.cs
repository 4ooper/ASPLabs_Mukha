using AutoMapper;
using BuildingContractor.WebAPI.Models;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.Technics.Commands.CreateTechnic;

namespace BuildingContractor.WebAPI.Models
{
    public class CreateTechnicDto : IMapWith<CreateTechnicCommand>
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Valid { get; set; }
        public ContractorDto Contractor { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTechnicDto, CreateTechnicCommand>()
                .ForMember(recordCommand => recordCommand.Name,
                    opt => opt.MapFrom(recordDto => recordDto.Name))
                .ForMember(recordCommand => recordCommand.CreationDate,
                    opt => opt.MapFrom(recordDto => recordDto.CreationDate))
                .ForMember(recordCommand => recordCommand.Valid,
                    opt => opt.MapFrom(recordDto => recordDto.Valid))
                .ForMember(recordCommand => recordCommand.ContractorId,
                    opt => opt.MapFrom(recordDto => recordDto.Contractor.Id));
        }
    }
}
