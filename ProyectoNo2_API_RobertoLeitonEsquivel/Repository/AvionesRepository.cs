using MODELS.DTO;
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

        public async Task<List<ModelosAvionesDTO>> GetAllAsync()
        {
            var list = new List<ModelosAvionesDTO>();

            using (var con = GetConection())
            {
                await con.OpenAsync();

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = @"SELECT	M.[Name] AS Marca,
		                                        A.Serie AS Serie,
		                                        A.Nombre AS Fantasia,
		                                        A.FechaRegistro,
		                                        A.NombreTecnico,
		                                        MA.Id,
		                                        MA.[Name] AS Modelo,
		                                        I.Stock
                                        FROM Aviones A
                                        INNER JOIN ModeloAviones MA
	                                        ON A.IdModelo = MA.Id
                                        INNER JOIN Marcas M
	                                        ON A.IdMarca = M.Id
                                        INNER JOIN Inventario I
	                                        ON A.IdModelo = I.IdModelo
                                            AND I.Stock > 0";
                    cmd.CommandType = CommandType.Text;
                    var result = await cmd.ExecuteReaderAsync();
                    while (result.Read())
                    {
                        if (list.Exists(x => x.Id == result.GetInt32(5)))
                        {
                            ModelosAvionesDTO datos = list.Find(x => x.Id == result.GetInt32(5));

                            datos.Aviones.Add(new GetAllAvionesDTO
                            {
                                Marca = result.GetString(0),
                                Serie = result.GetInt32(1),
                                Fantasia = result.GetString(2),
                                FechaRegistro = result.GetDateTime(3).ToString("dd-MM-yyyy HH:mm:ss"),
                                NombreTecnico = result.GetString(4)
                            });
                        }
                        else
                        {
                            list.Add(new ModelosAvionesDTO
                            {
                                Id = result.GetInt32(5),
                                Modelo = result.GetString(6),
                                Stock = result.GetInt32(7),
                                Aviones = new List<GetAllAvionesDTO>()
                                {
                                    new GetAllAvionesDTO
                                    {
                                         Marca = result.GetString(0),
                                         Serie = result.GetInt32(1),
                                         Fantasia = result.GetString(2),
                                         FechaRegistro = result.GetDateTime(3).ToString("dd-MM-yyyy HH:mm:ss"),
                                         NombreTecnico = result.GetString(4)
                                    }
                                }
                            });


                        }
                    }
                }
            }

            return list;
        }

        public async Task<List<GetAvionesDTO>> GetBySerie(int _serie)
        {
            var list = new List<GetAvionesDTO>();

            using (var con = GetConection())
            {
                await con.OpenAsync();

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = @"SELECT	A.Id AS Id,
		                                        A.Nombre AS NombreFantasia,
		                                        M.[Name] AS Marca,
		                                        MA.[Name] AS Modelo,
                                                MA.Id AS IdModelo
                                        FROM Aviones A
                                        INNER JOIN Marcas M
	                                        ON A.IdMarca = M.Id
                                        INNER JOIN ModeloAviones MA
	                                        ON A.IdModelo = MA.Id
                                        WHERE Serie = @Serie";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@Serie", SqlDbType.Int).Value = _serie;
                    var result = await cmd.ExecuteReaderAsync();
                    while (result.Read())
                    {
                        list.Add(new GetAvionesDTO
                        {
                            Id = result.GetInt32(0),
                            NombreFantasia = result.GetString(1),
                            Marca = result.GetString(2),
                            Modelo = result.GetString(3),
                            IdModelo = result.GetInt32(4),
                        });
                    }
                }
            }

            return list;
        }


    }
}