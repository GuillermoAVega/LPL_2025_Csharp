using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AltaLlantaCo.db.orm;

namespace AltaLlantaCo.db
{
    public partial class Producto : BaseClass, IAccessDB<Producto>, IImpleCodigo
    {  // HACER VERIFICACIONES ANTES DE REALIZAR OPERACIONES DE ACTUALIZACION, LANZAR EVENTO O EXCEPCION
        public event ValidarClaseDelegate ValidacionProductoGuardar;
        public List<Producto> FindAll()
        {
            return this.FindAll(null);
        }
        public List<Producto> FindAll(string criterio)
        {
            return ORMDB<Producto>.FindAll(criterio); 
        }
        public Producto FindbyKey(params object[] key)
        {
            var agn = ORMDB<Producto>.FindbyKey(key);
            // completar datos en this para dejarlo inicializado
            this.Codigo = agn.Codigo;
            this.CodCategoria = agn.CodCategoria;
            this.CodMarca = agn.CodMarca;
            this.Disponible = agn.Disponible;
            this.Precio = agn.Precio;
            this.Stock = agn.Stock;            
            this.SetIsObjFromDB();
            return this;
        }
        public bool SaveObj()
        {
            if (!this.IsNew)
            {
                if (this.ValidacionProductoGuardar != null)
                {
                    // Validaciones de los datos que deben estar cargados para tener una tupla de datos valida
                    
                }
            }
            return ORMDB<Producto>.SaveObject(this);
        }
        // Metodos estaticos para no usar una instancia para acceder a metodo FindAll-Producto
        public static List<Producto> FindAllStatic(string criterio=null, Comparison<Producto> compara=null)
        {
            var lista = ORMDB<Producto>.FindAll(criterio);
            if (compara != null)
                lista.Sort(compara);
            return lista;
        }

        public static Producto FindByKeyStatic(params object[] key)
        {
            return ORMDB<Producto>.FindbyKey(key);
        }
    }
}
