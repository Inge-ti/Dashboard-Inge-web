using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inge_Dashboard.Web.Models
{
    public class ResumenLicitacion
    {
        [Key]
        public DateTime FechaConsulta { get; set; }
        public int LicitacionesAdjudicadas { get; set; }
        public int LicitacionesParticipadas { get; set; }
        public decimal TotalNetoAdjudicado { get; set; }
        public decimal MaximoAdjudicado { get; set; }
    }
}
