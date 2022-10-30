using Microsoft.AspNetCore.Mvc;
using MediatR;
using BuildingContractor.Application.AboutContractor.Quieres.GetAboutContractorList;

namespace BuildingContractor.WebAPIMVC.Controllers
{
    public class AboutContractorController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 284)]
        public async Task<IActionResult> Index()
        {
            var query = new GetAboutContractorListQuery();
            var vm = await Mediator.Send(query);
            return View(vm);
        }
    }
}
