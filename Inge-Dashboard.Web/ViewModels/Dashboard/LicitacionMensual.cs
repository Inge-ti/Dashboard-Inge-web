using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inge_Dashboard.Web.ViewModels.Dashboard
{
    public class LicitacionMensual
    {
        public string MesAnno { get; set; }
        public int LicitacionesAdjudicadas { get; set; }
        public int LicitacionesParticipadas { get; set; }
    }
}
