using BuildingContractor.Application.Customers.Quieres.GetCustomerList;
using BuildingContractor.Application.Customers.Quieres.GetCustomerDetails;
using BuildingContractor.Application.Customers.Quieres.GetCustomerSearchList;
using BuildingContractor.Application.Customers.Quieres.GetCustomerFilterList;
using Microsoft.AspNetCore.Mvc;
using BuildingContractor.Application.Customers.Commands.CreateCustomer;
using BuildingContractor.Application.Customers.Commands.UpdateCustomer;
using BuildingContractor.Application.Customers.Commands.DeleteCustomer;
using BuildingContractor.WebAPI.Models;
using AutoMapper;

namespace BuildingContractor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : BaseController
    {
        private readonly IMapper _mapper;

        public CustomerController(IMapper mapper) => _mapper = mapper;

        [HttpGet("[action]/")]
        public async Task<ActionResult<CustomerListVm>> GetAll([FromQuery] int page)
        {
            var query = new GetCustomerListQuery { Page = page >= 0 ? page : 0 };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("[action]/")]
        public async Task<ActionResult<GetCustomerFilterListVm>> Filter([FromQuery] int page, string? prop, string? value)
        {
            var query = new GetCustomerFilterListQuery
            {
                Page = page >= 0 ? page : 0,
                SortProp = prop,
                SortValue = value
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("[action]/")]
        public async Task<ActionResult<GetCustomerSearchListVm>> Search([FromQuery] string searchText, [FromQuery] int page = -1)
        {
            var query = new GetCustomerSearchListQuery { Page = page, SearchText = searchText };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}/")]
        public async Task<ActionResult<CustomerDetailsVm>> Get(int id)
        {
            var query = new GetCustomersDetailsQuery
            {
                Id = id
            };
            try
            {
                var vm = await Mediator.Send(query);
                return Ok(vm);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateCustomerDto createCustomerDto)
        {
            var command = _mapper.Map<CreateCustomerCommand>(createCustomerDto);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerDto updateCustomerDto)
        {
            var command = _mapper.Map<UpdateCustomerCommand>(updateCustomerDto);
            try
            {
                await Mediator.Send(command);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCustomerCommand
            {
                Id = id,
            };
            try
            {
                await Mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
