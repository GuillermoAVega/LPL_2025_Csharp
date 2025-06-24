using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AltaLlantaCo.db.orm;

namespace AltaLlantaCo.db
{
    public partial class Bulto : BaseClass, IAccessDB<Bulto>
    {  // HACER VERIFICACIONES ANTES DE REALIZAR OPERACIONES DE ACTUALIZACION, LANZAR EVENTO O EXCEPCION
        public event ValidarClaseDelegate ValidacionBultoGuardar;
        public List<Bulto> FindAll()
        {
            return this.FindAll(null);
        }
        public List<Bulto> FindAll(string criterio)
        {
            return ORMDB<Bulto>.FindAll(criterio); 
        }
        public Bulto FindbyKey(params object[] key)
        {
            var act = ORMDB<Bulto>.FindbyKey(key);
            // completar datos en this para dejarlo inicializado
            this.Codigo = act.Codigo;
            this.FechaDespacho = act.FechaDespacho;
            this.FechaLlegada = act.FechaLlegada;
            this.HoraLlegada = act.HoraLlegada;
            this.Estado = act.Estado;
            this.CodFactura = act.CodFactura;
            
            this.SetIsObjFromDB();
            return this;
        }
        public bool SaveObj()
        {
            if (!this.IsNew)
            {
                if (this.ValidacionBultoGuardar != null)
                {
                    // Validaciones de los datos que deben estar cargados para tener una tupla de datos valida
                    
                }
            }
            return ORMDB<Bulto>.SaveObject(this);
        }
        // Metodos estaticos para no usar una instancia para acceder a metodo FindAll-Bulto
        public static List<Bulto> FindAllStatic(string criterio=null, Comparison<Bulto> compara=null)
        {
            var lista = ORMDB<Bulto>.FindAll(criterio);
            if (compara != null)
                lista.Sort(compara);
            return lista;
        }

        public static Bulto FindByKeyStatic(params object[] key)
        {
            return ORMDB<Bulto>.FindbyKey(key);
        }
    }
}
