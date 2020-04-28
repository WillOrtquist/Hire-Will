using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    public class Flavors
    {
        public int id { get; set; }
        public string flavor { get; set; }
        public bool isAvailable { get; set; }
    }
}
