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

        [Route("/getContenir")]
        [HttpGet]
        public List<Contenir> getContenir()
        {
            return Context.getContenir();
        }

        [Route("/getCommande")]
        [HttpGet]
        public List<Commande> getCommande()
        {
            return Context.getCommande();
        }
        
        [Route("/insertConso")]
        [HttpPost]
        public int insertConso(string nom)
        {
            return Context.insertConso(nom);
        }

        [Route("/initializeNewCommande")]
        [HttpPost]
        public int initializeNewCommande()
        {
            return Context.initializeNewCommande();
        }

        [Route("/createCommande")]
        [HttpPost]
        public int createCommande(int idcommande, int idconso, string etat)
        {
            return Context.createCommande(idcommande, idconso, etat);
        }

        [Route("/updateStateCommande")]
        [HttpPut]
        public int updateCommandState(int idcommande, int idconso, string etat)
        {
            return Context.updateCommandState(idcommande, idconso, etat);
        }


    }
}
