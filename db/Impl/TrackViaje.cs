using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AltaLlantaCo.db.orm;

namespace AltaLlantaCo.db
{
    public partial class TrackViaje : BaseClass, IAccessDB<TrackViaje>
    {  // HACER VERIFICACIONES ANTES DE REALIZAR OPERACIONES DE ACTUALIZACION, LANZAR EVENTO O EXCEPCION
        public event ValidarClaseDelegate ValidacionTrackViajeGuardar;
        public List<TrackViaje> FindAll()
        {
            return this.FindAll(null);
        }
        public List<TrackViaje> FindAll(string criterio)
        {
            return ORMDB<TrackViaje>.FindAll(criterio); 
        }
        public TrackViaje FindbyKey(params object[] key)
        {
            var agn = ORMDB<TrackViaje>.FindbyKey(key);
            // completar datos en this para dejarlo inicializado
            this.CodBulto = agn.CodBulto;
            this.Codigo = agn.Codigo;
            this.CodSucursalDestino = agn.CodSucursalDestino;
            this.CodSucursalOrigen = agn.CodSucursalOrigen;
            this.Detalle = agn.Detalle;
            this.FechaIngreso = agn.FechaIngreso;
            this.FechaSalida = agn.FechaSalida;
            this.HoraIngreso = agn.HoraIngreso;
            this.HoraSalida = agn.HoraSalida;            

            this.SetIsObjFromDB();
            return this;
        }
        public bool SaveObj()
        {
            if (!this.IsNew)
            {
                if (this.ValidacionTrackViajeGuardar != null)
                {
                    // Validaciones de los datos que deben estar cargados para tener una tupla de datos valida
                    
                }
            }
            return ORMDB<TrackViaje>.SaveObject(this);
        }
        // Metodos estaticos para no usar una instancia para acceder a metodo FindAll-TrackViaje
        public static List<TrackViaje> FindAllStatic(string criterio=null, Comparison<TrackViaje> compara=null)
        {
            var lista = ORMDB<TrackViaje>.FindAll(criterio);
            if (compara != null)
                lista.Sort(compara);
            return lista;
        }

        public static TrackViaje FindByKeyStatic(params object[] key)
        {
            return ORMDB<TrackViaje>.FindbyKey(key);
        }
    }
}
