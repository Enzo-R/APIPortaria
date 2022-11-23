using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace APIPortaria.Data
{
    //classe responsavel por fazer o uso do DB
    public static class Utils
    {
        public static async Task<DataTable> RetornaTabela(String SqlComands, String order = "")
        {
            DataTable dt = new DataTable();
            String _sql = SqlComands;
            if (order != "") _sql += " ORDER BY " + order;

            //MODELO ADO.NET DataSet: SqlConnection, SqlCommand, SqlDataReader - http://www.macoratti.net/08/11/c_adn_1.htm

            using (SqlConnection conn = new SqlConnection(Connect.ConnectionString))
            {
                conn.Open();

                using (SqlCommand _Command = new SqlCommand(_sql, conn))
                {
                    _Command.CommandType = CommandType.Text;
                    SqlDataReader dataReader;
                    using (dataReader = await _Command.ExecuteReaderAsync())
                    {
                        dt.Load(dataReader);
                        dataReader.Close();

                    }
                }
                conn.Close();
            }

            return dt;
        }

    }
}
