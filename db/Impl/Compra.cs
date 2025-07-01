using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AltaLlantaCo.db.orm;

namespace AltaLlantaCo.db
{
    public partial class Compra : BaseClass, IAccessDB<Compra>, IImpleCodigo
    {  // HACER VERIFICACIONES ANTES DE REALIZAR OPERACIONES DE ACTUALIZACION, LANZAR EVENTO O EXCEPCION
        public event ValidarClaseDelegate ValidacionCompraGuardar;
        public List<Compra> FindAll()
        {
            return this.FindAll(null);
        }
        public List<Compra> FindAll(string criterio)
        {
            return ORMDB<Compra>.FindAll(criterio); 
        }
        public Compra FindbyKey(params object[] key)
        {
            var agn = ORMDB<Compra>.FindbyKey(key);
            // completar datos en this para dejarlo inicializado
            this.Codigo = agn.Codigo;
            this.CodFactura = agn.CodFactura;
            this.Entregado = agn.Entregado;
            this.Fecha = agn.Fecha;            
            this.SetIsObjFromDB();
            return this;
        }
        public bool SaveObj()
        {
            if (!this.IsNew)
            {
                if (this.ValidacionCompraGuardar != null)
                {
                    // Validaciones de los datos que deben estar cargados para tener una tupla de datos valida
                    
                }
            }
            return ORMDB<Compra>.SaveObject(this);
        }
        // Metodos estaticos para no usar una instancia para acceder a metodo FindAll-Compra
        public static List<Compra> FindAllStatic(string criterio=null, Comparison<Compra> compara=null)
        {
            var lista = ORMDB<Compra>.FindAll(criterio);
            if (compara != null)
                lista.Sort(compara);
            return lista;
        }

        public static Compra FindByKeyStatic(params object[] key)
        {
            return ORMDB<Compra>.FindbyKey(key);
        }
    }
}
