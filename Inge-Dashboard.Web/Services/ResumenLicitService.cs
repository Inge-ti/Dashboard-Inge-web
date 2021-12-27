using Inge_Dashboard.Web.Data;
using Inge_Dashboard.Web.Models;
using Inge_Dashboard.Web.ViewModels.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inge_Dashboard.Web.Services
{
    public interface IResumenLicitService
    {
        Task<List<ResumenLicitacion>> ObtenerResumenLicitacionCliente(DashboardFiltro filtro);

    }

    public class ResumenLicitService : IResumenLicitService
    {
        private readonly IngeMerPubContext _context;
        public ResumenLicitService(IngeMerPubContext context)
        {
            _context = context;
        }

        public async Task<List<ResumenLicitacion>> ObtenerResumenLicitacionCliente(DashboardFiltro filtro)
        {
            return await _context.Proc_Dashboard_Obtener_Resumen_Ofertas(filtro.RutProveedor, filtro.FechaInicio, filtro.FechaFin);
        }
    }
}
