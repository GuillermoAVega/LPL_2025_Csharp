 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AltaLlantaCo.db;
using WebDemo.Models;
using Newtonsoft.Json;
using System.Text;

namespace WebDemo.Controllers
{
    public class MedioPagoController: Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var model = new MedioPagoModel();
            model.BancosList = BancoStatic.GetListado();
            return View(model);
        }

        public ActionResult Show(int codigo)
        {
            var mPago = MedioPago.FindByKeyStatic(codigo);
            if (mPago == null)
                return Redirect("/MedioPago");
            var model = new MedioPagoModel
            {
                Descripcion= mPago.Descripcion,
                CodBanco = mPago.CodigoBanco,
                BancosList = BancoStatic.GetListado(),

            };
            model.Codigo = codigo;

            return View(model);
        }


        [HttpPost]
        public ActionResult Create(MedioPagoModel model)
        {
            model.BancosList = BancoStatic.GetListado();
            if (!ModelState.IsValid)
                return View(model);

            MedioPago mPago = new MedioPago { 
                Descripcion = model.Descripcion,
                CodigoBanco = model.CodBanco,
            };

            if (mPago.SaveObj())
                return RedirectToAction("Index");

            ModelState.AddModelError("", "No se pudo guardar el medio de pago.");
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(MedioPagoModel model)
        {
            model.BancosList = BancoStatic.GetListado();
            if (!ModelState.IsValid)
                return View(model);
            MedioPago mPago = MedioPago.FindByKeyStatic(model.Codigo);
            mPago.Descripcion = model.Descripcion;
            mPago.CodigoBanco = model.CodBanco;

            if (!mPago.SaveObj())
                Redirect("/Error");
            return RedirectToAction("/");
        }

        public ActionResult Listar()
        {
            List<MedioPagoModelViewList> lista = new List<MedioPagoModelViewList>();

            foreach (var e in MedioPago.FindAllStatic())
            {
                string nombreBanco = "";

                if (e.CodigoBanco != null) 
                {
                    Banco banco = Banco.FindByKeyStatic(e.CodigoBanco); // Busca el banco manualmente
                    nombreBanco = banco.Nombre;
                }
                
                lista.Add(new MedioPagoModelViewList
                {
                    Codigo = e.Codigo,
                    Descripcion = e.Descripcion,
                    Banco = nombreBanco
                });
            }

            var datatable = new DataTableMedioPago { data = lista };
            return Content(JsonConvert.SerializeObject(datatable));
        }


        //Listar medios mas usados
        public ActionResult ListadoMasUsados()
        {
            var model = MedioPagoModelStatic.GetListadoMedioPagoMasUsado();

            return View(model);
        }

        public ActionResult ListarMedios()
        {
            var datatable = new DataTableMedioUsado
            {
                data = MedioPagoModelStatic.GetListadoMedioPagoMasUsado().Select(e => new MedioPagoMasUsadoView
                {

                    Codigo = e.Codigo,  
                    Descripcion = e.Descripcion,
                    Banco = e.Banco,
                    VecesUsado= e.VecesUsado

                }).ToList()
            };

            return Content(JsonConvert.SerializeObject(datatable));
        }



        public ActionResult ExportarListado(string nombreArchivo, string formato)
        {
            // Assuming you have a method to get the file data as a byte array
            var mediosPago = MedioPagoModelStatic.GetListadoMedioPagoMasUsado();

            byte[] archivoBytes;
            string fileName;

            if (formato == "csv")
            {
                // Generar archivo CSV
                var csv = new StringBuilder();
                csv.AppendLine("Banco, Descripcion");

                foreach (var medioPago in mediosPago)
                {
                    csv.AppendLine(String.Format("{0},{1}", medioPago.Banco, medioPago.Descripcion));
                }

                archivoBytes = System.Text.Encoding.UTF8.GetBytes(csv.ToString());
                fileName = String.Format("{0}.csv", nombreArchivo);
            }
            else
            {
                // Generar archivo TXT
                var txt = new StringBuilder();
                txt.AppendLine(string.Format("{0,-20} {1,-50}",
                    "Banco", "Descripcion"));

                txt.AppendLine(new string('-', 50)); // Separador

                foreach (var medioPago in mediosPago)
                {
                    //txt.AppendLine(String.Format("{0},{1},{2},{3},{4}", producto.Codigo, producto.Descripcion, producto.Marca, producto.Categoria, producto.Cantidad));
                    txt.AppendLine(string.Format("{0,-20} {1,-50}",
               medioPago.Banco, medioPago.Descripcion));

                }

                archivoBytes = System.Text.Encoding.UTF8.GetBytes(txt.ToString());
                fileName = String.Format("{0}.txt", nombreArchivo);
            }


            return File(archivoBytes, "text/csv", fileName);
        }


    }
}