using MODELS.DTO;
using MODELS.Models;
using MODELS.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;

namespace ProyectoNo2_API_RobertoLeitonEsquivel.Repository
{
    public class AterrisajeRepository : MasterRepository, IAterrizaje
    {
        public async Task AddAsync(AterrizajeDTO _aterrizaje)
        {
            using (var conn = GetConection())
            {
                await conn.OpenAsync();

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERTAR_ATERRISAJES";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = _aterrizaje.FechaRegistro;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
                    await cmd.ExecuteNonQueryAsync();
                    int Id = (int)cmd.Parameters["@Id"].Value;
                    cmd.Parameters.Clear();

                    foreach (var avion in _aterrizaje.Aviones)
                    {
                        cmd.CommandText = @"INSERT INTO AterrisajesAviones(IdAterrisaje,IdAvion,PerdidasHumanas,PerdidoMision)
                                            VALUES(@IdAterrisaje,@IdAvion,@PerdidasHumanas,@PerdidoMision)";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("@IdAterrisaje", SqlDbType.Int).Value = Id;
                        cmd.Parameters.Add("@IdAvion", SqlDbType.Int).Value = avion.IdAvion;
                        cmd.Parameters.Add("@PerdidasHumanas", SqlDbType.Bit).Value = avion.PerdidasHumanas;
                        cmd.Parameters.Add("@PerdidoMision", SqlDbType.Bit).Value = avion.PerdidoMision;
                        await cmd.ExecuteNonQueryAsync();
                        cmd.Parameters.Clear();
                    }
                }
            }
        }

        public async Task<List<GetAllDespeguesDTO>> GetAvionesDespegues(string _numeroDespegue)
        {
            var list = new List<GetAllDespeguesDTO>();

            using (var conn = GetConection())
            {
                await conn.OpenAsync();

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT	D.NumeroDespegue AS Despegue,
		                                        D.NombreMision AS Mision,
		                                        D.NombreTecnico AS Tecnico,
		                                        MA.[Name] AS Modelo,
		                                        A.Id
                                        FROM Aviones A
                                        INNER JOIN DespeguesAviones DA
	                                        ON A.Id = DA.IdAvion
                                        INNER JOIN ModeloAviones MA
	                                        ON A.IdModelo = MA.Id
                                        INNER JOIN Despegues D
	                                        ON D.Id = DA.IdDespegue
                                        WHERE D.NumeroDespegue = @NumeroDespegue";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@NumeroDespegue", SqlDbType.NVarChar).Value = _numeroDespegue;
                    var result = await cmd.ExecuteReaderAsync();

                    while (result.Read())
                    {
                        list.Add(new GetAllDespeguesDTO
                        {
                            Despegue = result.GetString(0),
                            Mision = result.GetString(1),
                            Tecnico = result.GetString(2),
                            Modelo = result.GetString(3),
                            IdAvion = result.GetInt32(4)
                        });
                    }
                }
            }

            return list;
        }

        public async Task<List<GetDespeguesDTO>> GetAllAsync()
        {
            var list = new List<GetDespeguesDTO>();

            using (var conn = GetConection())
            {
                await conn.OpenAsync();

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT	NumeroDespegue,
		                                        NombreMision
                                        FROM Despegues";
                    cmd.CommandType = CommandType.Text;
                    using (var result = await cmd.ExecuteReaderAsync())
                    {
                        while (result.Read())
                        {
                            list.Add(new GetDespeguesDTO
                            {
                                Despegue = result.GetString(0),
                                Mision = result.GetString(1)
                            });
                        }
                    }
                }
            }

            return list;
        }
    }
}