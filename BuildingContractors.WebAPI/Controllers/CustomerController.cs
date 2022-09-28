﻿using BuildingContractor.Application.Customers.Quieres.GetCustomerList;
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
    public class CustomerController : BaseController
    {
        private readonly IMapper _mapper;

        public CustomerController(IMapper mapper) => _mapper = mapper;

        [HttpGet("[action]/")]
        public async Task<ActionResult<CustomerListVm>> GetAll()
        {
            var query = new GetCustomerListQuery();
            var vm = await Mediator.Send(query);
            Console.WriteLine(vm);
            return Ok(vm);
        }

        [HttpGet("{id}/")]
        public async Task<ActionResult<CustomerListVm>> Get(int id)
        {
            var query = new GetCustomersDetailsQuery
            {
                id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromForm] CreateCustomerDto createCustomerDto)
        {
            var command = _mapper.Map<CreateCustomerCommand>(createCustomerDto);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateCustomerDto updateCustomerDto)
        {
            var command = _mapper.Map<UpdateCustomerCommand>(updateCustomerDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCustomerCommand
            {
                id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
