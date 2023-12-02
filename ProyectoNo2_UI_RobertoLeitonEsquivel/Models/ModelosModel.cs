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
    public class ModelosModel : IModelo
    {
        private readonly ICommon _common;

        public ModelosModel()
        {
            _common = new CommonModel();
        }

        public async Task<List<Modelos>> GetByMarca(int  _IdMarca)
        {
            return await _common.ExecuteHttpAsync<List<Modelos>>(HttpMethod.Get, $"Modelos?id={_IdMarca}");
        }
    }
}