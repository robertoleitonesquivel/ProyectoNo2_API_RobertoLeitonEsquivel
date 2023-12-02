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
    public class ModelosController : ApiController
    {
        private readonly IModelo _modelos;

        public ModelosController()
        {
            _modelos = new ModelosRepository();
        }

        public async Task<HttpResponseMessage> Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await _modelos.GetByMarca(id));
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new
                {
                    Ok = false,
                    Message = ex.Message
                });
            }
        }

    }
}
