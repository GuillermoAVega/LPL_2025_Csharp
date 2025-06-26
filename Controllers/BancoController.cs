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
    public class BancoController : Controller
    {
        //
        // GET: /Banco/

        public ActionResult Index()
        {
            var bancos = Banco.FindAllStatic();
            return View(bancos);
        }

        public ActionResult Create()
        {
            return View();
        }



        public ActionResult Show(int codigoBanco)
        {
            var banco = Banco.FindByKeyStatic(codigoBanco);
            if (banco == null)
                return Redirect("/Banco");

            var model = new BancoModel
            {
                nombre = banco.Nombre,
                telefono = banco.Telefono,
                direccion = banco.Direccion
            };
            
            model.codigo = codigoBanco;

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(BancoModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Banco banco = new Banco { Nombre = model.nombre, Direccion = model.direccion, Telefono = model.telefono };

            if (banco.SaveObj())
                Redirect("/Banco");

            return RedirectToAction("/Create");
        }



        [HttpPost]
        public ActionResult Update(BancoModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            
            Banco banco = Banco.FindByKeyStatic(model.codigo);

            banco.Nombre = model.nombre;
            banco.Direccion = model.direccion;
            banco.Telefono = model.telefono;
            
            if (!banco.SaveObj())
                Redirect("../Error");   
            return RedirectToAction("/");
        }
       



        public ActionResult Listar()
        {
            var datatable = new DataTableBanco { data = Banco.FindAllStatic().Select(e => new BancoModel { codigo = e.Codigo, nombre = e.Nombre, direccion = e.Direccion, telefono = e.Telefono }).ToList() };
            return Content(JsonConvert.SerializeObject(datatable));
        }


    }
}
