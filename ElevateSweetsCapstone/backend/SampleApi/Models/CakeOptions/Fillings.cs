using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    public class Fillings
    {
        public int id { get; set; }
        public string filling { get; set; }
        public double additional_cost { get; set; }
        public bool isAvailable { get; set; }
    }
}
