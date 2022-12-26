using AutoMapper;
using System;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.Buildings.Commands.UpdateBuilding;

namespace BuildingContractor.WebAPI.Models
{
    public class UpdateBuildingDto : IMapWith<UpdateBuildingCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CustomerDto Customer { get; set; }
        public ContractorDto Contractor { get; set; }
        public DateTime ConclusionDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime ComissioningDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateBuildingDto, UpdateBuildingCommand>()
                .ForMember(recordCommand => recordCommand.Id,
                    opt => opt.MapFrom(recordDto => recordDto.Id))
                .ForMember(recordCommand => recordCommand.Name,
                    opt => opt.MapFrom(recordDto => recordDto.Name))
                .ForMember(recordCommand => recordCommand.CustomerId,
                    opt => opt.MapFrom(recordDto => recordDto.Customer.Id))
                .ForMember(recordCommand => recordCommand.ContractorId,
                    opt => opt.MapFrom(recordDto => recordDto.Contractor.Id))
                .ForMember(recordCommand => recordCommand.ConclusionDate,
                    opt => opt.MapFrom(recordDto => recordDto.ConclusionDate))
                .ForMember(recordCommand => recordCommand.DeliveryDate,
                    opt => opt.MapFrom(recordDto => recordDto.DeliveryDate))
                .ForMember(recordCommand => recordCommand.ComissioningDate,
                    opt => opt.MapFrom(recordDto => recordDto.ComissioningDate));
        }
    }
}
