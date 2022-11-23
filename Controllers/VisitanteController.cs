using APIPortaria.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPortaria.Controllers
{

    [ApiController]
    public class VisitanteController : ControllerBase
    {

        [HttpPost]
        [Route("api/[controller]/AddVisitante")]
        public async Task<Visitante> AddVisitante(Visitante v)
        {
            await v.AddVisitante();
            return v;
        }

        [HttpDelete]
        [Route("api/[controller]/DelVisitante")]
        public async Task<Visitante> DelVisitante(int IdVisitante)
        {
            Visitante v = new Visitante();
            v.IdVisitante = IdVisitante;
            await v.DelVisitante();
            return v;
        }

        [HttpPut]
        [Route("api/[controller]/PutVisitante")]
        public async Task<Visitante> PutVisitante(Visitante v)
        {

            await v.PutVisitante();
            return v;
        }



    }
}
