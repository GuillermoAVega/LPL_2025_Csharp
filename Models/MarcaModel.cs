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
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class UniqueCodigoAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "'{0}' ya existe registrado!";
        private readonly object _typeId = new object();

        public UniqueCodigoAttribute(string codigoProperty)
            : base(_defaultErrorMessage)
        {
            CodigoProperty = codigoProperty;
        }

        public string CodigoProperty { get; private set; }

        public override object TypeId
        {
            get
            {
                return _typeId;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString, CodigoProperty);
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return ValidationResult.Success;
        }
        public override bool IsValid(object value)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);
            object originalValue = properties.Find(CodigoProperty, true).GetValue(value);
            var Mar = Marca.FindByKeyStatic(originalValue);
            return Mar == null;
            // Buscar en la Base
            //return false;
        }
    }

    





    public class MarcaModel
    {
        [Required]
        [DisplayName("Codigo")]
        public int Codigo { get;set; }

        [Required]
        [DisplayName("Descripcion")]
        public string Descripcion { get; set; }

        public List<SelectListItem> MarcasList { get; set; }
    }

    public class DataTableMarca
    {
        public List<MarcaModel> data { get; set; }
    }


    public class MarcaStatic
    {
        public static List<SelectListItem> GetListado()
        {
            return Marca.FindAllStatic().Select(mar => new SelectListItem { Text = mar.Descripcion, Value = mar.Codigo.ToString() }).ToList();
        }
    }
}

