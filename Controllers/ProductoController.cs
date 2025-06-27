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
    public class ProductoController : Controller
    {
        //
        // GET: /Producto/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var model = new ProductoModel();
            model.CategoriaList = Categoria.FindAllStatic().Select(categoria => new SelectListItem { Text = categoria.Descripcion, Value = categoria.Codigo.ToString() }).ToList();
            model.MarcaList = MarcaStatic.GetListado();
            return View(model);
        }


        public ActionResult Show(int codigoProducto)
        {
            var producto = Producto.FindByKeyStatic(codigoProducto);

            if (producto == null)
                return Redirect("/Producto");

            var model = new ProductoModel
            {
                CategoriaList = Categoria.FindAllStatic().Select(categoria => new SelectListItem { Text = categoria.Descripcion, Value = categoria.Codigo.ToString() }).ToList(),
                MarcaList = MarcaStatic.GetListado(),
                Descripcion = producto.Descripcion,
                CodCategoria = producto.CodCategoria,
                CodMarca = producto.CodCategoria,
                Precio = producto.Precio,
                Stock = producto.Stock,
                Disponibilidad = producto.Disponible
            };

            model.Codigo = codigoProducto;

            return View(model);
        }



        [HttpPost]
        public ActionResult Create(ProductoModel model)
        {
            model.CategoriaList = Categoria.FindAllStatic().Select(categoria => new SelectListItem { Text = categoria.Descripcion, Value = categoria.Codigo.ToString() }).ToList();
            model.MarcaList = MarcaStatic.GetListado();


            if (!ModelState.IsValid)
                return View(model);

            Producto producto = new Producto
            {
                CodCategoria = model.CodCategoria,
                CodMarca = model.CodMarca,
                Precio = model.Precio,
                Stock = model.Stock,
                Disponible = model.Disponibilidad,
                Descripcion = model.Descripcion
            };

            if (producto.SaveObj())
                Redirect("/Producto");

            return RedirectToAction("/Create");
        }



        [HttpPost]
        public ActionResult Update(ProductoModel model)
        {
            model.CategoriaList = Categoria.FindAllStatic().Select(categoria => new SelectListItem { Text = categoria.Descripcion, Value = categoria.Codigo.ToString() }).ToList();
            model.MarcaList = MarcaStatic.GetListado();

            if (!ModelState.IsValid)
                return View(model);

            Producto producto = Producto.FindByKeyStatic(model.Codigo);
            producto.Precio = model.Precio;
            producto.CodCategoria = model.CodCategoria;
            producto.CodMarca = model.CodMarca;
            producto.Stock = model.Stock;
            producto.Disponible = model.Disponibilidad;
            producto.Descripcion = model.Descripcion;


            if (!producto.SaveObj())
                Redirect("/ProductoError"); //Implementar.

            return RedirectToAction("/");
        }


        public ActionResult ProductoError()
        {
            return View();
        }


        public ActionResult Listar()
        {
            var datatable = new DataTableProducto { data = Producto.FindAllStatic().Select(e => new ProductoModelViewList { 
                Codigo = e.Codigo, 
                Descripcion = e.Descripcion, 
                Marca = e.MarcaObj.Descripcion, 
                Categoria = e.CategoriaObj.Descripcion, 
                Precio = e.Precio, 
                Stock = e.Stock, 
                Disponibilidad = e.Disponible? "Si" : "No"
            }).ToList() };

            return Content(JsonConvert.SerializeObject(datatable));
        }

        public ActionResult Listado()
        {
            var model = new ListadoModel
            {
                Marcas = MarcaStatic.GetListado(),
                Categorias = CategoriaStatic.GetListado()

            };

            return View(model);
        }




        //Logica para listado de productos mas vendidos.

        public ActionResult ListarMasVendidos() 
        {
            var datatable = new DataTableProductoVendido
            {
                data = ProductoModelStatic.GetListadoMasVendidos().Select(e => new ProductoVendidoView
                {
                    Codigo = e.Codigo,
                    Cantidad = e.Cantidad,
                    Descripcion = e.Descripcion,
                    Marca = e.Marca,
                    Categoria = e.Categoria

                }).ToList()
            };
            return Content(JsonConvert.SerializeObject(datatable)); 
        }

        public ActionResult ListadoMasVendidos()
        {
            var model = ProductoModelStatic.GetListadoMasVendidos();

            return View(model);
        }



        public ActionResult ExportarListado(string nombreArchivo, string formato)
        {
            // Assuming you have a method to get the file data as a byte array
            var productos = ProductoModelStatic.GetListadoMasVendidos();
            byte[] archivoBytes;
            string fileName;

            if (formato == "csv")
            {
                // Generar archivo CSV
                var csv = new StringBuilder();
                csv.AppendLine("Codigo,Descripcion,Marca,Categoria,Cantidad Vendida");

                foreach (var producto in productos)
                {
                csv.AppendLine(String.Format("{0},{1},{2},{3},{4}", producto.Codigo, producto.Descripcion, producto.Marca, producto.Categoria, producto.Cantidad));
                }

                archivoBytes = System.Text.Encoding.UTF8.GetBytes(csv.ToString());
                fileName = String.Format("{0}.csv", nombreArchivo);
            }
            else
            {
                // Generar archivo TXT
                var txt = new StringBuilder();
                txt.AppendLine(string.Format("{0,-10} {1,-50} {2,-15} {3,-30} {4,10}",
                    "Codigo", "Descripcion", "Marca", "Categoria", "Cantidad"));

                txt.AppendLine(new string('-', 120)); // Separador

                foreach (var producto in productos)
                {
                    //txt.AppendLine(String.Format("{0},{1},{2},{3},{4}", producto.Codigo, producto.Descripcion, producto.Marca, producto.Categoria, producto.Cantidad));
                    txt.AppendLine(string.Format("{0,-10} {1,-50} {2,-15} {3,-25} {4,10}",
               producto.Codigo, producto.Descripcion, producto.Marca, producto.Categoria, producto.Cantidad));
                
                }

                archivoBytes = System.Text.Encoding.UTF8.GetBytes(txt.ToString());
                fileName = String.Format("{0}.txt", nombreArchivo);
            }

            
            return File(archivoBytes, "text/csv", fileName);
        }

    }




}
