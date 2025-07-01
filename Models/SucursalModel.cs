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
    public class SucursalModel
    {
        /*
         * private string _nombre;
        private string _direccion;
        private string _telefono;
        private int _cod_postal;*/
        [Required]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Direccion")]
        public string Direccion { get; set; }

        [DisplayName("Telefono")]
        public string Telefono { get; set; }

        [DisplayName("Localidad")]
        public int CodPostal { get; set; }

        public List<SelectListItem> LocalidadesList { get; set; }

        public int Codigo { get; set; }

    }
    public class SucursalModelViewList
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Telefono { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
    public class DataTableSucursal
    {
        public List<SucursalModelViewList> data { get; set; }
    }
    public class SucursalStatic
    {
        public static List<SelectListItem> GetListado()
        {
            return Sucursal.FindAllStatic().Select(suc => new SelectListItem { Text = suc.Nombre, Value = suc.Codigo.ToString() }).ToList();
        }
    }
}