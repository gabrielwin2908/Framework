using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Projeto_Framework.Controllers
{
    public class TodosController : Controller
    {
        public IActionResult Index()
        {
            string sTabela = "";

            var client = new RestClient("https://jsonplaceholder.typicode.com/");

            var request = new RestRequest("todos");

            var response = client.Get(request);

            JArray resposta = (JArray)JsonConvert.DeserializeObject(response.Content);

            foreach (JObject trabalho in resposta)
            {
                sTabela += "<tr>";
                sTabela += "<td>";
                sTabela += trabalho["userId"];
                sTabela += "</td>";
                sTabela += "<td>";
                sTabela += trabalho["id"];
                sTabela += "</td>";
                sTabela += "<td>";
                sTabela += trabalho["title"];
                sTabela += "</td>";
                sTabela += "<td>";
                sTabela += trabalho["completed"];
                sTabela += "</td>";
                sTabela += "</tr>";


            }

            ViewBag.projeto = sTabela;

            return View();
        }
    }
}