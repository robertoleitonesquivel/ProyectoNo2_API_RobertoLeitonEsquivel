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
    public class RetirosModel : IRetiros
    {
        private readonly ICommon _common;

        public RetirosModel()
        {
            _common = new CommonModel();
        }

        public async Task AddAsync(RestirosDTO _retitosDTO)
        {
            await _common.ExecuteHttpAsync<RestirosDTO>(HttpMethod.Post, "Retiros", _retitosDTO);
        }
    }
}