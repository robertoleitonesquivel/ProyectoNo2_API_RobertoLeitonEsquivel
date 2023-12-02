using MODELS.Models;
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
    public class AvionesController : ApiController
    {
        private readonly IAviones _aviones;

        public AvionesController()
        {
            _aviones = new AvionesRepository();
        }

        public async Task<HttpResponseMessage> Post(List<Aviones> aviones)
        {
            try
            {
                await _aviones.AddAsync(aviones);

                return Request.CreateResponse(HttpStatusCode.OK, new
                {
                    Ok = true,
                    Message = ""
                });
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new
                {
                    Ok = true,
                    Message = ex.Message
                });
            }
        }
    }
}
