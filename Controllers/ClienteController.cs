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
    public class ClienteController : Controller
    {
        //
        // GET: /Cliente/

        public ActionResult Index()
        {
            return View();
        }        
        public ActionResult Create()
        {            
            var model = new ClienteModel();
            model.LocalidadesList = LocalidadStatic.GetListado();
            return View(model);
        }
        
        
        [HttpPost]
        public ActionResult Create(ClienteModel model)        
        {
            model.LocalidadesList = LocalidadStatic.GetListado();         
            if (!ModelState.IsValid)
                return View(model);
            
            Cliente cli = new Cliente
            {
                Usuario = model.Usuario,
                Clave = model.Clave,
                Cuil = model.Cuil,
                RazonSocial = model.RazonSocial,
                Direccion = model.Direccion,
                CodPostal = model.CodPostal,
                Email = model.Email,
                Celular = model.Celular
            };

            if (cli.SaveObj())
                Redirect("/Cliente");

            return RedirectToAction("/Create");            
        }

        public ActionResult Show(int codigoUsuario)
        {
            var cli = Cliente.FindByKeyStatic(codigoUsuario);
            if (cli == null)
                return Redirect("/Cliente");
            var model = new ClienteModel
            {
                Cuil = cli.Cuil,
                RazonSocial = cli.RazonSocial,
                Celular = cli.Celular,
                Direccion = cli.Direccion,
                CodPostal = cli.CodPostal,
                Clave = cli.Clave,
                ConfirmaClave = cli.Clave,
                Email = cli.Email,
                LocalidadesList = LocalidadStatic.GetListado(),
                Usuario = cli.Usuario
            };
            model.Codigo = codigoUsuario;

            return View(model);
        }


        [HttpPost]
        public ActionResult Update(ClienteModel model)
        {
            model.LocalidadesList = LocalidadStatic.GetListado();
            if (!ModelState.IsValid)
                return View(model);

            Cliente cli = Cliente.FindByKeyStatic(model.Codigo);
            cli.Usuario = model.Usuario;
            cli.Clave = model.Clave;
            cli.RazonSocial = model.RazonSocial;
            cli.Direccion = model.Direccion;
            cli.CodPostal = model.CodPostal;
            cli.Email = model.Email;
            cli.Celular = model.Celular;

            if (!cli.SaveObj())
                Redirect("/ClienteError");
            return RedirectToAction("/");            
        }


        public ActionResult ClienteError()
        {
            return View(); 
        }
        public ActionResult Listar()
        {
            var datatable = new DataTableCliente { data = Cliente.FindAllStatic().Select(e => new ClienteModelViewList { Clave=e.Clave,Localidad = e.LocalidadObj.Nombre,  Codigo = e.Codigo, RazonSocial = e.RazonSocial, Usuario = e.Usuario, Email = e.Email, Celular = e.Celular, Cuil = e.Cuil, Direccion = e.Direccion }).ToList() };
            return Content(JsonConvert.SerializeObject(datatable));
        }
    }
}
