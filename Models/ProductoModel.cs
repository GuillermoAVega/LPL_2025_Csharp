using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel;
using AltaLlantaCo.db;
using System.Web.Mvc;

namespace WebDemo.Models
{
    public struct InfoProducto
    {
        public int Cantidad;
        public int CodigoProducto;
    }

    public class ProductoModel
    {
        [Required]
        [DisplayName("Descripcion")]
        public string Descripcion { get; set; }

        [Required]
        [DisplayName("Categoria")]
        public int CodCategoria { get; set; }
        public List<SelectListItem> CategoriaList { get; set; }

        [Required]
        [DisplayName("Marca")]
        public int CodMarca { get; set; }
        public List<SelectListItem> MarcaList { get; set; }

        [Required]
        [DisplayName("Precio")]
        public float Precio { get; set; }

        [Required]
        [DisplayName("Stock")]
        public float Stock { get; set; }

        [DisplayName("Disponibilidad")]
        public bool Disponibilidad { get; set; }

        public int Codigo { get; set; }
    }


    public class ProductoModelViewList
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public float Precio { get; set; }
        public float Stock { get; set; }
        public string Disponibilidad { get; set; }
    }

    public class DataTableProducto
    {
        public List<ProductoModelViewList> data { get; set; }
    }

    public class ListadoModel 
    {
        public List<SelectListItem> Marcas { get; set;}
        public List<SelectListItem> Categorias { get; set; }
    }

    //Logica para el listado de productos mas vendidos

    public class ProductoVendidoView
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { set; get; }
    }

    public class DataTableProductoVendido
    {
        public List<ProductoVendidoView> data { get; set; }
    }




    public class ProductoModelStatic{

        public static List<ProductoVendidoView> GetListadoMasVendidos()
        {
            List<Producto> listaProductos = Producto.FindAllStatic();
            List<DetalleFactura> listaDetalles;
            List<InfoProducto> pedidos = new List<InfoProducto>();

            int cantidad = 0;

            foreach (var producto in listaProductos)
            {

                listaDetalles = DetalleFactura.FindAllStatic(String.Format("cod_producto = {0}", producto.Codigo));

                foreach (var detalle in listaDetalles)
                {
                    cantidad += detalle.Cantidad;
                }
                pedidos.Add(new InfoProducto { Cantidad = cantidad, CodigoProducto = producto.Codigo });
                cantidad = 0;

            }

            pedidos.Sort((x, y) => y.Cantidad.CompareTo(x.Cantidad));

            List<ProductoVendidoView> productosVendidos = new List<ProductoVendidoView>();

            for(int i = 0; i < pedidos.Count && i < 5; i++)
            {
                Producto producto = Producto.FindByKeyStatic(pedidos[i].CodigoProducto);

                productosVendidos.Add(
                    new ProductoVendidoView
                    {
                        Codigo = producto.Codigo,
                        Cantidad = pedidos[i].Cantidad,
                        Categoria = producto.CategoriaObj.Descripcion,
                        Marca = producto.MarcaObj.Descripcion,
                        Descripcion = producto.Descripcion
                    }
                );
            }

            return productosVendidos;
        }


    }



}