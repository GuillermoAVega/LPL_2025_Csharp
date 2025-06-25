using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AltaLlantaCo.db;
using WebDemo.Models;
using Newtonsoft.Json;

namespace WebDemo.Controllers
{
    public class MpagoController: Controller
    {
        public ActionResult Index()
        {
            var mPagos = MedioPago.FindAllStatic();
            return View(mPagos);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MPagoModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            MedioPago mPago = new MedioPago { Descripcion = model.Descripcion };

            if (mPago.SaveObj())
                Redirect("/Mpago");

            return RedirectToAction("/Create");
        }

        public ActionResult Listar()
        {
            var datatable = new DataTableMpago { data = MedioPago.FindAllStatic().Select(e => new MPagoModel { Descripcion= e.Descripcion}).ToList() };
            return Content(JsonConvert.SerializeObject(datatable));
        }
    }
}