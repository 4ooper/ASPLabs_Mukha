using BuildingContractor.Application.ListOfWorks.Quieres.GetListOfWorksList;
using BuildingContractor.Application.Customers.Quieres.GetCustomerDetails;
using Microsoft.AspNetCore.Mvc;
using BuildingContractor.Application.Customers.Commands.CreateCustomer;
using BuildingContractor.Application.Customers.Commands.UpdateCustomer;
using BuildingContractor.Application.Customers.Commands.DeleteCustomer;
using BuildingContractor.WebAPI.Models;
using AutoMapper;


namespace BuildingContractor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ListOfWorksController : BaseController
    {
        private readonly IMapper _mapper;

        public ListOfWorksController(IMapper mapper) => _mapper = mapper;

        [HttpGet("[action]/")]
        public async Task<ActionResult<ListOfWorksVm>> GetAll()
        {
            var query = new GetListOfWorksQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
