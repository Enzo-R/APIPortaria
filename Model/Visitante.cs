using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using APIPortaria.Data;

namespace APIPortaria.Model
{
    public class Visitante
    {
        public int IdVisitante { get; set; }
        public String Nome { get; set; }
        public String Documento { get; set; }
        public String Contato { get; set; }

        public async Task AddVisitante()
        {
            String _sql = "spVisitaAddVisitante";

            using (SqlConnection conn = new SqlConnection(Connect.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(_sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Identity", SqlDbType.Int).Value = 0;
                    cmd.Parameters.Add("@Nome", SqlDbType.VarChar, 60).Value = Nome;
                    cmd.Parameters.Add("@Documento", SqlDbType.VarChar, 25).Value = Documento;
                    cmd.Parameters.Add("@Contato", SqlDbType.VarChar, 30).Value = Contato;

                    object Call = await cmd.ExecuteScalarAsync();
                    IdVisitante = Int32.Parse(Call.ToString());
                }

            }
        }

        public async Task DelVisitante()
        {
            String _sql = "spVisitaDelVisitante";

            using (SqlConnection conn = new SqlConnection(Connect.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(_sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IdVisitante", SqlDbType.Int).Value = IdVisitante;

                    object Call = await cmd.ExecuteScalarAsync();
                }

            }
        }

        public async Task PutVisitante()
        {
            String _sql = "spVisitaPutVisitante";

            using (SqlConnection conn = new SqlConnection(Connect.ConnectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(_sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IdVisitante", SqlDbType.Int).Value = IdVisitante;
                    cmd.Parameters.Add("@Nome", SqlDbType.VarChar, 60).Value = Nome;
                    cmd.Parameters.Add("@Documento", SqlDbType.VarChar, 25).Value = Documento;
                    cmd.Parameters.Add("@Contato", SqlDbType.VarChar, 30).Value = Contato;

                    object Call = await cmd.ExecuteScalarAsync();
                }

            }
        }
    }
}