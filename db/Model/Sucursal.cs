using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace AltaLlantaCo.db
{
    [Table(Name = "sucursal")]
    public partial class Sucursal
    {
        #region variables locales
        private int _Codigo;
        private string _nombre;
        private string _direccion;
        private string _telefono;
        private int _cod_postal;
        private Localidad _localidadObj = null;

        #endregion

        #region propiedades publicas

        [Propiedad(Name = "codigo", Tipo = typeof(int), EsAutoGenerado = true, EsClave = true)]
        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        [Propiedad(Name = "nombre", Tipo = typeof(string), Longitud = 50)]
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        [Propiedad(Name = "direccion", Tipo = typeof(string), Longitud = 90)]
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        [Propiedad(Name = "telefono", Tipo = typeof(string), Longitud = 25)]
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        [Propiedad(Name = "cod_postal", Tipo = typeof(int))]
        public int CodigoPostal
        {
            get { return _cod_postal; }
            set { _cod_postal = value; }
        }

        #endregion        

        // -- TODO --
        #region Relaciones con otras entidades
        //Localidad
        public Localidad LocalidadObj
        {
            get
            {
                if (_localidadObj == null && _cod_postal != 0)
                {
                    _localidadObj = Localidad.FindByKeyStatic(_cod_postal);
                }
                return _localidadObj;
            }
        } 
        #endregion
       
    }

}
