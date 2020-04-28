using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    public class Styles
    {
        public int id { get; set; }
        public string style { get; set; }
        public double price { get; set; }
        public bool isAvailable { get; set; }

        public int sizeId { get; set; }
    }
}
