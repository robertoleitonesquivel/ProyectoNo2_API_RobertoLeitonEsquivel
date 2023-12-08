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
    public class AterrisajesModel : IAterrizaje
    {
        private readonly ICommon _common;

        public AterrisajesModel()
        {
            _common = new CommonModel();
        }

        public async Task AddAsync(AterrizajeDTO _aterrizaje)
        {
            await _common.ExecuteHttpAsync<AterrizajeDTO>(HttpMethod.Post, "Aterrisajes", _aterrizaje);
        }

        public async Task<List<GetDespeguesDTO>> GetAllAsync()
        {
            return await _common.ExecuteHttpAsync<List<GetDespeguesDTO>>(HttpMethod.Get, "Aterrisajes");
        }

        public async Task<List<GetAllDespeguesDTO>> GetAvionesDespegues(string _numeroDespegue)
        {
            return await _common.ExecuteHttpAsync<List<GetAllDespeguesDTO>>(HttpMethod.Get, $"Aterrisajes?numeroDespegue={_numeroDespegue}");
        }
    }
}