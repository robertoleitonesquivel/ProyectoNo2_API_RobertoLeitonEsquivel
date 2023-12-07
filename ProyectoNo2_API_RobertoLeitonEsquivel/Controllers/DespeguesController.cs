using MODELS.Models.Contracts;
using MODELS.Models;
using ProyectoNo2_API_RobertoLeitonEsquivel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MODELS.DTO;

namespace ProyectoNo2_API_RobertoLeitonEsquivel.Controllers
{
    public class DespeguesController : ApiController
    {
        private readonly IDespegues _despegues;

        public DespeguesController()
        {
            _despegues = new DespeguesRepository();
        }

        public async Task<HttpResponseMessage> Post(DespeguesDTO despegues)
        {
            try
            {
                await _despegues.AddAsync(despegues);

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

        public async Task<HttpResponseMessage> Get(int id)
        {
            try
            {
                var result = await _despegues.GetAvionesBySerie(id);

                return Request.CreateResponse(HttpStatusCode.OK, result);
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
