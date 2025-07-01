using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace AltaLlantaCo.db
{
    [Table(Name = "compra")]
    public partial class Compra
    {
        #region variables locales
        private int _codigo;
        private DateTime _fecha;        
        private bool _entregado;
        private int _cod_factura;
        private Factura _factura = null;
        #endregion

        #region propiedades publicas

        [Propiedad(Name = "codigo", Tipo = typeof(int), EsAutoGenerado = true, EsClave = true)]
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        
        [Propiedad(Name = "fecha", Tipo = typeof(DateTime))]
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
       
        [Propiedad(Name = "entregado", Tipo = typeof(bool))]
        public bool Entregado
        {
            get { return _entregado; }
            set { _entregado = value; }
        }


        [Propiedad(Name = "cod_factura", Tipo = typeof(int))]
        public int CodFactura
        {
            get { return _cod_factura; }
            set { _cod_factura = value; }
        }        
        #endregion       
 
        #region Relaciones con otras entidades

        public Factura FacturaObj
        {
            get
            {
                if (_factura == null && _cod_factura != 0)
                {
                    _factura = Factura.FindByKeyStatic(_factura);
                }
                return _factura;
            }
        }    
        #endregion
    }

}
