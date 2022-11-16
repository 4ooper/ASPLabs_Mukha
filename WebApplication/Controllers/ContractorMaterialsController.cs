using Microsoft.AspNetCore.Mvc;
using MediatR;
using BuildingContractor.Application.ConctractorMaterials.Quieres.GetConctractorMaterialList;
using BuildingContractor.Application.Producers.Quieres.GetProducersList;
using BuildingContractor.Application.ConctractorMaterials.Commands.CreateContractorMaterial;
using BuildingContractor.Application.ConctractorMaterials.Quieres.GetContractorMaterialDetails;
using BuildingContractor.Application.ConctractorMaterials.Commands.DeleteContractorMaterial;
using WebApplication.Models;
using BuildingContractor.Domain;
using System.Dynamic;
using BuildingContractor.Application.ConctractorMaterials.Commands.UpdateContractorMaterial;

namespace WebApplication.Controllers
{
    public class ContractorMaterialsController : Controller
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
            var query = new GetConctractorMaterialListQuery { page = page > 0 ? page : 1, url = Request.Host };
            var vm = await Mediator.Send(query);
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new GetProducerListQuery();
            var vm = await Mediator.Send(query);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateContractorMaterialDto createMaterial)
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new CreateContractorMaterialCommand
            {
                name = createMaterial.name,
                createdDate = createMaterial.createdDate,
                validaty = createMaterial.validaty,
                producer = new Producer { id = createMaterial.producer }
            };
            var cvm = await Mediator.Send(query);
            return Redirect("/contractormaterials");
        }

        [HttpGet]
        public async Task<IActionResult> Detail([FromQuery] int id)
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var detailQuery = new GetContractorMaterialDetailsQuery
            {
                id = id
            };
            var detailVm = await Mediator.Send(detailQuery);
            var producerListQuery = new GetProducerListQuery();
            var producerListVm = await Mediator.Send(producerListQuery);
            dynamic model = new ExpandoObject();
            model.detail = detailVm;
            model.producers = producerListVm.producers;
            return View(model);
        }

        public async Task<IActionResult> Update([FromForm] UpdateContractorMaterialsDto updateContractorMaterials)
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new UpdateContractorMaterialCommand
            {
                id = updateContractorMaterials.id,
                name = updateContractorMaterials.name,
                createdDate = updateContractorMaterials.createdDate,
                validaty = updateContractorMaterials.validaty,
                ProducerID = updateContractorMaterials.producer
            };
            await Mediator.Send(query);
            return Redirect("/contractormaterials");
        }

        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var user = HttpContext.Items["User"];
            if (IsUserExist((User)HttpContext.Items["User"]) == false)
            {
                return Redirect("/account");
            }
            var query = new DeleteContractorMaterialCommand
            {
                id = id
            };
            var deleteVm = await Mediator.Send(query);
            return Redirect("/contractormaterials");
        }

        private bool IsUserExist(User user)
        {
            return user == null ? false : true;
        }
    }
}
