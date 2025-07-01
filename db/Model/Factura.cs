using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace AltaLlantaCo.db
{
    [Table(Name = "factura")]
    public partial class Factura
    {
        #region variables locales
        private int _codigo;
        private int _nro;
        private int _serie;
        private string _letra;
        private DateTime _fecha;
        private int _cod_cliente;
        private int _cod_mpago;
        private Cliente _cliente = null;
        private MedioPago _medio_pago = null;
        #endregion

        #region propiedades publicas

        [Propiedad(Name = "codigo", Tipo = typeof(int), EsAutoGenerado = true, EsClave = true)]
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
             
        [Propiedad(Name = "nro", Tipo = typeof(int))]
        public int Nro
        {
            get { return _nro; }
            set { _nro = value; }
        }

        [Propiedad(Name = "serie", Tipo = typeof(int))]
        public int Serie
        {
            get { return _serie; }
            set { _serie = value; }
        }
        
        [Propiedad(Name = "letra", Tipo = typeof(string), Longitud = 1)]
        public string Letra
        {
            get { return _letra; }
            set { _letra = value; }
        }

        [Propiedad(Name = "fecha", Tipo = typeof(DateTime))]
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        [Propiedad(Name = "cod_cliente", Tipo = typeof(int))]
        public int CodCliente
        {
            get { return _cod_cliente; }
            set { _cod_cliente = value; }
        }

        [Propiedad(Name = "cod_mpago", Tipo = typeof(int))]
        public int CodMedioPago
        {
            get { return _cod_mpago; }
            set { _cod_mpago = value; }
        }
     
        #endregion       
 
        #region Relaciones con otras entidades

        public Cliente ClienteObj
        {
            get
            {
                if (_cliente == null && _cod_cliente != 0)
                {
                    _cliente = Cliente.FindByKeyStatic(_cliente);
                }
                return _cliente;
            }
        }


        public MedioPago MedioPagoObj
        {
            get
            {
                if (_medio_pago == null && _cod_mpago != 0)
                {
                    _medio_pago = MedioPago.FindByKeyStatic(_medio_pago);
                }
                return _medio_pago;
            }
        }


        #endregion
    }

}
