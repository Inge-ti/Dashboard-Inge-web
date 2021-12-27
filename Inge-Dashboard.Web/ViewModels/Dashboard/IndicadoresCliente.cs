using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inge_Dashboard.Web.ViewModels.Dashboard
{
    public class IndicadoresCliente
    {
        [DataType(DataType.Currency)]
        [Display(Name = "Maximo Adjudicado por licitación")]
        public decimal MaximoAdjudicado { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Primera Adjudicación")]
        public DateTime? FechaPrimeraAdjudicacion { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Ventas Totales")]
        public decimal VentasTotales { get; set; }


        [DataType(DataType.Currency)]
        [Display(Name = "Promedio Mensual Total Neto Adjudicado")]
        public decimal PromedioMensualTotalNetoAdjudicaciones { get; set; }


        [Display(Name = "N° Licitaciones Adjudicadas")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int NumLicitacionesAdjudicadas { get; set; }

        [Display(Name = "N° Licitaciones Participadas")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int NumLicitacionesParticipadas { get; set; }
    }
}
