using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VEGA.Models
{
    public class Base
    {
        [Column(Order = 100)]
        public DateTime LastUpdate { get; set; }

        public Base()
        {
            LastUpdate = DateTime.Now;
        }
    }
}
