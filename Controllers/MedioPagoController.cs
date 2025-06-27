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
    public class MedioPagoController: Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var model = new MedioPagoModel();
            model.BancosList = BancoStatic.GetListado();
            return View(model);
        }

        public ActionResult Show(int codigo)
        {
            var mPago = MedioPago.FindByKeyStatic(codigo);
            if (mPago == null)
                return Redirect("/MedioPago");
            var model = new MedioPagoModel
            {
                Descripcion= mPago.Descripcion,
                CodBanco = mPago.CodigoBanco,
                BancosList = BancoStatic.GetListado(),

            };
            model.Codigo = codigo;

            return View(model);
        }


        [HttpPost]
        public ActionResult Create(MedioPagoModel model)
        {
            model.BancosList = BancoStatic.GetListado();
            if (!ModelState.IsValid)
                return View(model);

            MedioPago mPago = new MedioPago { 
                Descripcion = model.Descripcion,
                CodigoBanco = model.CodBanco,
            };

            if (mPago.SaveObj())
                return RedirectToAction("Index");

            ModelState.AddModelError("", "No se pudo guardar el medio de pago.");
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(MedioPagoModel model)
        {
            model.BancosList = BancoStatic.GetListado();
            if (!ModelState.IsValid)
                return View(model);
            MedioPago mPago = MedioPago.FindByKeyStatic(model.Codigo);
            mPago.Descripcion = model.Descripcion;
            mPago.CodigoBanco = model.CodBanco;

            if (!mPago.SaveObj())
                Redirect("/Error");
            return RedirectToAction("/");
        }

        public ActionResult Listar()
        {
            var datatable = new DataTableMedioPago { data = MedioPago.FindAllStatic().Select
                (e => new MedioPagoModelViewList { 
                    Codigo = e.Codigo, Descripcion= e.Descripcion, Banco = e.BancoObj.Nombre 
                }).ToList() };
            return Content(JsonConvert.SerializeObject(datatable));
        }
    }
}