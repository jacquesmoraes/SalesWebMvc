using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Models.Enums
{
    public enum SalesStatus : int
    {
        pending = 0,
        billed = 1,
        canceled = 2
    }
}
