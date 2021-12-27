using Inge_Dashboard.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inge_Dashboard.Web.Data
{
    public class IngeMerPubContext :DbContext
    {
        public IngeMerPubContext(DbContextOptions<IngeMerPubContext> options):base(options)
        {
        }
        public DbSet<ResumenLicitacion> ResumenesLicitacion { get; set; }

        public async Task<List<ResumenLicitacion>> Proc_Dashboard_Obtener_Resumen_Ofertas(string rutProveedor, DateTime? fechaInicio, DateTime? fechaFin)
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            List<ResumenLicitacion> lst = await this.ResumenesLicitacion.FromSqlRaw("Proc_Dashboard_Obtener_Resumen_Ofertas {0}, {1}, {2}", rutProveedor, fechaInicio, fechaFin).ToListAsync();
            return lst;
        }
    }
}
