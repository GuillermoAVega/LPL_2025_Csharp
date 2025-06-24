using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace AltaLlantaCo.db
{
    [Table(Name = "track_viaje")]
    public partial class TrackViaje
    {
        #region variables locales
        private int _codigo;
        private int _codigo_sucursal_o;
        private int _codigo_sucursal_d;
        private int _codigo_bulto;
        private DateTime _fecha_ingreso;
        private DateTime _hora_ingreso;
        private DateTime _fecha_salida;
        private DateTime _hora_salida;
        private string _detalle;
        private Sucursal _sucursal_origen = null;
        private Sucursal _sucursal_destino = null;
        private Bulto _bulto = null;
        #endregion

        #region propiedades publicas

        [Propiedad(Name = "codigo", Tipo = typeof(int), EsAutoGenerado = true, EsClave = true)]
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        [Propiedad(Name = "cod_suc_o", Tipo = typeof(int))]
        public int CodSucursalOrigen
        {
            get { return _codigo_sucursal_o; }
            set { _codigo_sucursal_o = value; }
        }

        [Propiedad(Name = "cod_suc_d", Tipo = typeof(int))]
        public int CodSucursalDestino
        {
            get { return _codigo_sucursal_d; }
            set { _codigo_sucursal_d = value; }
        }

        [Propiedad(Name = "cod_bulto", Tipo = typeof(int))]
        public int CodBulto
        {
            get { return _codigo_bulto; }
            set { _codigo_bulto = value; }
        }
        
        [Propiedad(Name = "f_ingreso", Tipo = typeof(DateTime))]
        public DateTime FechaIngreso
        {
            get { return _fecha_ingreso; }
            set { _fecha_ingreso = value; }
        }

        [Propiedad(Name = "h_ingreso", Tipo = typeof(DateTime))]
        public DateTime HoraIngreso
        {
            get { return _hora_ingreso; }
            set { _hora_ingreso = value; }
        }

        [Propiedad(Name = "f_salida", Tipo = typeof(DateTime))]
        public DateTime FechaSalida
        {
            get { return _fecha_salida; }
            set { _fecha_salida = value; }
        }

        [Propiedad(Name = "h_salida", Tipo = typeof(DateTime))]
        public DateTime HoraSalida
        {
            get { return _hora_salida; }
            set { _hora_salida = value; }
        }
       
        [Propiedad(Name = "detalle", Tipo = typeof(string) ,Longitud=150)]
        public string Detalle
        {
            get { return _detalle; }
            set { _detalle = value; }
        }

        

        #endregion       
 
        #region Relaciones con otras entidades
        //Sucursal O
        //Sucursal D
        //Bulto
        #endregion
    }

}
