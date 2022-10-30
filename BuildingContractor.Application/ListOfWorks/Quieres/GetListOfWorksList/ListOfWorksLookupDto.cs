using AutoMapper;
using BuildingContractor.Application.Common.Mappings;
using BuildingContractor.Domain;

namespace BuildingContractor.Application.ListOfWorks.Quieres.GetListOfWorksList
{
    public class ListOfWorksLookupDto : IMapWith<listOfWork>
    {
        public int id { get; set; }
        public string name { get; set; }
        public License license { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<listOfWork, ListOfWorksLookupDto>()
                .ForMember(listOfWorkDto => listOfWorkDto.id, opt => opt.MapFrom(listOfWork => listOfWork.id))
                .ForMember(listOfWorkDto => listOfWorkDto.name, opt => opt.MapFrom(listOfWork => listOfWork.name))
                .ForMember(listOfWorkDto => listOfWorkDto.license, opt => opt.MapFrom(listOfWork => listOfWork.license));
        }
    }
}
