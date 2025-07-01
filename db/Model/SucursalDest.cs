using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace AltaLlantaCo.db
{
    [Table(Name = "sucursal_dest")]
    public partial class SucursalDest
    {
        #region variables locales
        private int _codSuc_O;
        private int _codSuc_D;
        private int _km;
        private Sucursal _sucursal_origenObj = null;
        private Sucursal _sucursal_destinoObj = null;

        #endregion

        #region propiedades publicas

        [Propiedad(Name = "cod_suc_o", Tipo = typeof(int), EsAutoGenerado = false, EsClave = true)]
        public int CodigoSucOrigen
        {
            get { return _codSuc_O; }
            set { _codSuc_O = value; }
        }

        [Propiedad(Name = "cod_suc_d", Tipo = typeof(int), EsAutoGenerado = false, EsClave = true)]
        public int CodigoSucDestino
        {
            get { return _codSuc_D; }
            set { _codSuc_D = value; }
        }


        [Propiedad(Name = "km", Tipo = typeof(int))]
        public int Km
        {
            get { return _km; }
            set { _km = value; }
        }

        #endregion

        // -- TODO --
        #region Relaciones con otras entidades

        public Sucursal SucursalOrigenObj
        {
            get
            {
                if (_sucursal_origenObj == null && CodigoSucOrigen != 0)
                {
                    _sucursal_origenObj = Sucursal.FindByKeyStatic(CodigoSucOrigen);
                }
                return _sucursal_origenObj;
            }
        }

        public Sucursal SucursalDestinoObj
        {
            get
            {
                if (_sucursal_destinoObj == null && CodigoSucDestino != 0)
                {
                    _sucursal_destinoObj = Sucursal.FindByKeyStatic(CodigoSucDestino);
                }
                return _sucursal_destinoObj;
            }
        }

        #endregion


        public override string ToString()
        {
            return string.Format("Sucursal Origen: {0} - Sucursal Destino: {1}", this._sucursal_origenObj.ToString(), this._sucursal_destinoObj.ToString());
        }

    }

}