using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AltaLlantaCo.db;

namespace WebDemo.Models
{

    public class CategoriaStatic
    {
        public static List<SelectListItem> GetListado()
        {
            return Categoria.FindAllStatic().Select(categoria => new SelectListItem { Text = categoria.Descripcion, Value = categoria.Codigo.ToString() }).ToList();
        }
    }




}