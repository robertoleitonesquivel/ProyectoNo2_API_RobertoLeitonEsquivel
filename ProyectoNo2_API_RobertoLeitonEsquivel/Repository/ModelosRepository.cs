using MODELS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MODELS.Models.Contracts;

namespace ProyectoNo2_API_RobertoLeitonEsquivel.Repository
{
    public class ModelosRepository : MasterRepository, IModelo
    {
        public async Task<List<Modelos>> GetByMarca(int _IdMarca)
        {
            var list = new List<Modelos>();

            using (var con = GetConection())
            {
                await con.OpenAsync();

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT Id,Name FROM ModeloAviones WHERE IdMarca = @Id";
                    cmd.Parameters.Add("@Id",SqlDbType.Int).Value = _IdMarca;
                    cmd.CommandType = CommandType.Text;
                    var result = await cmd.ExecuteReaderAsync();
                    while (result.Read())
                    {
                        list.Add(new Modelos()
                        {
                            Id = result.GetInt32(0),
                            Name = result.GetString(1),
                        });
                    }
                }
            }

            return list;
        }
    }
}