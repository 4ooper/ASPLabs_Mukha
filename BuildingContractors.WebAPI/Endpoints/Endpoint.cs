using BuildingContractor.Application.ConctractorMaterials.Quieres.GetConctractorMaterialList;
using Microsoft.AspNetCore.Mvc;
using BuildingContractor.WebAPI.Models;
using AutoMapper;
using MediatR;
using BuildingContractor.Persistence;

namespace BuildingContractor.WebAPI.Endpoints
{
    public static class Endpoint
    {
        private readonly static string _styles = "<style>" +
            "a {display: block; padding: 5px 10px 5px 10px; font-size: 130%; " +
            "background-color: #BBF4FF; text-decoration: none; color: black;" +
            "margin-top: 10px; border-radius: 5px;}" +
            "body {display:flex; flex-direction:column; align-items: center; align-items:center;}" +
            "h1 {text-align: center;}" +
            ".bg-yellow {background-color: #ebeb34;}" +
            ".bg-green {background-color: #34eb3a;}" +
            ".bg-red {background-color: red; }" +
            "</style>";

        public static string Template(string title, string body)
        {
            return "<html><head>" +
                $"<title>{title}</title>" +
                "<meta charset=\"utf-8\" />" +
                _styles +
                "</head><body>" +
                $"<h1>{title}</h1>{body}" +
                "</body></html>";
        }

        public static void Info(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync(Template("Info",
                    "<script type = \"text/javascript\"> " +
                    "var code = navigator.appCodeName;" +
                    "var name = navigator.appName;" +
                    "var vers = navigator.appVersion; " +
                    "var platform = navigator.platform;" +
                    "var cook = navigator.cookieEnabled;" +
                    "var je = navigator.javaEnabled();" +
                    "var ua = navigator.userAgent;" +
                    "document.write('Браузер: ' + name + " +
                    "'<br />Версия браузера: ' + vers +" +
                    "'<br />Кодовое название браузера: ' + code +" +
                    "'<br />Платформа: ' + platform +" +
                    "'<br />Поддержка cookie: ' + cook +" +
                    "'<br />Поддержка JavaScript: ' + je +" +
                    "'<br />userAgent: ' + ua);" +
                    "</script>" +
                    "<a href=\"/\">Back</a><br>"));
            });
        }

        public static void ContractorMaterials(IApplicationBuilder app)
        {
            app.Run(async context =>
            {

                var mediator = context.RequestServices.GetService<IMediator>();
                var query = new GetConctractorMaterialListQuery
                {
                    cacheKey = "contractormaterials"
                };
                var vm = mediator.Send(query).Result.conctractorMaterials;

                string htmlString =
                    "<a href=\"/\">Back</a><br>" +
                    "<table border=1>" +
                    "<tr>" +
                    "<th>Id</th>" +
                    "<th>Name</th>" +
                    "<th>CreateDate</th>" +
                    "<th>Validaty</th>" +
                    "<th>Producer id</th>" +
                    "<th>Producer name</th>" +
                    "</tr>";

                foreach (var item in vm)
                {
                    htmlString += "<tr>" +
                                $"<td>{item.id}</td>" +
                                $"<td>{item.name}</td>" +
                                $"<td>{item.createdDate}</td>" +
                                $"<td>{item.validaty}</td>" +
                                $"<td>{item.producer.id}</td>" +
                                $"<td>{item.producer.name}</td>" +
                                "</tr>";
                }

                htmlString += "</table>";

                await context.Response.WriteAsync(Template("ContractorMaterials", htmlString));
            });
        }

        public static void FirstSearch(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var mediator = context.RequestServices.GetService<IMediator>();
                var query = new GetConctractorMaterialListQuery();
                var vm = mediator.Send(query).Result.conctractorMaterials;

                string keyName = "Name";
                string keySelect = "Select";
                string keyMultiselect = "MultiSelect";
                string test = context.Request.Cookies[keyName];
                string htmlString =
                    "<a href=\"/\">Back</a><br>" +
                    "<form>" +
                    $"<input id=\"name-input\" type=\"text\" name=\"Name\" placeholder=\"Name\" " +
                    $"value=\"{context.Request.Cookies[keyName]}\"/><br><br>" +
                    $"<select name=\"{keySelect}\"><option>Default</option>";


                foreach (var item in vm)
                {
                    if ($"{item.name} ({item.id})" == context.Request.Cookies[keySelect])
                        htmlString += $"<option selected>{item.name} ({item.id})</option>";
                    else
                        htmlString += $"<option>{item.name} ({item.id})</option>";
                }

                htmlString += $"</select><br><br><select multiple name=\"{keyMultiselect}\" size=\"10\">";

                string[] selectedItemsArr = { };
                if (context.Request.Cookies[keyMultiselect] is not null)
                    selectedItemsArr = context.Request.Cookies[keyMultiselect].Split(',');

                foreach (var elem in vm)
                {
                    bool isContains = false;
                    foreach (var item in selectedItemsArr)
                    {
                        if ($"{elem.name} ({elem.id})" == item)
                        {
                            isContains = true;
                            break;
                        }
                    }

                    if (isContains)
                        htmlString += $"<option selected>{elem.name} ({elem.id})</option>";
                    else
                        htmlString += $"<option>{elem.name} ({elem.id})</option>";
                }

                htmlString += "</select><br><br>" +
                    "<button type=\"submit\">Search</button>" +
                    "</form>";

                string name = context.Request.Query[keyName];
                string selected = context.Request.Query[keySelect];
                string multiselected = context.Request.Query[keyMultiselect];

                if (name is not null)
                    context.Response.Cookies.Append(keyName, name);

                if (selected is not null)
                    context.Response.Cookies.Append(keySelect, selected);

                if (multiselected is not null)
                    context.Response.Cookies.Append(keyMultiselect, multiselected);

                await context.Response.WriteAsync(Endpoints.Endpoint.Template("Search Form 1", htmlString));
            });
        }

        public static void SecondSearch(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var mediator = context.RequestServices.GetService<IMediator>();
                var query = new GetConctractorMaterialListQuery();
                var vm = mediator.Send(query).Result.conctractorMaterials;

                string keyName = "Name";
                string keySelect = "Select";
                string keyMultiselect = "MultiSelect";

                string htmlString =
                    "<a href=\"/\">Back</a><br>" +
                    "<form>" +
                    $"<input id=\"name-input\" type=\"text\" name=\"{keyName}\" placeholder=\"Name\" " +
                    $"value=\"{context.Session.GetString(keyName)}\"/><br><br>" +
                    $"<select name=\"{keySelect}\"><option>Default</option>";

                foreach (var rm in vm)
                {
                    if ($"{rm.name} ({rm.id})" == context.Session.GetString(keySelect))
                        htmlString += $"<option selected>{rm.name} ({rm.id})</option>";
                    else
                        htmlString += $"<option>{rm.name} ({rm.id})</option>";
                }

                htmlString += $"</select><br><br><select multiple name=\"{keyMultiselect}\" size=\"10\">";

                string[] selectedItemsArr = { };
                if (context.Session.GetString(keyMultiselect) is not null)
                    selectedItemsArr = context.Session.GetString(keyMultiselect).Split(',');

                foreach (var rm in vm)
                {
                    bool isContains = false;
                    foreach (var item in selectedItemsArr)
                    {
                        if ($"{rm.name} ({rm.id})" == item)
                        {
                            isContains = true;
                            break;
                        }
                    }

                    if (isContains)
                        htmlString += $"<option selected>{rm.name} ({rm.id})</option>";
                    else
                        htmlString += $"<option>{rm.name} ({rm.id})</option>";
                }

                htmlString += "</select><br><br>" +
                    "<button type=\"submit\">Search</button>" +
                    "</form>";

                string name = context.Request.Query[keyName];
                string selected = context.Request.Query[keySelect];
                string multiselected = context.Request.Query[keyMultiselect];

                if (name is not null)
                    context.Session.SetString(keyName, name);

                if (selected is not null)
                    context.Session.SetString(keySelect, selected);

                if (multiselected is not null)
                    context.Session.SetString(keyMultiselect, multiselected);

                await context.Response.WriteAsync(Endpoints.Endpoint.Template("Search Form 2", htmlString));
            });
        }
    }
}
