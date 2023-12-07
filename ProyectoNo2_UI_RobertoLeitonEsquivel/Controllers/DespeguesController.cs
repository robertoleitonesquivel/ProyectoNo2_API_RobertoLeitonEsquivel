using MODELS.DTO;
using MODELS.Models;
using MODELS.Models.Contracts;
using ProyectoNo2_UI_RobertoLeitonEsquivel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProyectoNo2_UI_RobertoLeitonEsquivel.Controllers
{
    public class DespeguesController : Controller
    {

        private readonly IDespegues _despegues;

        public DespeguesController()
        {
            _despegues = new DespeguesModel();
        }

        // GET: Despegues
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Add(DespeguesDTO despegues)
        {
            try
            {
                await _despegues.AddAsync(despegues);

                return Json(new { Ok = true, Message = "Despegue agregado con éxito!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { Ok = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetBySerie(int Serie)
        {
            try
            {

                var avionesList = await _despegues.GetAvionesBySerie(Serie);

                return Json(new { Ok = true, Mesaage = "", Data = avionesList }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { Ok = false, Mesaage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}