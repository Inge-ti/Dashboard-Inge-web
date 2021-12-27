using Inge_Dashboard.Web.Helpers;
using Inge_Dashboard.Web.Services;
using Inge_Dashboard.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inge_Dashboard.Web.Controllers
{
    [Authorize]
    public class DashboardClienteController : Controller
    {
        private readonly IResumenLicitService _resumenLicitService;

        public DashboardClienteController(IResumenLicitService resumenLicitService)
        {
            _resumenLicitService = resumenLicitService;
        }
        public IActionResult Index()
        {
            return View(new DashboardViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(DashboardViewModel dashboardViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(dashboardViewModel);
            }
            try
            {
                var licitacionesCliente = await _resumenLicitService.ObtenerResumenLicitacionCliente(dashboardViewModel.DashboardFiltro);
                //Generar los resultados
                dashboardViewModel.LicitacionesMensuales = GeneradorDashboard.GenerarResumenLicitaciones(licitacionesCliente);
                dashboardViewModel.IndicadoresCliente = GeneradorDashboard.GenerarIndicadores(licitacionesCliente);
                dashboardViewModel.TotalesNetosMensuales = GeneradorDashboard.GenerarResumenTotalNetoMensuales(licitacionesCliente);
            }
            catch (Exception ex)
            {

            }


            return View(dashboardViewModel);
        }
    }
}
