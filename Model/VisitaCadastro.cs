using APIPortaria.Model;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;
using APIPortaria.Data;
using APIPortaria.Controllers;

namespace APIPortaria.Model
{
    public class VisitaCadastro 
    {
        public int IdCadastro { get; set; }
        public int IdVisitante { get; set; }
        public int IdDestino { get; set; }
        public int IdMotivo { get; set; }
        public int IdResponsavel { get; set; }
        public String Detalhes { get; set; }
        public String OBS { get; set; }

        public async Task AddCadastro()
        {
            //Ao inves de usar um comando SQL chama a StoredProcedure
            String _sql = "spVisitaCadastro";
            VisitaDestino vd = new VisitaDestino();

            using (SqlConnection conn = new SqlConnection(Connect.ConnectionString))
            {
                conn.Open();

                using(SqlCommand _Command = new SqlCommand(_sql, conn))
                {
                    //CommandTypeText para usar sp dentro do projeto
                    _Command.CommandType = CommandType.StoredProcedure; 

                    _Command.Parameters.Add("@Identity", SqlDbType.Int).Value = 0;
                    _Command.Parameters.Add("@IdVisitante", SqlDbType.Int).Value = IdVisitante;
                    _Command.Parameters.Add("@IdSetor", SqlDbType.Int).Value = IdDestino;
                    _Command.Parameters.Add("@IdMotivo", SqlDbType.Int).Value = IdMotivo;
                    _Command.Parameters.Add("@IdResponsavel", SqlDbType.Int).Value = IdResponsavel;
                    _Command.Parameters.Add("@Detalhe", SqlDbType.VarChar, 5000).Value = Detalhes;
                    _Command.Parameters.Add("@Observacao", SqlDbType.VarChar, 5000).Value = OBS;


                    _Command.Parameters.Add("@DataCadastro", SqlDbType.DateTime).Value = DateTime.Now;
                    _Command.Parameters.Add("@dtEntrada", SqlDbType.DateTime).Value = DateTime.Now;
                    _Command.Parameters.Add("@dtSaida", SqlDbType.DateTime).Value = DBNull.Value;


                    object Call = await _Command.ExecuteScalarAsync();
                    IdCadastro = Int32.Parse(Call.ToString());
                }

            }
        }
    }

}
