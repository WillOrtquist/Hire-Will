using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    public class Sizes
    {
        public int id { get; set; }
        public string size { get; set; }
        public double basePrice { get; set; }
        public bool isAvailable { get; set; }

        public int styleId { get; set; }
    }
}
