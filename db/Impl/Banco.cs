using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AltaLlantaCo.db.orm;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace AltaLlantaCo.db
{
    public partial class Banco : BaseClass, IAccessDB<Banco>, IImpleCodigo
    {  // HACER VERIFICACIONES ANTES DE REALIZAR OPERACIONES DE ACTUALIZACION, LANZAR EVENTO O EXCEPCION
        public event ValidarClaseDelegate ValidacionBancoGuardar;
        public List<Banco> FindAll()
        {
            return this.FindAll(null);
        }
        public List<Banco> FindAll(string criterio)
        {
            return ORMDB<Banco>.FindAll(criterio); 
        }
        public Banco FindbyKey(params object[] key)
        {
            var Banco = ORMDB<Banco>.FindbyKey(key);
            // completar datos en this para dejarlo inicializado
            this.Codigo = Banco.Codigo;
            this.Nombre = Banco.Nombre;
            this.SetIsObjFromDB();
            return this;
        }
        public bool SaveObj()
        {
            if (!this.IsNew)
            {
                if (this.ValidacionBancoGuardar != null)
                {
                    // Validaciones de los datos que deben estar cargados para tener una tupla de datos valida
                    if(Nombre == "" )
                        ValidacionBancoGuardar("No se puede poner Nombre vacio");
                }
            }
            return ORMDB<Banco>.SaveObject(this);
        }
        // Metodos estaticos para no usar una instancia para acceder a metodo FindAll-Banco
        public static List<Banco> FindAllStatic(string criterio=null, Comparison<Banco> compara=null)
        {
            var lista = ORMDB<Banco>.FindAll(criterio);
            if (compara != null)
                lista.Sort(compara);
            return lista;
        }

        public static Banco FindByKeyStatic(params object[] key)
        {
            return ORMDB<Banco>.FindbyKey(key);
        }
    }
    public class BancoModel
    {
        [Required]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Direccion")]
        public string Direccion { get; set; }

        [DisplayName("Telefono")]
        public string Telefono { get; set; }



    }
    public class DataTableBanco
    {
        public List<BancoModel> data { get; set; }
    }
    public class BancoStatic
    {
        public static List<SelectListItem> GetListado()
        {
            return Banco.FindAllStatic().Select(banco => new SelectListItem { Text = banco.Nombre, Value = banco.Codigo.ToString() }).ToList();
        }
    }

}
