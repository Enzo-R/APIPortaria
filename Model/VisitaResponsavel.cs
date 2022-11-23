using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using APIPortaria.Data;

namespace APIPortaria.Model
{
    public class VisitaResponsavel
    {
        public int IdResponsavel { get; set; }
        public String Responsavel { get; set; }

        public async static Task<List<VisitaResponsavel>> GetVisitaResponsavel()
        {
            List<VisitaResponsavel> VR = new List<VisitaResponsavel>();
            DataTable dt = await Utils.RetornaTabela("SELECT IdResponsavel, Nome FROM tbVisitas_Responsaveis", "Nome");
            

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow VisitanteRow in dt.Rows)
                {
                    VisitaResponsavel _Responsavel = new();
                    _Responsavel.IdResponsavel = Convert.ToInt32(VisitanteRow[0]);
                    _Responsavel.Responsavel = Convert.ToString(VisitanteRow[1]);
                    VR.Add(_Responsavel);
                }
            }
            return VR;
        }
    }
}
