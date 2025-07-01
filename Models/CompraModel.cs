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

    public class CompraView
    {
        [Required]
        [DisplayName("CodFactura")]
        public int CodFactura { get; set; }

        [Required]
        [DisplayName("Codigo")]
        public int Codigo { get; set; }

        [Required]
        [DisplayName("Entregado")]
        public string Entregado { get; set; }

        [Required]
        [DisplayName("Fecha")]
        public string Fecha { get; set; }

    }

    public class DataTableCompra
    {
        public List<CompraView> data { get; set; }
    }

}