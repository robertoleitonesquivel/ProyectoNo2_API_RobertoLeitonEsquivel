using MODELS.DTO;
using MODELS.Models;
using MODELS.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ProyectoNo2_UI_RobertoLeitonEsquivel.Models
{
    public class AvionesModel : IAviones
    {
        private readonly ICommon _common;

        public AvionesModel()
        {
            _common = new CommonModel();
        }

        public async Task AddAsync(List<Aviones> _aviones)
        {
            await _common.ExecuteHttpAsync<List<Aviones>>(HttpMethod.Post, "Aviones", _aviones);
        }

        public async Task<List<ModelosAvionesDTO>> GetAllAsync()
        {
            return await _common.ExecuteHttpAsync<List<ModelosAvionesDTO>>(HttpMethod.Get, "Aviones");
        }

        public async Task<List<GetAvionesDTO>> GetBySerie(int _serie)
        {
            return await _common.ExecuteHttpAsync<List<GetAvionesDTO>>(HttpMethod.Get, $"Aviones?id={_serie}");
        }


    }
}