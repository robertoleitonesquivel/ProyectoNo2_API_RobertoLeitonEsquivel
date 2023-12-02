using MODELS.Models;
using MODELS.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProyectoNo2_API_RobertoLeitonEsquivel.Repository
{
    public class AvionesRepository : MasterRepository, IAviones
    {
        public async Task AddAsync(List<Aviones> _aviones)
        {
            using (var con = GetConection())
            {
                await con.OpenAsync();

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "INSERTAR_AVIONES";
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var item in _aviones)
                    {
                        cmd.Parameters.Add("@Serie", SqlDbType.Int).Value = item.Serie;
                        cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = item.Nombre;
                        cmd.Parameters.Add("@Dimensiones", SqlDbType.NVarChar).Value = item.Dimensiones;
                        cmd.Parameters.Add("@Distancia", SqlDbType.Int).Value = item.Distancia;
                        cmd.Parameters.Add("@IdMarca", SqlDbType.Int).Value = item.IdMarca;
                        cmd.Parameters.Add("@IdModelo", SqlDbType.Int).Value = item.IdModelo;
                        cmd.Parameters.Add("@NombreTecnico", SqlDbType.NVarChar).Value = item.NombreTecnico;
                        await cmd.ExecuteNonQueryAsync();
                        cmd.Parameters.Clear();
                    }
                   
                }
            }
        }
    }
}