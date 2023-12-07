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
    public class DespeguesRepository : MarcasRepository, IDespegues
    {
        public async Task AddAsync(DespeguesDTO _despegues)
        {
            using (var con = GetConection())
            {
                await con.OpenAsync();

                using (var cmd = new SqlCommand())
                {
                    //CREACION DEL DESPEGUE
                    cmd.Connection = con;
                    cmd.CommandText = "INSERTAR_DESPEGUES";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FechaDespegue", SqlDbType.DateTime).Value = _despegues.FechaDespegue;
                    cmd.Parameters.Add("@NombreTecnico", SqlDbType.NVarChar).Value = _despegues.Tecnico;
                    cmd.Parameters.Add("@NombreMision", SqlDbType.NVarChar).Value = _despegues.NombreMision;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
                    await cmd.ExecuteNonQueryAsync();
                    int Id = (int)cmd.Parameters["@Id"].Value;
                    cmd.Parameters.Clear();

                    //AVIONES DEL DESPEGUE
                    cmd.CommandText = @"INSERT INTO DespeguesAviones(IdDespegue,IdAvion,Piloto)
                                        VALUES(@IdDespegue,@IdAvion,@Piloto)";
                    cmd.CommandType = CommandType.Text;
                    foreach (var item in _despegues.AvionesDespegue)
                    {
                        cmd.Parameters.Add("@IdDespegue", SqlDbType.Int).Value = Id;
                        cmd.Parameters.Add("@IdAvion", SqlDbType.NVarChar).Value = item.IdAvion;
                        cmd.Parameters.Add("@Piloto", SqlDbType.NVarChar).Value = item.NombrePiloto;
                        await cmd.ExecuteNonQueryAsync();
                        cmd.Parameters.Clear();
                    }

                }
            }
        }

        public async Task<List<AvionesDespegueDTO>> GetAvionesBySerie(int _serie)
        {
            var list = new List<AvionesDespegueDTO>();

            using (var con = GetConection())
            {
                await con.OpenAsync();

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = @"SELECT	A.Id AS Id,
		                                        A.Serie AS Serie,
		                                        M.[Name]  AS Marca,
		                                        MA.[Name] AS Modelo
                                        FROM Aviones A
                                        INNER JOIN ModeloAviones MA
	                                        ON A.IdModelo = MA.Id
                                        INNER JOIN Marcas M
	                                        ON A.IdMarca = M.Id
                                        WHERE A.Serie = @Serie";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@Serie", SqlDbType.Int).Value = _serie;
                    var result = await cmd.ExecuteReaderAsync();
                    while (result.Read())
                    {
                        list.Add(new AvionesDespegueDTO
                        {
                            IdAvion = result.GetInt32(0),
                            Serie = result.GetInt32(1),
                            Marca = result.GetString(2),
                            Modelo = result.GetString(3)
                        });
                    }
                }
            }

            return list;
        }
    }
}