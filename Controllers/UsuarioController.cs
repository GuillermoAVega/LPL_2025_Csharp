using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo.Models;
using AltaLlantaCo.db;
using Newtonsoft.Json;

namespace WebDemo.Controllers
{
    public class UsuarioController : Controller
    {


        public ActionResult Index()
        {
            if(Session["usuario"]==null)
                ViewData["SesionIniciada"] = null;
            else
                ViewData["SesionIniciada"] = true;
            return View();
        }


        [HttpPost]
        public ActionResult Login(UsuarioClaveCambioModel model)
        {
            if (model.ConfirmaClave == null)
            {
                var listusers = Cliente.FindAllStatic("usuario ='" + model.Usuario+ "' and clave = '" + model.Clave + "'");
                if (listusers != null)
                    if (listusers.Count > 0)
                    {
                        Session["usuario"] = model.Usuario;
                        Session["codusuario"] = listusers[0].Codigo;
                        ViewData["SesionIniciada"] = true;
                        return Redirect("/Usuario/Inicio");
                    }
            }
            if (!ModelState.IsValid)
                return Redirect("/Usuario/");

            ViewData["SesionIniciada"] = true;
            return Redirect("/Usuario/Inicio");
        }

        public ActionResult Inicio()
        {
            if (Session["usuario"] == null)
                ViewData["SesionIniciada"] = null;
            else
            {
                ViewData["SesionIniciada"] = true;
                ViewData["usuario"] = Session["usuario"];
            }
            return View();
        }


        public ActionResult Comprar() 
        {
            if (Session["usuario"] == null)
                ViewData["SesionIniciada"] = null;
            else
            {
                ViewData["SesionIniciada"] = true;
                ViewData["usuario"] = Session["usuario"];
            }

            return View();
        }


        public ActionResult CambioClave()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CambioClave(UsuarioClaveCambioModel user) 
        {

            if(Session["usuario"] == null)
                return RedirectToAction("/");

            if(user.Clave != user.ConfirmaClave)
                return Redirect("/");

            string nombreUsuario = Session["usuario"].ToString();
            List<Cliente> usuarios = Cliente.FindAllStatic(String.Format("usuario = '{0}'", nombreUsuario));

            var cliente = usuarios[0];

            cliente.Clave = user.Clave;

            if (!cliente.SaveObj())
                RedirectToAction("/"); 

            return RedirectToAction("/Inicio");
        }


        public ActionResult Carrito()
        {
            if (Session["usuario"] == null)
                ViewData["SesionIniciada"] = null;
            else
            {
                ViewData["SesionIniciada"] = true;
                ViewData["usuario"] = Session["usuario"];
            }

            return View();
        }


        public ActionResult Listar()
        {
            var datatable = new DataTableCompra
            {
                data = UsuarioModel.GetListadoCompras(Session["usuario"].ToString()).Select(e => new CompraView
                {
                    CodFactura = e.CodFactura,
                    Codigo = e.Codigo,
                    Fecha = e.Fecha.ToString(),
                    Entregado = e.Entregado ? "Si" : "No"
                }).ToList()
            };
            return Content(JsonConvert.SerializeObject(datatable));
        }


    }
}
