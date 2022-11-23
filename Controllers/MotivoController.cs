using APIPortaria.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPortaria.Controllers
{
    
    [ApiController]
    public class MotivoController : ControllerBase
    {
        [HttpGet]
        [Route("api/[controller]/GetMotivo")]
        public async  Task<List<VisitaMotivo>> GetVisitaMotivo()
        {
            List<VisitaMotivo> temp = await VisitaMotivo.GetVisitaMotivo();
            return temp;
        }

    }
}
