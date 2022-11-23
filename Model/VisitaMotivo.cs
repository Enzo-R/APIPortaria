using APIPortaria.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace APIPortaria.Model
{
    public class VisitaMotivo
    {
        public int IdMotivo { get; set; }
        public String Motivo { get; set; }

        public static async Task<List<VisitaMotivo>> GetVisitaMotivo()
        {
            List<VisitaMotivo> VM = new List<VisitaMotivo>();
            DataTable dt = await Utils.RetornaTabela("SELECT IdMotivo, Descricao FROM tbVisitas_Motivos", "");
            

           if (dt.Rows.Count != 0)
           {
                foreach(DataRow MotivoRow in dt.Rows)
                {
                    VisitaMotivo _motivo = new VisitaMotivo();
                    _motivo.IdMotivo = Convert.ToInt32(MotivoRow[0]);
                    _motivo.Motivo = Convert.ToString(MotivoRow[1]);
                    VM.Add(_motivo);

                }
           }
            return VM;
        }
    }
}