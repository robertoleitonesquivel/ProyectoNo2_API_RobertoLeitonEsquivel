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
    public class MarcasModel : IMarcas
    {
        private readonly ICommon _common;

        public MarcasModel()
        {
            _common = new CommonModel();
        }

        public async Task<List<Marcas>> GetAllAsync()
        {
            return await _common.ExecuteHttpAsync<List<Marcas>>(HttpMethod.Get,"Marcas");
        }
    }
}