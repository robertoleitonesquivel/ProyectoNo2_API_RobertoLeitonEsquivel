using MODELS.Models.Contracts;
using ProyectoNo2_API_RobertoLeitonEsquivel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProyectoNo2_API_RobertoLeitonEsquivel.Controllers
{
    public class MarcasController : ApiController
    {
        private readonly IMarcas _marcas;

        public MarcasController()
        {
            _marcas = new MarcasRepository();
        }

        public async Task<HttpResponseMessage> Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await _marcas.GetAllAsync());
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError,new
                {
                    Ok = false,
                    Message = ex.Message    
                });
            }
        }
    }
}
