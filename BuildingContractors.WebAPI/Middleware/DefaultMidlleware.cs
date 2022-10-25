using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using BuildingContractor.WebAPI.Endpoints;
using MediatR;
using BuildingContractor.Application.ConctractorMaterials.Quieres.GetConctractorMaterialList;

namespace BuildingContractor.WebAPI.Middleware
{
    public class DefaultMidlleware
    {
        private readonly RequestDelegate _next;
        public DefaultMidlleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string path = context.Request.Path.Value.ToLower();
            var _mediator = context.RequestServices.GetService<IMediator>();
            string htmlString;

            switch (path)
            {
                default:
                    htmlString = Endpoints.Endpoint.Template("Index",
                    "<a href=\"/RepairingModels\">Contractor Materials</a>" +
                    "<a href=\"/Info\" class=\"bg-yellow\">Info</a>" +
                    "<a href=\"/SearchFaults\" class=\"bg-green\">Search Faults</a>" +
                    "<a href=\"/SearchRepairingModels\" class=\"bg-green\">Search Repairing Models</a>");
                    await context.Response.WriteAsync(htmlString);
                    break;
            }
        }
    }
}
