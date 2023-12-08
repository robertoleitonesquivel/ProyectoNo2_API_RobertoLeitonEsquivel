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
    public class AterrisajesController : Controller
    {
        private readonly IAterrizaje _aterrisaje;

        public AterrisajesController()
        {
            _aterrisaje = new AterrisajesModel();
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                ViewBag.Despegues = await GetDespegues();

                return View();
            }
            catch (Exception)
            {
                return View();
            }

        }

        [HttpPost]
        public async Task<JsonResult> Add(AterrizajeDTO aterrizaje)
        {
            try
            {
                await _aterrisaje.AddAsync(aterrizaje);

                return Json(new { Ok = true, Message = "Aterrisaje creado con éxito!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { Ok = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetDespegues(string numeroSerie)
        {
            try
            {
                var result = await _aterrisaje.GetAvionesDespegues(numeroSerie);

                return Json(new { Ok = true, Mesaage = "", Data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { Ok = false, Mesaage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        private async Task<SelectList> GetDespegues()
        {

            var despeguesList = await _aterrisaje.GetAllAsync();

            var list = new SelectList(despeguesList, "Despegue", "Mision");

            return list;
        }
    }
}