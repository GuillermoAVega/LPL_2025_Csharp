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
    public class LocalidadController : Controller
    {
        public ActionResult Index()
        {
            var localidades = Localidad.FindAllStatic();            
            return View(localidades);
        }

        public ActionResult Create()
        {
            return View();
        }
                
        [HttpPost]
        public ActionResult Create(LocalidadModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
                
            Localidad loc = new Localidad { Codigo = model.CodigoPostal, Nombre = model.Nombre };

            if (loc.SaveObj())
                    Redirect("/Localidad");
            
            return RedirectToAction("/Create");            
        }

//show
        public ActionResult Show(int codigo)
        {
            var localidad = Localidad.FindByKeyStatic(codigo);
            if (localidad == null)
                return Redirect("/Localidad");

            var model = new LocalidadModel
            {
                Nombre = localidad.Nombre
            };
            model.CodigoPostal = codigo;
            return View(model); // esto carga la vista Show.aspx con el modelo
        }

// update
        [HttpPost]
        public ActionResult Update(LocalidadModel model)
        {
            model.LocalidadesList = MarcaStatic.GetListado();
            if (!ModelState.IsValid)
                return View(model);

            Localidad localidad = Localidad.FindByKeyStatic(model.CodigoPostal);
            localidad.Codigo = model.CodigoPostal;
            localidad.Nombre = model.Nombre;

            if (!localidad.SaveObj())
                return Redirect("/LocalidadError");
            return RedirectToAction("/Localidad");
        }

//listar
        public ActionResult Listar()
        {
            var datatable = new DataTableLocalidad { data = Localidad.FindAllStatic().Select(e => new LocalidadModel { CodigoPostal = e.Codigo, Nombre = e.Nombre }).ToList() };
            return Content(JsonConvert.SerializeObject(datatable));
        }
        
    }
}
