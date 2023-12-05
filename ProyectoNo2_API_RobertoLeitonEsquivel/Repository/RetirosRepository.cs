using MODELS.DTO;
using MODELS.Models;
using MODELS.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProyectoNo2_API_RobertoLeitonEsquivel.Repository
{
    public class RetirosRepository : MasterRepository, IRetiros
    {
        public async Task AddAsync(RestirosDTO _retitosDTO)
        {
            using (var con = GetConection())
            {
                await con.OpenAsync();

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "INSERTAR_RETIROS";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@NombreTecnico", SqlDbType.NVarChar).Value = _retitosDTO.NombreTecnico;
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = _retitosDTO.FechaRetiro;
                    cmd.Parameters.Add("@Aviones", SqlDbType.NVarChar).Value = _retitosDTO.Aviones;
                    cmd.Parameters.Add("@Modelos", SqlDbType.Int).Value = _retitosDTO.Modelos;
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}