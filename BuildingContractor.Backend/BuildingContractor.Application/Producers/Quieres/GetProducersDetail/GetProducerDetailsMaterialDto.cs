using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;
using AutoMapper;

namespace BuildingContractor.Application.Producers.Quieres.GetProducersDetail
{
    public class GetProducerDetailsMaterialDto : IMapWith<Material>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Valid { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Material, GetProducerDetailsMaterialDto>()
                .ForMember(recordVm => recordVm.Id, opt => opt.MapFrom(record => record.Id))
                .ForMember(recordVm => recordVm.Name, opt => opt.MapFrom(record => record.Name))
                .ForMember(recordVm => recordVm.CreationDate, opt => opt.MapFrom(record => record.CreationDate))
                .ForMember(recordVm => recordVm.Valid, opt => opt.MapFrom(record => record.Valid));
        }
    }
}
