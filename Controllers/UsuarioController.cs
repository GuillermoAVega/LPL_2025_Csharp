using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemo.Models;
using AltaLlantaCo.db;

namespace WebDemo.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Index()
        {
            if(Session["usuario"]==null)
                ViewData["SesionIniciada"] = null;
            else
                ViewData["SesionIniciada"] = null;
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
    }
}
