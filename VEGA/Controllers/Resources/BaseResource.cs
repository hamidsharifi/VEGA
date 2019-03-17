using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VEGA.Controllers.Resources
{
    public class BaseResource
    {
        public DateTime LastUpdate { get; set; }

        public BaseResource()
        {
            LastUpdate = DateTime.Now;
        }
    }
}
