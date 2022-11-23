using APIPortaria.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPortaria.Controllers
{
    [ApiController]
    public class ResponsavelController : ControllerBase
    {
        [HttpGet]
        [Route("api/[controller]/GetResponsavel")]
        public async Task<List<VisitaResponsavel>> GetVisitaResponsavel()
        {
            return await VisitaResponsavel.GetVisitaResponsavel();
        }

    }
}
