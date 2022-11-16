using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using MediatR;
using BuildingContractor.Application.ContractorTechnique.Quieres.GetContractorTechniqueList;
using BuildingContractor.Application.ContractorTechnique.Commands.CreateContractorTechnique;
using BuildingContractor.Application.ContractorTechnique.Quieres.GetContractorTechniqueDetails;
using BuildingContractor.Application.ContractorTechnique.Commands.UpdateContractorTechnique;
using BuildingContractor.Application.ContractorTechnique.Commands.DeleteContractorTechnique;
using BuildingContractor.Domain;

namespace WebApplication.Controllers
{
    public class ContractorTechniqueController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        public async Task<IActionResult> Index([FromQuery] int page)
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new GetContractorTechniqueListQuery { page = page > 0 ? page : 1, url = Request.Host };
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
        public async Task<IActionResult> Create([FromForm] CreateContractorTechniqueDto createContractorTechnique)
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new CreateContractorTechniqueCommand
            {
                name = createContractorTechnique.name,
                buyDate = createContractorTechnique.buyDate,
                validaty = createContractorTechnique.validaty
            };
            var vm = await Mediator.Send(query);
            return Redirect("/contractortechnique");
        }

        [HttpGet]
        public async Task<IActionResult> Detail([FromQuery] int id)
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new GetContractorTechniqueDetailsQuery
            {
                id = id
            };
            var vm = await Mediator.Send(query);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UpdateContractorTechniqueDto updateContractorTechnique)
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new UpdateContractorTechniqueCommand
            {
                id = updateContractorTechnique.id,
                name = updateContractorTechnique.name,
                buyDate = updateContractorTechnique.buyDate,
                validaty = updateContractorTechnique.validaty
            };
            var vm = await Mediator.Send(query);
            return Redirect("/contractortechnique");
        }

        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new DeleteContractorTechniqueCommand
            {
                id = id
            };
            var vm = await Mediator.Send(query);
            return Redirect("/contractortechnique");
        }

        private bool IsUserExist(User user)
        {
            return user == null ? false : true;
        }
    }
}
