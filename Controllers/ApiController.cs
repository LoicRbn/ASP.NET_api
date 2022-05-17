using Microsoft.AspNetCore.Mvc;
using ASP.NET_api.Models;

namespace ASP.NET_api.Controllers
{

    public class ApiController : Controller
    {
        private readonly DatabaseContext Context;

        public ApiController(DatabaseContext context)
        {
            Context = context;
        }

        [Route("/getConso")]
        [HttpGet]
        public List<Conso> getConso()
        {
            return Context.getConso();
        }
        /*
        [HttpPost(Name = "/insertConso")]
        public */
    }
}
