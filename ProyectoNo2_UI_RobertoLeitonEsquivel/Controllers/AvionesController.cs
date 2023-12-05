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
    public class AvionesController : Controller
    {
        private readonly IMarcas _marcas;
        private readonly IAviones _aviones;
        private readonly IModelo _modelos;
        private readonly IRetiros _retiros;

        public AvionesController()
        {
            _marcas = new MarcasModel();
            _aviones = new AvionesModel();
            _modelos = new ModelosModel();
            _retiros = new RetirosModel();
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                ViewBag.Marcas = await GetMarcas();

                return View(new Aviones());
            }
            catch (Exception)
            {

                return View(new Aviones());
            }

        }

        public ActionResult Retiro()
        {
            return View();
        }

        public async Task<ActionResult> Listar()
        {
            var avionesList = await _aviones.GetAllAsync();

            return View(avionesList);
        }

        [HttpPost]
        public async Task<JsonResult> Add(List<Aviones> aviones)
        {
            try
            {
                await _aviones.AddAsync(aviones);

                return Json(new { Ok = true, Message = "Avión agregado con éxito!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { Ok = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public async Task<JsonResult> AddRetiro(RestirosDTO retirosDTO)
        {
            try
            {
                await _retiros.AddAsync(retirosDTO);

                return Json(new { Ok = true, Message = "Retiro realizado con éxito!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { Ok = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetModelos(int IdMarca)
        {
            try
            {

                var modelosList = await _modelos.GetByMarca(IdMarca);

                return Json(new { Ok = true, Mesaage = "", Data = modelosList }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { Ok = false, Mesaage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetBySerie(int Serie)
        {
            try
            {

                var avionesList = await _aviones.GetBySerie(Serie);

                return Json(new { Ok = true, Mesaage = "", Data = avionesList }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { Ok = false, Mesaage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        private async Task<SelectList> GetMarcas()
        {

            var marcasList = await _marcas.GetAllAsync();

            var list = new SelectList(marcasList, "Id", "Name");

            return list;
        }


    }
}