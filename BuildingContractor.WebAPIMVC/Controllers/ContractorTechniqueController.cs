using Microsoft.AspNetCore.Mvc;
using MediatR;
using BuildingContractor.Application.ContractorTechnique.Quieres.GetContractorTechniqueList;


namespace BuildingContractor.WebAPIMVC.Controllers
{
    public class ContractorTechniqueController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 284)]
        public async Task<IActionResult> Index()
        {
            var query = new GetContractorTechniqueListQuery();
            var vm = await Mediator.Send(query);
            return View(vm);
        }
    }
}
