using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inge_Dashboard.Web.ViewModels.Dashboard
{
    public class DashboardFiltro
    {
        [Required(ErrorMessage = "Ingrese un rut")]
        [Display(Name = "Rut Proveedor")]
        public string RutProveedor { get; set; }

        [Display(Name = "Desde")]
        [DataType(DataType.Date)]
        public DateTime? FechaInicio { get; set; }

        [Display(Name = "Hasta")]
        [DataType(DataType.Date)]
        public DateTime? FechaFin { get; set; }

    }
}
