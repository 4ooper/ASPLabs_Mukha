﻿using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.Producers.Quieres.GetProudersFilterList
{
    public class GetProducersFilterListLookupDto : IMapWith<Producer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Producer, GetProducersFilterListLookupDto>()
                .ForMember(recordDto => recordDto.Id, opt => opt.MapFrom(record => record.Id))
                .ForMember(recordDto => recordDto.Name, opt => opt.MapFrom(record => record.Name));
        }
    }
}