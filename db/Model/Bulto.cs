using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace AltaLlantaCo.db
{
    [Table(Name = "bulto")]
    public partial class Bulto
    {
        #region variables locales
        private int _codigo;
        private DateTime _fecha_despacho;
        private DateTime _fecha_llegada;
        private DateTime _hora_llegada;
        private int _estado;
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
        
        [Propiedad(Name = "fecha_despacho", Tipo = typeof(DateTime))]
        public DateTime FechaDespacho
        {
            get { return _fecha_despacho; }
            set { _fecha_despacho = value; }
        }

        [Propiedad(Name = "fecha_llegada", Tipo = typeof(DateTime))]
        public DateTime FechaLlegada
        {
            get { return _fecha_llegada; }
            set { _fecha_llegada = value; }
        }

        [Propiedad(Name = "hora_llegada", Tipo = typeof(DateTime))]
        public DateTime HoraLlegada
        {
            get { return _hora_llegada; }
            set { _hora_llegada = value; }
        }
       
        [Propiedad(Name = "estado", Tipo = typeof(int))]
        public int Estado
        {
            get { return _estado; }
            set { _estado = value; }
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
