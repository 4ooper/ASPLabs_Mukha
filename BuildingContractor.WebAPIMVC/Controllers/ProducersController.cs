using Microsoft.AspNetCore.Mvc;
using MediatR;
using BuildingContractor.Application.Producers.Quieres.GetProducersList;

namespace BuildingContractor.WebAPIMVC.Controllers
{
    public class ProducersController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 284)]
        public async Task<IActionResult> Index()
        {
            var query = new GetProducerListQuery();
            var vm = await Mediator.Send(query);
            return View(vm);
        }
    }
}
