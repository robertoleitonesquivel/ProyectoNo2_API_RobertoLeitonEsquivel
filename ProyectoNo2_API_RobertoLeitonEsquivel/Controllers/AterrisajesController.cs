using MODELS.DTO;
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
    public class AterrisajesController : ApiController
    {
        private IAterrizaje _aterrisaje;

        public AterrisajesController()
        {
            _aterrisaje = new AterrisajeRepository();
        }

        public async Task<HttpResponseMessage> Post(AterrizajeDTO aterrizaje)
        {
            try
            {
                await _aterrisaje.AddAsync(aterrizaje);

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
                    Ok = false,
                    Message = ex.Message
                });
            }
        }

        public async Task<HttpResponseMessage> Get(string numeroDespegue)
        {
            try
            {
                var result = await _aterrisaje.GetAvionesDespegues(numeroDespegue);

                return Request.CreateResponse(HttpStatusCode.OK, result);
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

        public async Task<HttpResponseMessage> Get()
        {
            try
            {
                var result = await _aterrisaje.GetAllAsync();

                return Request.CreateResponse(HttpStatusCode.OK, result);
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
