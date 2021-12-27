using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inge_Dashboard.Web.Helpers
{
    public class FechasHelper
    {
        public static int DiferenciaMeses(DateTime desde, DateTime hasta)
        {
            int meses = ((hasta.Year - desde.Year) * 12) + hasta.Month - desde.Month;
            return meses;
        }
    }
}
