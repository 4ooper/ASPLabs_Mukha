using AutoMapper;
using System;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Application.Customers.Commands.UpdateCustomer;

namespace BuildingContractor.WebAPI.Models
{
    public class UpdateCustomerDto : IMapWith<UpdateCustomerCommand>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }

        public void Mapping(Profile profile)
        {
            try
            {
                profile.CreateMap<UpdateCustomerDto, UpdateCustomerCommand>()
                .ForMember(customerCommand => customerCommand.id,
                    opt => opt.MapFrom(customerDto => customerDto.id))
                .ForMember(customerCommand => customerCommand.name,
                    opt => opt.MapFrom(customerDto => customerDto.name))
                .ForMember(customerCommand => customerCommand.surname,
                    opt => opt.MapFrom(customerDto => customerDto.surname));
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception");
            }
        }
    }
}
