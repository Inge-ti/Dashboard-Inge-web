using Inge_Dashboard.Web.Models;
using Inge_Dashboard.Web.ViewModels.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inge_Dashboard.Web.Helpers
{
    public class GeneradorDashboard
    {
        public static List<LicitacionMensual> GenerarResumenLicitaciones(List<ResumenLicitacion> lst)
        {
            var resultado = (from lic in lst
                             group lic by lic.FechaConsulta.ToString("MM/yyyy") into l
                             select new LicitacionMensual
                             {
                                 MesAnno = l.First().FechaConsulta.ToString("MM/yyyy"),
                                 LicitacionesAdjudicadas = l.Sum(x => x.LicitacionesAdjudicadas),
                                 LicitacionesParticipadas = l.Sum(x => x.LicitacionesParticipadas)
                             }
                        ).OrderBy(x => DateTime.Parse(x.MesAnno)).ToList();
            return resultado;
        }

        public static List<TotalNetoAdjudicadoMensual> GenerarResumenTotalNetoMensuales(List<ResumenLicitacion> lst)
        {
            var resultado = (from lic in lst
                             group lic by lic.FechaConsulta.ToString("MM/yyyy") into l
                             select new TotalNetoAdjudicadoMensual
                             {
                                 MesAnno = l.First().FechaConsulta.ToString("MM/yyyy"),
                                 TotalNetoAdjudicado = l.Sum(x => x.TotalNetoAdjudicado) / 1000000
                             }).OrderBy(x => DateTime.Parse(x.MesAnno)).ToList();
            return resultado;
        }

        public static IndicadoresCliente GenerarIndicadores(List<ResumenLicitacion> lst)
        {
            var lstLicAdjudicados = lst.Where(x => x.LicitacionesAdjudicadas > 0);

            if (lstLicAdjudicados.Count() == 0) return new IndicadoresCliente();
            int meses = FechasHelper.DiferenciaMeses(lstLicAdjudicados.Min(x => x.FechaConsulta), lstLicAdjudicados.Max(x => x.FechaConsulta));

            var indicadoreDash = new IndicadoresCliente
            {
                MaximoAdjudicado = lstLicAdjudicados.Max(x => x.MaximoAdjudicado),
                FechaPrimeraAdjudicacion = lstLicAdjudicados.Min(x => x.FechaConsulta),
                VentasTotales = lstLicAdjudicados.Sum(x => x.TotalNetoAdjudicado),
                PromedioMensualTotalNetoAdjudicaciones = lstLicAdjudicados.Sum(x => x.TotalNetoAdjudicado) / meses,
                NumLicitacionesAdjudicadas = lstLicAdjudicados.Sum(x => x.LicitacionesAdjudicadas),
                NumLicitacionesParticipadas = lst.Sum(x => x.LicitacionesParticipadas)

            };
            return indicadoreDash;
        }
    }
}
