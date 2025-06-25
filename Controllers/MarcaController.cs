using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo.Models;
using Newtonsoft.Json;
using AltaLlantaCo.db;

namespace WebDemo.Controllers
{
    public class MarcaController : Controller
    {
        //
        // GET: /Marca/

        public ActionResult Index()
        {
            var marcas = Marca.FindAllStatic();
            return View(marcas);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MarcaModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Marca marca = new Marca { Descripcion = model.Descripcion };

            if (marca.SaveObj())
                return Redirect("/Marca");

            return RedirectToAction("/Create");
        }

//show
        public ActionResult Show(int codigo)
        {
            var marca = Marca.FindByKeyStatic(codigo);
            if (marca == null)
                return Redirect("/Marca");

            var model = new MarcaModel
            {
                Descripcion = marca.Descripcion
            };
            model.Codigo = codigo;
            return View(model); // esto carga la vista Show.aspx con el modelo
        }

// update
        [HttpPost]
        public ActionResult Update(MarcaModel model)
        {
            model.MarcasList = MarcaStatic.GetListado();
            if (!ModelState.IsValid)
                return View(model);

            Marca marca = Marca.FindByKeyStatic(model.Codigo);
            marca.Descripcion = model.Descripcion;

            if (marca.SaveObj())
                return Redirect("/Marca");

            return RedirectToAction("/Show");
        }


//listar
        public ActionResult Listar()
        {
            var datatable = new DataTableMarca { data = Marca.FindAllStatic().Select(e => new MarcaModel { Codigo = e.Codigo, Descripcion = e.Descripcion }).ToList() };
            return Content(JsonConvert.SerializeObject(datatable));
        }
    }
}
