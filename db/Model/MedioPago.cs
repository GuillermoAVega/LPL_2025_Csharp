using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace AltaLlantaCo.db
{
    [Table(Name = "medio_pago")]
    public partial class MedioPago
    {
        #region variables locales
        private int _codigo;
        private string _descripcion;
        private int _cod_banco;            
        private Banco _bancoObj=null;
        #endregion

        #region propiedades publicas

        [Propiedad(Name = "codigo", Tipo = typeof(int), EsAutoGenerado = true, EsClave = true)]
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        [Propiedad(Name = "descripcion", Tipo = typeof(string), Longitud = 50)]
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        
        [Propiedad(Name = "cod_banco", Tipo = typeof(int))]
        public int CodigoBanco
        {
            get { return _cod_banco; }
            set { _cod_banco = value; }
        }
        #endregion        
        
        // -- TODO --
        #region Relaciones con otras entidades
        public Banco BancoObj
        {
            get
            {
                if (_bancoObj == null && _cod_banco != 0)
                {
                    _bancoObj = Banco.FindByKeyStatic(_cod_banco);
                }
                return _bancoObj;
            }
        }
        #endregion
    }

}
