using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.Models
{
    public class Order
    {

        public Cake cake { get; set; }
        // public string style { get; set; }
        // public string size { get; set; }
        // public string flavor { get; set; }
        // public string frosting { get; set; }
        // public string filling { get; set; }
        // public string cakeName { get; set; }

        public string writingOnCake { get; set; }
        public int quantity { get; set; }
        public int orderId { get; set; }
        //public double price { get; set; }
        public string orderStatus { get; set; }
        public string customerName { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public double orderTotal
        {
            get { return quantity * cake.price; }
        }

        public string date { get; set; }
        public string time { get; set; }
        public DateTime pickupDateTime 
        {
            get { return DateTime.Parse(date + " " + time); }
            
        }
        
    }
}
