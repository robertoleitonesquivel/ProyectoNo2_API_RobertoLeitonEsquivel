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
    public class MarcasRepository : MasterRepository, IMarcas
    {
        public async Task<List<Marcas>> GetAllAsync()
        {
            var list = new List<Marcas>();  

            using (var con = GetConection())
            {
                await con.OpenAsync();

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT Id,Name FROM Marcas";
                    cmd.CommandType = CommandType.Text;
                    var result = await cmd.ExecuteReaderAsync();
                    while (result.Read())
                    {
                        list.Add(new Marcas()
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