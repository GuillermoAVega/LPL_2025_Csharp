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
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class UniqueCuilAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "'{0}' ya existe registrado!";
        private readonly object _typeId = new object();

        public UniqueCuilAttribute(string cuilProperty)
            : base(_defaultErrorMessage)
        {
            CuilProperty = cuilProperty;
        }

        public string CuilProperty { get; private set; }

        public override object TypeId
        {
            get
            {
                return _typeId;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString, CuilProperty);
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return ValidationResult.Success;
        }
        public override bool IsValid(object value)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);
            object originalValue = properties.Find(CuilProperty, true).GetValue(value);
            int codigo = Convert.ToInt32 (properties.Find("Codigo", true).GetValue(value));
            var listusers = Cliente.FindAllStatic("cuil ='"+ originalValue+"' and Codigo not in (0"+ (codigo==0?"":","+codigo.ToString()) +")"  );
            if (listusers!=null)
                if(listusers.Count>0)
                  return false;
            return true;
            // Buscar en la Base
            //return false;
        }
    }

    [UniqueCuil("Cuil", ErrorMessage = "Debe ingresar cuil unico.")]
    [ClaveValida("Clave", "ConfirmaClave", ErrorMessage = "La clave y la confirmacion no coinciden.")]
    public class ClienteModel
    {
        [Required]
        [DisplayName("Usuario")]
        public string Usuario { get; set; }

        [Required]
        [DisplayName("Clave")]
        public string Clave{ get; set; }

        [Required]
        [DisplayName("Confirma Clave")]
        public string ConfirmaClave { get; set; }
        
        [Required]
        [DisplayName("Cuil")]
        public string Cuil { get; set; }
        
        [Required]
        [DisplayName("Razon Social")]
        public string RazonSocial { get; set; }
        
        [DisplayName("Direccion")]
        public string Direccion { get; set; }

        [DisplayName("Localidad")]
        public int CodPostal { get; set; }

        public List<SelectListItem> LocalidadesList { get; set; }
        
        [DisplayName("Email")]
        public string Email { get; set; }
        
        [DisplayName("Celular")]
        public string Celular { get; set; }

        
        public int Codigo { get; set; }
    }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class ClaveValidaAttribute : ValidationAttribute
    {
        private const string _defaultErrorMessage = "'{0}' and '{1}' no coinciden.";
        private readonly object _typeId = new object();

        public ClaveValidaAttribute(string originalProperty, string confirmProperty)
            : base(_defaultErrorMessage)
        {
            OriginalProperty = originalProperty;
            ConfirmProperty = confirmProperty;
        }

        public string ConfirmProperty { get; private set; }
        public string OriginalProperty { get; private set; }

        public override object TypeId
        {
            get
            {
                return _typeId;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentUICulture, ErrorMessageString,
                OriginalProperty, ConfirmProperty);
        }

        public override bool IsValid(object value)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(value);
            object originalValue = properties.Find(OriginalProperty, true /* ignoreCase */).GetValue(value);
            object confirmValue = properties.Find(ConfirmProperty, true /* ignoreCase */).GetValue(value);
            return Object.Equals(originalValue, confirmValue);
        }
    }
    public class ClienteModelViewList
    {
        public int Codigo { get; set; }
        public string Cuil { get; set; }
        public string Usuario{ get; set; }
        public string RazonSocial { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Celular { get; set; }
    }
    public class DataTableCliente
    {
        public List<ClienteModelViewList> data { get; set; }
    }   

    

}
