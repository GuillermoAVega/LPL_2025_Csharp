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

    public class DetalleFacturaView
    {
        
        [Required]
        [DisplayName("Producto")]
        public string Producto { get; set; }

        [Required]
        [DisplayName("Precio")]
        public float Precio { get; set; }

        [Required]
        [DisplayName("Cantidad")]
        public int Cantidad { get; set; }
    }

    public class DataTableFactura
    {
        public List<DetalleFacturaView> data { get; set; }
    }

}