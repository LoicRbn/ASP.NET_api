﻿using Microsoft.AspNetCore.Mvc;
using ASP.NET_api.Models;

namespace ASP.NET_api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ApiController : Controller
    {
        private readonly DatabaseContext Context;

        public ApiController(DatabaseContext context)
        {
            Context = context;
        }
        [HttpGet(Name = "/getId")]
        public List<int> getId()
        {
            return Context.getId();
        }
    }
}