using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MediatR;
using BuildingContractor.Application.Users.Commands.CreateUser;
using BuildingContractor.Application.Users.Commands.SignInUser; 
using BuildingContractor.Domain;
using BuildingContractor.WebAPI.Models;

namespace BuildingContractor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        [HttpPost("[action]/")]
        public async Task<ActionResult<string>> Create([FromBody] CreateUserDto createUser)
        {
            var query = new CreateUserCommand
            {
                Login = createUser.Login,
                Password = createUser.Password
            };
            var cvm = await Mediator.Send(query);
            return Ok(cvm);
        }

        [HttpPost("[action]/")]
        public async Task<ActionResult<string>> SignIn([FromBody] CreateUserDto signInUserDto)
        {
            var query = new SignInUserCommand
            {
                Login = signInUserDto.Login,
                Password = signInUserDto.Password
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        private bool CanAccept(User user)
        {
            if (user == null || user.RoleId != 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
