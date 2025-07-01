using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel;
using AltaLlantaCo.db;
using System.Web.Mvc;

namespace WebDemo.Models
{
    public class MedioPagoModel
    {
        [Required]
        [DisplayName("Descripcion")]
        public string Descripcion { get; set; }

        [DisplayName("Banco")]
        public int? CodBanco { get; set; }

        public List<SelectListItem> BancosList { get; set; }

        public int Codigo { get; set; }

    }
    public class MedioPagoModelViewList
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Banco { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class DataTableMedioPago
    {
        public List<MedioPagoModelViewList> data { get; set; }
    }
    public class MedioPagoStatic
    {
        public static List<SelectListItem> GetListado()
        {
            return MedioPago.FindAllStatic().Select(mp => new SelectListItem { Text = mp.Descripcion, Value = mp.Codigo.ToString() }).ToList();
        }
    }

   


    //Listar medios de pago mas usados
    public struct InfoMedioPago
    {
        public int CantidadUsado;
        public int Codigo;
    }

    public class MedioPagoMasUsadoView
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Banco { get; set; }
        public int VecesUsado{ get; set; }
    }

    public class DataTableMedioUsado
    {
        public List<MedioPagoMasUsadoView> data { get; set; }
    }

    public class MedioPagoModelStatic
    {

        public static List<MedioPagoMasUsadoView> GetListadoMedioPagoMasUsado()
        {
            List<MedioPago> listaMedioPagos = MedioPago.FindAllStatic();
            List<InfoMedioPago> mediosUsados = new List<InfoMedioPago>();

            int cantidadUsado = 0;

            foreach (var mPago in listaMedioPagos)
            {

                cantidadUsado = (Factura.FindAllStatic(String.Format("cod_mpago = {0}", mPago.Codigo))).Count;

                mediosUsados.Add(
                    new InfoMedioPago
                    {
                        Codigo = mPago.Codigo,
                        CantidadUsado = cantidadUsado 
                    }
                );

            }

            mediosUsados.Sort((x, y) => y.CantidadUsado.CompareTo(x.CantidadUsado));

            List<MedioPagoMasUsadoView> listaMediosMasUsados = new List<MedioPagoMasUsadoView>();

            for (int i = 0; i < mediosUsados.Count && i < 3; i++)
            {
                MedioPago mPago = MedioPago.FindByKeyStatic(mediosUsados[i].Codigo);
                Banco banco = Banco.FindByKeyStatic(mPago.CodigoBanco);
                string nombreBanco = "";
                if (banco != null)
                    nombreBanco = banco.Nombre;


                listaMediosMasUsados.Add(
                    new MedioPagoMasUsadoView
                    {
                        Codigo = mPago.Codigo,
                        Descripcion= mPago.Descripcion,
                        Banco = nombreBanco,
                        VecesUsado = mediosUsados[i].CantidadUsado
                    }
                );

            }

            return listaMediosMasUsados;
        }

    }
}