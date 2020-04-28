using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    public class Cake
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string style { get; set; }
        public string size { get; set; }
        public string flavor { get; set; }
        public string frosting { get; set; }
        public string filling { get; set; }
        public string description { get; set; }
        public string imageName { get; set; }
        public bool isAvailable { get; set; }
    }
}
