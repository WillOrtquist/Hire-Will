using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL
{
    /// <summary>
    /// A SQL Dao for order objects.
    /// </summary>
    public interface IOrderDAO
    {
        ///<Summary>
        /// Returns a list of every order stored in our SQL database
        ///</Summary>
        List<Order> GetAllOrders();

        /// <summary>
        /// Adds an order into our SQL database
        /// </summary>
        int AddOrder(Order order);

        bool UpdateOrderStatus(Order order);

        Order GetOrder(int id);

    }
}
