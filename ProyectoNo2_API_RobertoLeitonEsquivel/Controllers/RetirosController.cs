using MODELS.DTO;
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
    public class RetirosController : ApiController
    {
        private readonly IRetiros _retiros;

        public RetirosController()
        {
            _retiros = new RetirosRepository();
        }

        public async Task<HttpResponseMessage> Post(RestirosDTO retirosDTO)
        {
            try
            {
                await _retiros.AddAsync(retirosDTO);

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
