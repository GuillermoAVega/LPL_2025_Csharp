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
        
        public ActionResult Listar()
        {
            var datatable = new DataTableLocalidad { data = Localidad.FindAllStatic().Select(e => new LocalidadModel { CodigoPostal = e.Codigo, Nombre = e.Nombre }).ToList() };
            return Content(JsonConvert.SerializeObject(datatable));
        }
        
    }
}
