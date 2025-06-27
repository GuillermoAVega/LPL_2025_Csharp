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
                Redirect("/Error");
            return RedirectToAction("/");
        }


        public ActionResult Listar()
        {
            List<SucursalModelViewList> lista = new List<SucursalModelViewList>();

            foreach (var s in Sucursal.FindAllStatic())
            {
                string nombreLocalidad = "";
                Localidad loc = Localidad.FindByKeyStatic(s.CodigoPostal); // Busca la localidad manualmente
                if (loc != null)
                    nombreLocalidad = loc.Nombre;

                lista.Add(new SucursalModelViewList
                {
                    Codigo = s.Codigo,
                    Nombre = s.Nombre,
                    Direccion = s.Direccion,
                    Telefono = s.Telefono,
                    Localidad = nombreLocalidad
                });
            }

            var datatable = new DataTableSucursal { data = lista };
            return Content(JsonConvert.SerializeObject(datatable));
        }


    }
}