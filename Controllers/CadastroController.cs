using APIPortaria.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPortaria.Controllers
{
    
    [ApiController]
    public class CadastroController : ControllerBase
    {

        [HttpPost]
        [Route("api/[controller]/AddCadastro")]
        public async Task<VisitaCadastro> GetCadastro(VisitaCadastro vc)
        {
            await vc.AddCadastro();
            return vc;
        }
    }
}
