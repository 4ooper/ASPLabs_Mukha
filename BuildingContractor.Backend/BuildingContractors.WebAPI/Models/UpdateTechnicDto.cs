using AutoMapper;
using BuildingContractor.WebAPI.Models;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.Technics.Commands.UpdateTechnic;

namespace BuildingContractor.WebAPI.Models
{
    public class UpdateTechnicDto : IMapWith<UpdateTechnicCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Valid { get; set; }
        public ContractorDto Contractor { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTechnicDto, UpdateTechnicCommand>()
                .ForMember(recordCommand => recordCommand.Id,
                    opt => opt.MapFrom(recordDto => recordDto.Id))
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
