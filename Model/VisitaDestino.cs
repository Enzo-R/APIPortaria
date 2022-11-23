using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using APIPortaria.Data;

namespace APIPortaria.Model
{
    public class VisitaDestino
    {
        public int IdDestino { get; set; }
        public String Destino { get; set; }

        public static async Task<List<VisitaDestino>> GetVisitaDestino()
        {
            List<VisitaDestino> VD = new List<VisitaDestino>();
            DataTable dt = await Utils.RetornaTabela("SELECT IdSetor, Descricao FROM tbVisitas_Setores", "Descricao");
          
            if (dt.Rows.Count != 0 )
            {
                foreach (DataRow DestinoRow in dt.Rows)
                {
                    VisitaDestino destino = new VisitaDestino();
                    destino.IdDestino = Convert.ToInt32(DestinoRow[0]);
                    destino.Destino = Convert.ToString(DestinoRow[1]);
                    VD.Add(destino);
                }
              
            }

            return VD;
        }
    }
}
