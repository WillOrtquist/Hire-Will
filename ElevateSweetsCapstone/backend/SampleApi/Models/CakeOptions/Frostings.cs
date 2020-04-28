using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    public class Frostings
    {
        public int id { get; set; }
        public string frosting { get; set; }
        public bool isAvailable { get; set; }
    }
}
