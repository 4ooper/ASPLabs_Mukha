using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MediatR;
using BuildingContractor.Application.Contractors.Quieres.GetContractorList;
using BuildingContractor.Application.Contractors.Quieres.GetContractorSearchList;
using BuildingContractor.Application.Contractors.Commands.CreateContractor;
using BuildingContractor.Application.Contractors.Commands.UpdateContractor;
using BuildingContractor.Application.Contractors.Commands.DeleteContractor;
using BuildingContractor.Application.Contractors.Quieres.GetContractorDetails;
using WebApplication.Models;
using BuildingContractor.Domain;
using BuildingContractor.Application.Users.Quieres.GetUsersList;

namespace WebApplication.Controllers
{
    public class ContractorsController : Controller
    {
        private readonly IMapper _mapper;
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        public ContractorsController(IMapper mapper) => _mapper = mapper;

        public async Task<IActionResult> Index([FromQuery] int page)
        {
            var user = HttpContext.Items["User"];
            if(IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new GetContractorListQuery { page = page > 0 ? page  : 1, url = Request.Host };
            var vm = await Mediator.Send(query);
            return View(vm);
        }

        public async Task<IActionResult> Search([FromQuery] string searchString, [FromQuery] int page)
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            Response.Cookies.Append("lastSearch", searchString);
            var query = new GetContractorSearchListQuery
            {
                searchText = searchString,
                url = Request.Host,
                page = page > 0 ? page : 1,
            };
            var vm = await Mediator.Send(query);
            return View(vm);
        } 

        [HttpGet]
        public IActionResult Create()
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateContractorDto createContractor)
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new CreateContractorCommand
            {
                name = createContractor.name
            };
            var cvm = await Mediator.Send(query);
            return Redirect("/contractors");
        }

        [HttpGet]
        public async Task<IActionResult> Detail([FromQuery] int id)
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new GetContractorDetailsQuery
            {
                id = id
            };
            var vm = await Mediator.Send(query);
            return View(vm);
        }

        public async Task<IActionResult> Update([FromForm] UpdateContractorDto updateContractor)
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new UpdateContractorCommand
            {
                id = updateContractor.id,
                name = updateContractor.name
            };
            var vm = await Mediator.Send(query);
            return Redirect("/contractors");
        }

        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new DeleteContractorCommand
            {
                id = id
            };
            var vm = await Mediator.Send(query);
            return Redirect("/contractors");
        }

        private bool IsUserExist(User user)
        {
            return user == null ? false : true;
        }
    }
}
