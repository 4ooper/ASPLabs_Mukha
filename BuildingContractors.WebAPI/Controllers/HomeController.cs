using Microsoft.AspNetCore.Mvc;
using MediatR;
using BuildingContractor.Application.Producers.Quieres.GetProducersList;

namespace BuildingContractor.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        public async Task<IActionResult> Index()
        {
            var query = new GetProducerListQuery();
            var vm = await Mediator.Send(query);
            return View(vm);
        }
    }
}
