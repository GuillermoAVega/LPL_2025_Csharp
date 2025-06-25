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
    public class SucursalController : Controller 
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {

            var model = new SucursalModel();
            model.LocalidadesList = LocalidadStatic.GetListado();
            return View(model);
        }
        
        public ActionResult Show(int codigo)
        {
            var suc = Sucursal.FindByKeyStatic(codigo);
            if (suc == null)
                return Redirect("/Sucursal");
            var model = new SucursalModel
            {
                Nombre = suc.Nombre,
                Direccion = suc.Direccion,
                CodPostal = suc.CodigoPostal,
                Telefono = suc.Telefono,
                LocalidadesList = LocalidadStatic.GetListado(),
                
            };
            model.Codigo = codigo;
            
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(SucursalModel model)
        {
            model.LocalidadesList = LocalidadStatic.GetListado();
            if (!ModelState.IsValid)
                return View(model);

            Sucursal suc = new Sucursal
            {
                Nombre= model.Nombre,
                Telefono= model.Telefono,
                Direccion = model.Direccion,
                CodigoPostal = model.CodPostal,
                
            };

            if (suc.SaveObj())
                return RedirectToAction("Index");

            ModelState.AddModelError("", "No se pudo guardar la sucursal.");
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(SucursalModel model)
        {
            model.LocalidadesList = LocalidadStatic.GetListado();
            if (!ModelState.IsValid)
                return View(model);
            Sucursal suc = Sucursal.FindByKeyStatic(model.Codigo);
            suc.Nombre = model.Nombre;
            suc.Direccion = model.Direccion;
            suc.CodigoPostal = model.CodPostal;
            suc.Telefono = model.Telefono;

            if (!suc.SaveObj())
                Redirect("/SucursalError");
            return RedirectToAction("/");
        }
        
        public ActionResult SucursalError()
        {
            return View();
        }


        public ActionResult Listar()
        {
            var datatable = new DataTableSucursal { data = Sucursal.FindAllStatic().Select(e => new SucursalModelViewList { Codigo= e.Codigo, Nombre = e.Nombre, Telefono = e.Telefono, Localidad = e.LocalidadObj.Nombre , Direccion = e.Direccion,  }).ToList() };
            return Content(JsonConvert.SerializeObject(datatable));
        }

    }
}