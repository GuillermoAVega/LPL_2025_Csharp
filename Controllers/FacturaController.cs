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
    public class FacturaController : Controller
    {
        //
        // GET: /Factura/

        public static int codigoFactura{set;get;}

        public ActionResult Index()
        {
            return View();
        }        

        public ActionResult Show(int CodFactura)
        {
            codigoFactura = CodFactura;

            if (CodFactura == 0)
                return Redirect("/");

            var detalles = DetalleFactura.FindAllStatic(String.Format("cod_factura = {0}", CodFactura));
            
            var detallesView = detalles.Select(e => new DetalleFacturaView
            {
                Cantidad = e.Cantidad,
                Precio = e.PrecioUnit,
                Producto = e.ProductoObj.Descripcion
            }).ToList();

            return View(detallesView); 
        }


        public ActionResult Listar()
        {
            var detalles = DetalleFactura.FindAllStatic(String.Format("cod_factura = {0}", codigoFactura));

            foreach (var detalle in detalles) 
            {
                Console.Write(detalle.Cantidad);
            
            }

            var datatable = new DataTableFactura
            {
                data = detalles.Select(e => new DetalleFacturaView
                {   
                    Producto = e.ProductoObj.Descripcion,
                    Precio = e.PrecioUnit,
                    Cantidad = e.Cantidad
                    
                }).ToList()
            };

            return Content(JsonConvert.SerializeObject(datatable));
        }

    }
}
