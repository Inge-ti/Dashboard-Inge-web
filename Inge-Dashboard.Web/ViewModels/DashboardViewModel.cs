using Inge_Dashboard.Web.ViewModels.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inge_Dashboard.Web.ViewModels
{
    public class DashboardViewModel
    {
        public DashboardFiltro DashboardFiltro { get; set; }

        public IndicadoresCliente IndicadoresCliente { get; set; }
        public List<LicitacionMensual> LicitacionesMensuales { get; set; }
        public List<TotalNetoAdjudicadoMensual> TotalesNetosMensuales { get; set; }

        public DashboardViewModel()
        {
            IndicadoresCliente = new IndicadoresCliente();
            LicitacionesMensuales = new List<LicitacionMensual>();
            TotalesNetosMensuales = new List<TotalNetoAdjudicadoMensual>();
        }

    }
}
