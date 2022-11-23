using APIPortaria.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPortaria.Controllers
{

    [ApiController]
    public class DestinoController : ControllerBase
    {
        [HttpGet]
        [Route("api/[controller]/GetDestino")]
        public async Task<List<VisitaDestino>> Get()
        {
            List<VisitaDestino> temp = await VisitaDestino.GetVisitaDestino();
            return temp;
        }
      


    }
}
