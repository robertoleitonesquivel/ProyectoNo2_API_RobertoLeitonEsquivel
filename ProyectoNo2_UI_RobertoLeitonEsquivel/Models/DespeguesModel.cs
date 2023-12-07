using MODELS.DTO;
using MODELS.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ProyectoNo2_UI_RobertoLeitonEsquivel.Models
{
    public class DespeguesModel : IDespegues
    {
        private readonly ICommon _common;

        public DespeguesModel()
        {
            _common = new CommonModel();
        }

        public async Task AddAsync(DespeguesDTO _despegues)
        {
            await _common.ExecuteHttpAsync<DespeguesDTO>(HttpMethod.Post, "Despegues", _despegues);
        }

        public async Task<List<AvionesDespegueDTO>> GetAvionesBySerie(int _serie)
        {
            return await _common.ExecuteHttpAsync<List<AvionesDespegueDTO>>(HttpMethod.Get, $"Despegues?id={_serie}");
        }
    }
}