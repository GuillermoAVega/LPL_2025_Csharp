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
    public class MedioPagoModel
    {
        [Required]
        [DisplayName("Descripcion")]
        public string Descripcion { get; set; }

        [DisplayName("Banco")]
        public int CodBanco { get; set; }

        public List<SelectListItem> BancosList { get; set; }

        public int Codigo { get; set; }

    }
    public class MedioPagoModelViewList
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Banco { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class DataTableMedioPago
    {
        public List<MedioPagoModelViewList> data { get; set; }
    }
    public class MedioPagoStatic
    {
        public static List<SelectListItem> GetListado()
        {
            return MedioPago.FindAllStatic().Select(mp => new SelectListItem { Text = mp.Descripcion, Value = mp.Codigo.ToString() }).ToList();
        }
    }

}